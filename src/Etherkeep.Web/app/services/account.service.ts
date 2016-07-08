import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Http, Response, Headers, RequestOptions} from '@angular/http';
import { Observable }     from 'rxjs/Observable';
import 'rxjs/add/operator/toPromise';

import { HttpService } from './http.service';
import { HttpClient } from '../common/http-client';
import { UserModel } from '../models/user.model';
import { LoginModel } from '../models/login.model';
import { RegisterModel } from '../models/register.model';

@Injectable()
export class AccountService
{
	private baseUrl = 'http://localhost:5001/api';
	private authServerUrl = 'http://localhost:5001';
	
	public constructor(private router: Router, private http: Http, private httpClient: HttpClient)
	{
		
	}
	
	public getUserInfo: UserModel()
	{
		let headers = new Headers();
		headers.append('Authorization', 'Bearer CfDJ8NEARHZ5dARGtVA3NOGx4TrzoTjrNPkpsdXpo37KkXRHfp182DNcOtQ-GenMeNKCspQqaM_R2UYfFjuJ0wspWbRIfgh3GVEMO3n660wFVbiAhM82vG93O1eGSBk7_AloNsCNbgWfAoygoT-xcTK00odv892q6BUZm4Y7ym_n5I_pI_68B4t8J6TUgYrh0s1fwfQgT1I6BV8Njal6sWzkKEoSONzHqmib6Ywa9pO8p8MlI33P2jZXWtT6fwj7wlrSE2M484pb82yWtwFMIAZ_J47CxhMe-KLWK5mAiC7Bdc8c52qNzYrjR037WNcr2Yzy6NhINW_JdhIirUck_nxLfiddSTWBEvlJdj53KU-lDlracxuX0_hItLxzND-rUzu4ei7f12jG2qV5wC271oLhXe_t7IpGqZYdFoFVc99SPwr-05QyMMlbPIbUEhn_O4j9PMAoHwaXhdFfduDmLMH5F0eMNQu5IuKpY1YXjPSQGnVshHDndudXh9KMnwHVxrDz3LM14cnJjmcMr4S6jNZDVtNUwo8tudQEeRLEiT6i_pjfsY4BvEqAHgNh3RUk-PymeRh5WwyeSBwvDvXfYIwHZBs-xunS1NtH-OFkLf0Vyg8s4bDhRgzJV1wS_0-oWvtqGVr4cCDBTTU8wnBsVrwDv52X2W2zjOZUUNdgsrmN4plcR1Yy9yj8kJ1sdlQFzClpxx-R_Zo0-ha-SamIKFMeqHvhVVmD2Rz-gi2K5wVNpawwF4rwFt-Kl6DEppj96SP9WskNhK636qIAVggg7kxE0wp9sbfvTI_PPj53PW3fKogOVaFiafo4bBcJ5gkyu6ZuZmTK0b31awJye7vAANnRNglsehDzbIMBqWWqMQMhbRQoa6JPlQCyCl9RRzW1fRG1oQ');
		headers.append('Content-Type', 'application/x-www-form-urlencoded');
		
		this.httpClient.get(this.authServerUrl + '/connect/userinfo').subscribe((response: Response) => {
                console.log(response);
            },
            (errors: any) => {
                console.log(errors);
            });
		
		return null;
	}
	
	public isLoggedIn() : boolean
	{
		let token = localStorage.getItem('accessToken');
		
		if(accessToken != null)
		{
			let user = this.getUserInfo();
			
			if(user != null)
			{
				return true;
			}
		}
		
		return false;
	}
	
	public login(model: LoginModel)
	{
		let scope: string = 'openid email';
		
		if(model.persistent)
		{
			scope = scope + ' offline_access';
		}
		
		return this.http.post(this.baseUrl + '/account/login', {
			LoginMode: model.loginMode,
			CountryCallingCode: model.countryCallingCode,
			AreaCode: model.areaCode,
			SubscriberNumber: model.subscriberNumber,
			EmailAddress: model.emailAddress,
			Password: model.password,
			Scope: scope
		}).toPromise();
	};
	
	
	
	public refreshToken()
	{
		
	}
	
	public register(model: RegisterModel)
	{
		return this.http.post(this.baseUrl + '/account/register', {
			RegisterMode: model.registerMode,
			CountryCallingCode: model.countryCallingCode,
			AreaCode: model.areaCode,
			SubscriberNumber: model.subscriberNumber,
			EmailAddress: model.emailAddress,
			Password: model.password,
			FirstName: model.firstName,
			LastName: model.lastName
		}).toPromise();
	}
}