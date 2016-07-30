import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/finally';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response, Headers, RequestOptions} from '@angular/http';
import { Observable }     from 'rxjs/Observable';

import { HttpService } from './http.service';
import { AuthService } from './auth.service';
import { UserModel } from '../models/user.model';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';
import { ChangePasswordModel } from '../models/change-password.model';
import { ResetPasswordModel } from '../models/reset-password.model';
import { ConfirmResetPasswordModel } from '../models/confirm-reset-password.model';

@Injectable()
export class UsersService
{
	private baseUrl = 'http://localhost:5001/api';
	
	public constructor(private router: Router, private httpService: HttpService, private authService: AuthService) {}
	
	public register(model: RegisterModel)
	{
		return this.httpService.post(this.baseUrl + '/users/register', {
			IdentityType: model.identityType,
			CountryCallingCode: model.countryCallingCode,
			AreaCode: model.areaCode,
			SubscriberNumber: model.subscriberNumber,
			EmailAddress: model.emailAddress,
			Password: model.password,
			FirstName: model.firstName,
			LastName: model.lastName
		});
	}

	public resetPassword(model: ResetPasswordModel)
	{
		return this.httpService.post(this.baseUrl + '/users/reset_password', {
			EmailAddress: model.emailAddress
		});
	}

	public confirmResetPassword(model: ConfirmResetPasswordModel)
	{
		return this.httpService.post(this.baseUrl + '/users/reset_password', {
			EmailAddress: model.emailAddress,
			Password: model.password,
			ConfirmPassword: model.confirmPassword,
			Code: model.code
		});
	}

	public changePassword(model: ChangePasswordModel)
	{
		return this.httpService.post(this.baseUrl + '/users/change_password', {
			OldPassword: model.oldPassword,
			NewPassword: model.newPassword,
			ConfirmPassword: model.confirmPassword
		});
	}
	
	public getUser()
	{
		return this.httpService.get(this.baseUrl + '/users/me');
	}
}