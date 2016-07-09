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
var Observable_1 = require('rxjs/Observable');
require('rxjs/Rx');
var http_client_1 = require('../common/http-client');
var AuthService = (function () {
    function AuthService(httpClient) {
        this.httpClient = httpClient;
        this.authServerUrl = 'http://localhost:5001';
    }
    AuthService.prototype.token = function (model) {
        var scope = 'openid profile email';
        if (model.persistent) {
            scope += ' offline_access';
        }
        var data = {
            grant_type: 'password',
            username: model.username,
            password: model.password,
            scope: scope
        };
        return this.httpClient.post(this.authServerUrl + '/connect/token', data, {}, {
            'Content-Type': 'application/x-www-form-urlencoded'
        });
    };
    AuthService.prototype.refreshToken = function (model) {
        var data = {
            grant_type: 'refresh_token',
            refresh_token: model.refreshToken
        };
        return this.httpClient.post(this.authServerUrl + '/connect/token', data, {}, {
            'Content-Type': 'application/x-www-form-urlencoded'
        });
    };
    AuthService.prototype.userInfo = function () {
        var accessToken = 'invalid_access_token';
        var authData = this.getAuthData();
        if (authData != null && authData.access_token) {
            accessToken = authData.access_token;
        }
        return this.httpClient.get(this.authServerUrl + '/connect/userinfo', {}, {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': 'Bearer ' + accessToken
        });
    };
    AuthService.prototype.getAuthData = function () {
        return JSON.parse(localStorage.getItem('authData'));
    };
    AuthService.prototype.setAuthData = function (authData) {
        localStorage.setItem('authData', JSON.stringify(authData));
    };
    AuthService.prototype.isLoggedIn = function () {
        return this.getAuthData() != null;
    };
    AuthService.prototype.logout = function () {
        localStorage.removeItem('authData');
        return Observable_1.Observable.of(true);
    };
    AuthService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_client_1.HttpClient])
    ], AuthService);
    return AuthService;
}());
exports.AuthService = AuthService;
//# sourceMappingURL=auth.service.js.map