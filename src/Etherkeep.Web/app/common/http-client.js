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
var http_1 = require('@angular/http');
var Observable_1 = require('rxjs/Observable');
var http_error_handler_1 = require('./http-error-handler');
var HttpOptions = (function () {
    function HttpOptions() {
        this.headers = {};
        this.params = {};
        this.data = {};
    }
    return HttpOptions;
}());
exports.HttpOptions = HttpOptions;
var HttpClient = (function () {
    function HttpClient(http, httpErrorHandler) {
        this.http = http;
        this.httpErrorHandler = httpErrorHandler;
    }
    HttpClient.prototype.get = function (url, params) {
        var options = new HttpOptions();
        options.method = http_1.RequestMethod.Get;
        options.url = url;
        options.params = params;
        return this.request(options);
    };
    HttpClient.prototype.post = function (url, data, params) {
        var options = new HttpOptions();
        options.method = http_1.RequestMethod.Post;
        options.url = url;
        options.params = params;
        options.data = data;
        return this.request(options);
    };
    HttpClient.prototype.put = function (url) {
    };
    HttpClient.prototype.delete = function (url) {
    };
    HttpClient.prototype.request = function (options) {
        var _this = this;
        var currentInstance = this;
        options.method = (options.method || http_1.RequestMethod.Get);
        options.url = (options.url || '');
        options.headers = (options.headers || {});
        options.params = (options.params || {});
        options.data = (options.data || {});
        this.interpolateUrl(options);
        this.addXsrfToken(options);
        this.addContentType(options);
        this.addAuthorization(options);
        var requestOptions = new http_1.RequestOptions();
        requestOptions.method = options.method;
        requestOptions.url = options.url;
        requestOptions.headers = options.headers;
        requestOptions.search = this.buildUrlSearchParams(options.params);
        requestOptions.body = JSON.stringify(options.data);
        var stream = this.http.request(options.url, requestOptions)
            .catch(function (error) {
            if (error && error.status == 401) {
            }
            _this.httpErrorHandler.handle(error);
            return Observable_1.Observable.throw(error);
        })
            .map(this.unwrapHttpValue)
            .catch(function (error) {
            return Observable_1.Observable.throw(_this.unwrapHttpError(error));
        })
            .finally(function () {
        });
        return stream;
    };
    HttpClient.prototype.addContentType = function (options) {
        if (options.method !== http_1.RequestMethod.Get) {
            options.headers['Content-Type'] = 'application/json; charset=UTF-8';
        }
        return options;
    };
    HttpClient.prototype.extractValue = function (collection, key) {
        var value = collection[key];
        delete (collection[key]);
        return value;
    };
    HttpClient.prototype.addXsrfToken = function (options) {
        var xsrfToken = this.getXsrfCookie();
        if (xsrfToken) {
            options.headers['X-XSRF-TOKEN'] = xsrfToken;
        }
        return options;
    };
    HttpClient.prototype.getXsrfCookie = function () {
        var matches = document.cookie.match(/\bXSRF-TOKEN=([^\s;]+)/);
        try {
            return (matches && decodeURIComponent(matches[1]));
        }
        catch (decodeError) {
            return ('');
        }
    };
    HttpClient.prototype.addAuthorization = function (options) {
        var accessToken = localStorage.getItem('access_token');
        if (accessToken != null) {
            options.headers.Authorization = 'Bearer ' + accessToken;
        }
        return options;
    };
    HttpClient.prototype.addCors = function (options) {
        options.headers['Access-Control-Allow-Origin'] = '*';
        return options;
    };
    HttpClient.prototype.buildUrlSearchParams = function (params) {
        var searchParams = new http_1.URLSearchParams();
        for (var key in params) {
            if (params.hasOwnProperty(key)) {
                searchParams.append(key, params[key]);
            }
        }
        return searchParams;
    };
    HttpClient.prototype.interpolateUrl = function (options) {
        var _this = this;
        options.url = options.url.replace(/:([a-zA-Z]+[\w-]*)/g, function ($0, token) {
            // Try to move matching token from the params collection.
            if (options.params.hasOwnProperty(token)) {
                return (_this.extractValue(options.params, token));
            }
            // Try to move matching token from the data collection.
            if (options.data.hasOwnProperty(token)) {
                return (_this.extractValue(options.data, token));
            }
            // If a matching value couldn't be found, just replace
            // the token with the empty string.
            return ('');
        });
        // Clean up any repeating slashes.
        //options.url = options.url.replace(/\/{2,}/g, '/');
        // Clean up any trailing slashes.
        options.url = options.url.replace(/\/+$/g, '');
        return options;
    };
    HttpClient.prototype.unwrapHttpError = function (error) {
        try {
            return (error.json());
        }
        catch (jsonError) {
            return ({
                error: -1,
                error_description: 'An unexpected error occurred.'
            });
        }
    };
    HttpClient.prototype.unwrapHttpValue = function (value) {
        return (value.json());
    };
    HttpClient = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http, http_error_handler_1.HttpErrorHandler])
    ], HttpClient);
    return HttpClient;
}());
exports.HttpClient = HttpClient;
//# sourceMappingURL=http-client.js.map