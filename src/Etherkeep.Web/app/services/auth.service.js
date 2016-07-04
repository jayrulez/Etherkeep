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
var http_1 = require('@angular/http');
var AuthService = (function () {
    function AuthService(router, http) {
        this.router = router;
        this.http = http;
        this.baseUrl = 'http://localhost:5001/api';
    }
    AuthService.prototype.emailLogin = function (email, password, persistent) {
        var scope = 'openid email';
        if (persistent) {
            scope = scope + ' offline_access';
        }
        return this.http.post(this.baseUrl + '/auth/email_login', {
            Email: email,
            Password: password,
            Scope: scope
        }, {}).toPromise();
    };
    ;
    AuthService.prototype.phoneNumberLogin = function (countryCallingCode, areaCode, subscriberNumber, password, persistent) {
        return this.http.post(this.baseUrl + '/auth/mobile_login', {
            CountryCallingCode: countryCallingCode,
            AreaCode: areaCode,
            SubscriberNumber: subscriberNumber,
            Password: password,
            Scope: scope
        }, {}).toPromise();
    };
    AuthService.prototype.isLoggedIn = function () {
    };
    AuthService.prototype.emailRegistration = function () {
    };
    AuthService.prototype.mobileNumberRegistration = function () {
    };
    AuthService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [router_1.Router, http_1.Http])
    ], AuthService);
    return AuthService;
}());
exports.AuthService = AuthService;
//# sourceMappingURL=auth.service.js.map