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
var login_mode_1 = require('../../common/login-mode');
var LoginComponent = (function () {
    function LoginComponent(accountService) {
        this.accountService = accountService;
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
        accountService.getUserInfo();
    }
    LoginComponent.prototype.setLoginMode = function (mode) {
        this.loginModel.loginMode = mode;
    };
    LoginComponent.prototype.login = function () {
        var _this = this;
        this.accountService.login(this.loginModel)
            .then(function (data) {
            console.log(data.json());
            _this.error = null;
        })
            .catch(function (error) {
            console.log(error.json());
            _this.error = error.json().error_description;
        });
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'login',
            templateUrl: 'app/components/account/login.component.html',
            providers: [account_service_1.AccountService],
            directives: [common_1.NgSwitch, common_1.NgSwitchCase]
        }), 
        __metadata('design:paramtypes', [account_service_1.AccountService])
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map