import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response } from '@angular/http';
import { Observable }     from 'rxjs/Observable';

import { HttpService } from './http.service';
import { UserModel } from '../models/user.model';

@Injectable()
export class AuthService
{
	private baseUrl = 'http://localhost:5001/api';
	
	public constructor(private router: Router, private http: Http)
	{
		
	}
	
	public emailLogin(email: string, password: string, persistent: boolean)
	{
		let scope = 'openid email';
		
		if(persistent)
		{
			scope = scope + ' offline_access';
		}
		
		return this.http.post(this.baseUrl + '/auth/email_login', {
			Email: email,
			Password: password,
			Scope: scope
		}, {}).toPromise();
	};
	
	public phoneNumberLogin(countryCallingCode: string, areaCode: string, subscriberNumber: string, password: string, persistent: boolean)
	{
		return this.http.post(this.baseUrl + '/auth/mobile_login', {
			CountryCallingCode: countryCallingCode,
			AreaCode: areaCode,
			SubscriberNumber: subscriberNumber,
			Password: password,
			Scope: scope
		}, {}).toPromise();
	}
	
	public isLoggedIn() : boolean
	{
		
	}
	
	public emailRegistration()
	{
		
	}
	
	public mobileNumberRegistration()
	{
		
	}
}