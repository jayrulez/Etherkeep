"use strict";
var http_1 = require('@angular/http');
var HttpService = (function () {
    function HttpService(http) {
        this.http = http;
        this.headers = new http_1.Headers();
    }
    HttpService.prototype.authorize = function () {
        this.headers.append('Authorization', 'Bearer token');
        this.http.
        ;
        return this;
    };
    HttpService.prototype.get = function (url) {
    };
    HttpService.prototype.post = function (url) {
    };
    HttpService.prototype.put = function (url) {
    };
    HttpService.prototype.delete = function (url) {
    };
    return HttpService;
}());
exports.HttpService = HttpService;
//# sourceMappingURL=http.service.js.map