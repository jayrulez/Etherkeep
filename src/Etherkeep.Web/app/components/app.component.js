"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var page_header_component_1 = require('./shared/layout/page-header.component');
var page_footer_component_1 = require('./shared/layout/page-footer.component');
var home_component_1 = require('./home.component');
var login_component_1 = require('./account/login.component');
var register_component_1 = require('./account/register.component');
var http_client_1 = require('../common/http-client');
var auth_service_1 = require('../services/auth.service');
var http_service_1 = require('../services/http.service');
var http_error_handler_1 = require('../services/http-error-handler');
var auth_guard_1 = require('../common/auth-guard');
var AppComponent = (function () {
    function AppComponent() {
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'app',
            templateUrl: 'app/components/app.component.html',
            directives: [
                page_header_component_1.PageHeaderComponent,
                page_footer_component_1.PageFooterComponent
            ].concat(router_1.ROUTER_DIRECTIVES),
            providers: [
                http_client_1.HttpClient,
                auth_service_1.AuthService,
                http_service_1.HttpService,
                http_error_handler_1.HttpErrorHandler,
                auth_guard_1.AuthGuard
            ],
            precompile: [
                home_component_1.HomeComponent,
                login_component_1.LoginComponent,
                register_component_1.RegisterComponent
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map