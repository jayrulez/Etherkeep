using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Etherkeep.Server.Data;
using Etherkeep.Server.Services;
using NWebsec.AspNetCore.Middleware;
using OpenIddict;
using CryptoHelper;
using Etherkeep.Server.Data.Entities;

namespace Etherkeep.Server
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSession();

            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext, Guid>()
                .AddDefaultTokenProviders();

            // Register the OpenIddict services, including the default Entity Framework stores.
            services.AddOpenIddict<User, IdentityRole<Guid>, ApplicationDbContext, Guid>()
                .SetAuthorizationEndpointPath("/connect/authorize")
                .SetLogoutEndpointPath("/connect/logout")
                .Configure(options => options.ApplicationCanDisplayErrors = true)

                // Register the NWebsec module. Note: you can replace the default Content Security Policy (CSP)
                // by calling UseNWebsec with a custom delegate instead of using the parameterless extension.
                // This can be useful to allow your HTML views to reference remote scripts/images/styles.
                .AddNWebsec(options => options.DefaultSources(directive => directive.Self())
                    .ImageSources(directive => directive.Self()
                        .CustomSources("*"))
                    .ScriptSources(directive => directive.Self()
                        .UnsafeInline()
                        .CustomSources("https://my.custom.url/"))
                    .StyleSources(directive => directive.Self()
                        .UnsafeInline()))

                // During development, you can disable the HTTPS requirement.
                .DisableHttpsRequirement();

            // When using your own authorization controller instead of using the
            // MVC module, you need to configure the authorization/logout paths:
            // services.AddOpenIddict<User, ApplicationDbContext>()
            //     .SetAuthorizationEndpointPath("/connect/authorize")
            //     .SetLogoutEndpointPath("/connect/logout");

            // Note: if you don't explicitly register a signing key, one is automatically generated and
            // persisted on the disk. If the key cannot be persisted, an exception is thrown.
            // 
            // On production, using a X.509 certificate stored in the machine store is recommended.
            // You can generate a self-signed certificate using Pluralsight's self-cert utility:
            // https://s3.amazonaws.com/pluralsight-free/keith-brown/samples/SelfCert.zip
            // 
            // services.AddOpenIddict<User, ApplicationDbContext>()
            //     .AddSigningCertificate("7D2A741FE34CC2C7369237A5F2078988E17A6A75");
            // 
            // Alternatively, you can also store the certificate as an embedded .pfx resource
            // directly in this assembly or in a file published alongside this project:
            // 
            // services.AddOpenIddict<User, ApplicationDbContext>()
            //     .AddSigningCertificate(
            //          assembly: typeof(Startup).GetTypeInfo().Assembly,
            //          resource: "Etherkeep.Server.Certificate.pfx",
            //          password: "OpenIddict");

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddSingleton<ViewRenderer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            // Add a middleware used to validate access
            // tokens and protect the API endpoints.
            app.UseOAuthValidation();

            // Alternatively, you can also use the introspection middleware.
            // Using it is recommended if your resource server is in a
            // different application/separated from the authorization server.
            // 
            // app.UseOAuthIntrospection(options => {
            //     options.AutomaticAuthenticate = true;
            //     options.AutomaticChallenge = true;
            //     options.Authority = "http://localhost:5001/";
            //     options.Audience = "resource_server";
            //     options.ClientId = "resource_server";
            //     options.ClientSecret = "875sqd4s5d748z78z7ds1ff8zz8814ff88ed8ea4z4zzd";
            // });

            app.UseIdentity();

            app.UseGoogleAuthentication(new GoogleOptions
            {
                ClientId = Configuration["GoogleAuthentication:ClientId"],
                ClientSecret = Configuration["GoogleAuthentication:ClientSecret"]
            });

            app.UseSession();

            app.UseOpenIddict();

            app.UseCors(options => {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowCredentials();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var context = new ApplicationDbContext(
                app.ApplicationServices.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                // Add Mvc.Client to the known applications.
                if (!context.Applications.Any())
                {
                    // Note: when using the introspection middleware, your resource server
                    // MUST be registered as an OAuth2 client and have valid credentials.
                    // 
                    // context.Applications.Add(new OpenIddictApplication {
                    //     Id = "resource_server",
                    //     DisplayName = "Main resource server",
                    //     Secret = Crypto.HashPassword("secret_secret_secret"),
                    //     Type = OpenIddictConstants.ClientTypes.Confidential
                    // });

                    context.Applications.Add(new OpenIddictApplication<Guid>
                    {
                        ClientId = "myClient",
                        ClientSecret = Crypto.HashPassword("secret_secret_secret"),
                        DisplayName = "My client application",
                        LogoutRedirectUri = "http://localhost:5000/",
                        RedirectUri = "http://localhost:5000/signin-oidc",
                        Type = OpenIddictConstants.ClientTypes.Confidential
                    });

                    // To test this sample with Postman, use the following settings:
                    // 
                    // * Authorization URL: http://localhost:5001/connect/authorize
                    // * Access token URL: http://localhost:5001/connect/token
                    // * Client ID: postman
                    // * Client secret: [blank] (not used with public clients)
                    // * Scope: openid email profile roles
                    // * Grant type: authorization code
                    // * Request access token locally: yes
                    context.Applications.Add(new OpenIddictApplication<Guid>
                    {
                        ClientId = "postman",
                        DisplayName = "Postman",
                        RedirectUri = "https://www.getpostman.com/oauth2/callback",
                        Type = OpenIddictConstants.ClientTypes.Public
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
