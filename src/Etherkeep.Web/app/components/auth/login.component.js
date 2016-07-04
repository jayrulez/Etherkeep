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
var auth_service_1 = require('../../services/auth.service');
var LoginComponent = (function () {
    function LoginComponent(authService) {
        this.authService = authService;
        this.loginMode = 'email';
        this.loginModel = {
            loginMode: 'email',
            email: 'waprave@gmail.com',
            countryCallingCode: '1',
            areaCode: '876',
            subscriberNumber: '4590021',
            password: 'password',
            persistent: true,
            error: ''
        };
    }
    LoginComponent.prototype.enableEmailLogin = function () {
        this.loginModel.loginMode = 'email';
    };
    LoginComponent.prototype.enablePhoneNumberLogin = function () {
        this.loginModel.loginMode = 'phone';
    };
    LoginComponent.prototype.login = function () {
        var _this = this;
        if (this.loginModel.loginMode == 'phone') {
            this.authService.phoneNumberLogin(this.loginModel.countryCallingCode, this.loginModel.areaCode, this.loginModel.subscriberNumber, this.loginModel.password, this.loginModel.persistent)
                .then(function (data) {
                console.log(data.json());
                _this.loginModel.error = '';
            })
                .catch(function (error) {
                console.log(error.json());
                _this.loginModel.error = error.json().error_description;
            });
        }
        else if (this.loginModel.loginMode == 'email') {
            this.authService.emailLogin(this.loginModel.email, this.loginModel.password, this.loginModel.persistent)
                .then(function (data) {
                console.log(data.json());
                _this.loginModel.error = '';
            })
                .catch(function (error) {
                console.log(error.json());
                _this.loginModel.error = error.json().error_description;
            });
        }
        else {
        }
    };
    LoginComponent = __decorate([
        core_1.Component({
            selector: 'login',
            templateUrl: 'app/components/auth/login.component.html',
            providers: [auth_service_1.AuthService]
        }), 
        __metadata('design:paramtypes', [auth_service_1.AuthService])
    ], LoginComponent);
    return LoginComponent;
}());
exports.LoginComponent = LoginComponent;
//# sourceMappingURL=login.component.js.map