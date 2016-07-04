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
var router_1 = require('angular2/router');
var core_1 = require('angular2/core');
var http_1 = require('angular2/http');
var HttpService = (function () {
    function HttpService(http, router) {
        this.http = http;
        this.router = router;
    }
    HttpService.prototype.get = function (url, params) {
        var _a = this.getRequestDetails(url, params), body = _a.body, options = _a.options;
        return this.http.get(url + "?" + body, options)
            .toPromise();
    };
    HttpService.prototype.post = function (url, params) {
        var _a = this.getRequestDetails(url, params), body = _a.body, options = _a.options;
        return this.http.post(url, body, options)
            .toPromise();
    };
    HttpService.prototype.put = function (url, params) {
        var _a = this.getRequestDetails(url, params), body = _a.body, options = _a.options;
        return this.http.put(url, body, options)
            .toPromise();
    };
    HttpService.prototype.delete = function (url, params) {
        var _a = this.getRequestDetails(url, params), body = _a.body, options = _a.options;
        return this.http.delete(url + "?" + body, options)
            .toPromise();
    };
    ;
    HttpService = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [(typeof (_a = typeof http_1.Http !== 'undefined' && http_1.Http) === 'function' && _a) || Object, (typeof (_b = typeof router_1.Router !== 'undefined' && router_1.Router) === 'function' && _b) || Object])
    ], HttpService);
    return HttpService;
    var _a, _b;
}());
exports.HttpService = HttpService;
getRequestDetails(url, string, params, Map(), {
    let: headers = new http_1.Headers({
        'Content-Type': 'application/x-www-form-urlencoded'
    }),
    let: options = new http_1.RequestOptions({
        headers: headers
    }),
    let: body = this.getRequestBody(params),
    return: { body: body, options: options }
}, private, getRequestBody(params, Map(), {
    // TODO: Encode the values using encodeURIComponent().
    let: array, string: [],
    let: body, string: ,
    params: .forEach(function (value, key) {
        array.push(key + "=" + value);
    }),
    return: array.join("&")
}));
//# sourceMappingURL=http.service.js.map