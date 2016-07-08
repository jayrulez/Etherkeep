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
require('rxjs/add/operator/toPromise');
var http_client_1 = require('../common/http-client');
var AccountService = (function () {
    function AccountService(router, http, httpClient) {
        var _this = this;
        this.router = router;
        this.http = http;
        this.httpClient = httpClient;
        this.baseUrl = 'http://localhost:5001/api';
        this.authServerUrl = 'http://localhost:5001';
        this.getUserInfo = function () {
            var headers = new http_1.Headers();
            headers.append('Authorization', 'Bearer CfDJ8NEARHZ5dARGtVA3NOGx4TrzoTjrNPkpsdXpo37KkXRHfp182DNcOtQ-GenMeNKCspQqaM_R2UYfFjuJ0wspWbRIfgh3GVEMO3n660wFVbiAhM82vG93O1eGSBk7_AloNsCNbgWfAoygoT-xcTK00odv892q6BUZm4Y7ym_n5I_pI_68B4t8J6TUgYrh0s1fwfQgT1I6BV8Njal6sWzkKEoSONzHqmib6Ywa9pO8p8MlI33P2jZXWtT6fwj7wlrSE2M484pb82yWtwFMIAZ_J47CxhMe-KLWK5mAiC7Bdc8c52qNzYrjR037WNcr2Yzy6NhINW_JdhIirUck_nxLfiddSTWBEvlJdj53KU-lDlracxuX0_hItLxzND-rUzu4ei7f12jG2qV5wC271oLhXe_t7IpGqZYdFoFVc99SPwr-05QyMMlbPIbUEhn_O4j9PMAoHwaXhdFfduDmLMH5F0eMNQu5IuKpY1YXjPSQGnVshHDndudXh9KMnwHVxrDz3LM14cnJjmcMr4S6jNZDVtNUwo8tudQEeRLEiT6i_pjfsY4BvEqAHgNh3RUk-PymeRh5WwyeSBwvDvXfYIwHZBs-xunS1NtH-OFkLf0Vyg8s4bDhRgzJV1wS_0-oWvtqGVr4cCDBTTU8wnBsVrwDv52X2W2zjOZUUNdgsrmN4plcR1Yy9yj8kJ1sdlQFzClpxx-R_Zo0-ha-SamIKFMeqHvhVVmD2Rz-gi2K5wVNpawwF4rwFt-Kl6DEppj96SP9WskNhK636qIAVggg7kxE0wp9sbfvTI_PPj53PW3fKogOVaFiafo4bBcJ5gkyu6ZuZmTK0b31awJye7vAANnRNglsehDzbIMBqWWqMQMhbRQoa6JPlQCyCl9RRzW1fRG1oQ');
            headers.append('Content-Type', 'application/x-www-form-urlencoded');
            _this.httpClient.get(_this.authServerUrl + '/connect/userinfo').subscribe(function (response) {
                console.log(response);
            }, function (errors) {
                console.log(errors);
            });
            return null;
        };
    }
    AccountService.prototype.isLoggedIn = function () {
        var token = localStorage.getItem('accessToken');
        if (accessToken != null) {
            var user = this.getUserInfo();
            if (user != null) {
                return true;
            }
        }
        return false;
    };
    AccountService.prototype.login = function (model) {
        var scope = 'openid email';
        if (model.persistent) {
            scope = scope + ' offline_access';
        }
        return this.http.post(this.baseUrl + '/account/login', {
            LoginMode: model.loginMode,
            CountryCallingCode: model.countryCallingCode,
            AreaCode: model.areaCode,
            SubscriberNumber: model.subscriberNumber,
            EmailAddress: model.emailAddress,
            Password: model.password,
            Scope: scope
        }).toPromise();
    };
    ;
    AccountService.prototype.refreshToken = function () {
    };
    AccountService.prototype.register = function (model) {
        return this.http.post(this.baseUrl + '/account/register', {
            RegisterMode: model.registerMode,
            CountryCallingCode: model.countryCallingCode,
            AreaCode: model.areaCode,
            SubscriberNumber: model.subscriberNumber,
            EmailAddress: model.emailAddress,
            Password: model.password,
            FirstName: model.firstName,
            LastName: model.lastName
        }).toPromise();
    };
    AccountService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [router_1.Router, http_1.Http, http_client_1.HttpClient])
    ], AccountService);
    return AccountService;
}());
exports.AccountService = AccountService;
//# sourceMappingURL=account.service.js.map