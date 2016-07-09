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
var common_1 = require('@angular/common');
var account_service_1 = require('../../services/account.service');
var auth_service_1 = require('../../services/auth.service');
var login_mode_1 = require('../../common/login-mode');
var router_1 = require('@angular/router');
var LoginComponent = (function () {
    function LoginComponent(accountService, authService, router) {
        this.accountService = accountService;
        this.authService = authService;
        this.router = router;
        this.loginMode = login_mode_1.LoginMode;
        this.loginModel = {
            loginMode: this.loginMode.EmailAddress,
            emailAddress: '',
            countryCallingCode: '',
            areaCode: '',
            subscriberNumber: '',
            password: 'password',
            persistent: true
        };
    }
    LoginComponent.prototype.setLoginMode = function (mode) {
        this.loginModel.loginMode = mode;
    };
    LoginComponent.prototype.login = function () {
        var _this = this;
        this.accountService.username(this.loginModel)
            .subscribe(function (response) {
            _this.authService.token({
                username: response.result,
                password: _this.loginModel.password,
                persistent: _this.loginModel.persistent
            })
                .subscribe(function (tokenResponse) {
                console.log(tokenResponse);
                _this.authService.setAuthData(tokenResponse);
                _this.router.navigate(['']);
            }, function (tokenResponse) {
                console.log(tokenResponse);
                _this.error = tokenResponse.error_description;
            });
        }, function (response) {
            console.log(response);
            //this.error = response.result.errorDescription || 'An unexpected error has occured.';
        });
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'login',
            templateUrl: 'app/components/account/login.component.html',
            providers: [account_service_1.AccountService, auth_service_1.AuthService],
            directives: [common_1.NgSwitch, common_1.NgSwitchCase]
        }), 
        __metadata('design:paramtypes', [account_service_1.AccountService, auth_service_1.AuthService, router_1.Router])
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map