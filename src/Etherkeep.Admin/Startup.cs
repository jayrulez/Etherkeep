using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Etherkeep.Admin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options => {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            // Insert a new cookies middleware in the pipeline to store the user
            // identity after he has been redirected from the identity provider.
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/signin")
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                // Note: these settings must match the application details
                // inserted in the database at the server level.
                ClientId = "admin",
                ClientSecret = "admin",
                PostLogoutRedirectUri = "http://localhost:5003/",

                RequireHttpsMetadata = false,
                GetClaimsFromUserInfoEndpoint = true,
                SaveTokens = true,

                // Use the authorization code flow.
                ResponseType = OpenIdConnectResponseType.Code,
                AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet,

                // Note: setting the Authority allows the OIDC client middleware to automatically
                // retrieve the identity provider's configuration and spare you from setting
                // the different endpoints URIs or the token validation parameters explicitly.
                Authority = "http://localhost:5001/",

                Scope = { "email", "roles", "offline_access" }
            });

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Dashboard}/{action=Index}/{id?}");
            });
        }
    }
}
