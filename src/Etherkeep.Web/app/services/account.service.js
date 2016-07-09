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
var http_service_1 = require('./http.service');
var auth_service_1 = require('./auth.service');
var AccountService = (function () {
    function AccountService(router, httpService, authService) {
        this.router = router;
        this.httpService = httpService;
        this.authService = authService;
        this.baseUrl = 'http://localhost:5001/api';
    }
    AccountService.prototype.username = function (model) {
        return this.httpService.post(this.baseUrl + '/account/username', {
            LoginMode: model.loginMode,
            CountryCallingCode: model.countryCallingCode,
            AreaCode: model.areaCode,
            SubscriberNumber: model.subscriberNumber,
            EmailAddress: model.emailAddress,
            Password: model.password
        }, {});
    };
    ;
    AccountService.prototype.register = function (model) {
        return this.httpService.post(this.baseUrl + '/account/register', {
            RegisterMode: model.registerMode,
            CountryCallingCode: model.countryCallingCode,
            AreaCode: model.areaCode,
            SubscriberNumber: model.subscriberNumber,
            EmailAddress: model.emailAddress,
            Password: model.password,
            FirstName: model.firstName,
            LastName: model.lastName
        });
    };
    AccountService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [router_1.Router, http_service_1.HttpService, auth_service_1.AuthService])
    ], AccountService);
    return AccountService;
}());
exports.AccountService = AccountService;
//# sourceMappingURL=account.service.js.map