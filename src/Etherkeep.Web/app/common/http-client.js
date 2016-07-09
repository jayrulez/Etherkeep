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
var http_1 = require('@angular/http');
var Observable_1 = require('rxjs/Observable');
var Options = (function () {
    function Options() {
        this.headers = {};
        this.params = {};
        this.data = {};
    }
    return Options;
}());
exports.Options = Options;
var HttpClient = (function () {
    function HttpClient(http) {
        this.http = http;
    }
    HttpClient.prototype.get = function (url, params, headers) {
        if (params === void 0) { params = {}; }
        if (headers === void 0) { headers = {}; }
        var options = new Options();
        options.method = http_1.RequestMethod.Get;
        options.headers = headers;
        options.url = url;
        options.params = params;
        return this.request(options);
    };
    HttpClient.prototype.post = function (url, data, params, headers) {
        if (data === void 0) { data = {}; }
        if (params === void 0) { params = {}; }
        if (headers === void 0) { headers = {}; }
        var options = new Options();
        options.method = http_1.RequestMethod.Post;
        options.headers = headers;
        options.url = url;
        options.params = params;
        options.data = data;
        return this.request(options);
    };
    HttpClient.prototype.put = function (url, headers) {
        if (headers === void 0) { headers = {}; }
        var options = new Options();
        options.method = http_1.RequestMethod.Put;
        options.headers = headers;
        options.url = url;
        return this.request(options);
    };
    HttpClient.prototype.delete = function (url, headers) {
        if (headers === void 0) { headers = {}; }
        var options = new Options();
        options.method = http_1.RequestMethod.Delete;
        options.headers = headers;
        options.url = url;
        return this.request(options);
    };
    HttpClient.prototype.request = function (options) {
        options.method = (options.method || http_1.RequestMethod.Get);
        options.url = (options.url || '');
        options.headers = (options.headers || {});
        options.params = (options.params || {});
        options.data = (options.data || {});
        var requestOptions = new http_1.RequestOptions();
        requestOptions.method = options.method;
        requestOptions.url = options.url;
        requestOptions.headers = options.headers;
        requestOptions.search = new http_1.URLSearchParams();
        for (var key in options.params) {
            requestOptions.search.append(key, options.params[key]);
        }
        if (requestOptions.headers['Content-Type'] == 'application/x-www-form-urlencoded') {
            var body = [];
            for (var key in options.data) {
                if (options.data.hasOwnProperty(key)) {
                    body.push(key + '=' + encodeURIComponent(options.data[key]));
                }
            }
            requestOptions.body = body.join('&');
        }
        else {
            requestOptions.body = JSON.stringify(options.data);
        }
        return this.http.request(options.url, requestOptions)
            .map(function (response) { return response.json(); })
            .catch(function (error) { return Observable_1.Observable.throw(error.json()); });
    };
    HttpClient = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [http_1.Http])
    ], HttpClient);
    return HttpClient;
}());
exports.HttpClient = HttpClient;
//# sourceMappingURL=http-client.js.map