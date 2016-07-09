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
require('rxjs/add/operator/map');
require('rxjs/add/operator/catch');
require('rxjs/add/operator/finally');
require('rxjs/add/observable/throw');
var core_1 = require('@angular/core');
var Observable_1 = require('rxjs/Observable');
var http_client_1 = require('../common/http-client');
var auth_service_1 = require('./auth.service');
var http_error_handler_1 = require('./http-error-handler');
var HttpService = (function () {
    function HttpService(httpClient, authService, httpErrorHandler) {
        this.httpClient = httpClient;
        this.authService = authService;
        this.httpErrorHandler = httpErrorHandler;
    }
    HttpService.prototype.get = function (url, params) {
        var _this = this;
        if (params === void 0) { params = {}; }
        var authData = this.authService.getAuthData();
        var headers = {};
        if (authData != null && authData.access_token) {
            headers['Authorization'] = 'Bearer ' + authData.access_token;
        }
        headers['Content-Type'] = 'application/json';
        var vm = this;
        var stream = this.httpClient.get(url, params, headers)
            .catch(function (error) {
            if (error.status == 401) {
                if (authData != null && authData.refresh_token) {
                    return vm.authService
                        .refreshToken({ refreshToken: authData.refresh_token })
                        .flatMap(function (tokenResponse) {
                        console.log(tokenResponse);
                        /*
                        if(false)
                        {
                            // retry request
                            headers['Authorization'] = 'Bearer ' + 'new token';
                            
                            return this.httpClient.get(url, params, headers);
                        }*/
                        return Observable_1.Observable.throw(error);
                    });
                }
            }
            _this.httpErrorHandler.handle(error);
            return Observable_1.Observable.throw(error);
        });
        return stream;
    };
    HttpService.prototype.post = function (url, data, params) {
        if (data === void 0) { data = {}; }
        if (params === void 0) { params = {}; }
        return this.httpClient.post(url, data, params, {
            'Content-Type': 'application/json'
        });
    };
    HttpService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_client_1.HttpClient, auth_service_1.AuthService, http_error_handler_1.HttpErrorHandler])
    ], HttpService);
    return HttpService;
}());
exports.HttpService = HttpService;
//# sourceMappingURL=http.service.js.map