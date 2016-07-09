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
var common_1 = require('@angular/common');
var account_service_1 = require('../../services/account.service');
var register_mode_1 = require('../../common/register-mode');
var RegisterComponent = (function () {
    function RegisterComponent(accountService) {
        this.accountService = accountService;
        this.registerMode = register_mode_1.RegisterMode;
        this.registerModel = {
            registerMode: this.registerMode.EmailAddress,
            emailAddress: '',
            countryCallingCode: '',
            areaCode: '',
            subscriberNumber: '',
            password: '',
            firstName: '',
            lastName: ''
        };
    }
    RegisterComponent.prototype.setRegisterMode = function (mode) {
        this.registerModel.registerMode = mode;
    };
    RegisterComponent.prototype.register = function () {
        var _this = this;
        this.accountService.register(this.registerModel)
            .map(function (response) { return response.json(); })
            .subscribe(function (response) {
            _this.error = null;
        }, function (response) {
            _this.error = response.result;
        });
    };
    RegisterComponent = __decorate([
        core_1.Component({
            selector: 'register',
            templateUrl: 'app/components/account/register.component.html',
            providers: [account_service_1.AccountService],
            directives: [common_1.NgSwitch, common_1.NgSwitchCase]
        }), 
        __metadata('design:paramtypes', [account_service_1.AccountService])
    ], RegisterComponent);
    return RegisterComponent;
}());
exports.RegisterComponent = RegisterComponent;
//# sourceMappingURL=register.component.js.map