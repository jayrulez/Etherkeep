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
var HttpErrorHandler = (function () {
    function HttpErrorHandler(_router) {
        this._router = _router;
    }
    HttpErrorHandler.prototype.handle = function (error) {
        if (error.status === 401) {
            sessionStorage.clear();
            this._router.navigate(['Login']);
        }
    };
    HttpErrorHandler = __decorate([
        core_1.Injectable(), 
        __metadata('design:paramtypes', [router_1.Router])
    ], HttpErrorHandler);
    return HttpErrorHandler;
}());
exports.HttpErrorHandler = HttpErrorHandler;
//# sourceMappingURL=http-error-handler.js.map