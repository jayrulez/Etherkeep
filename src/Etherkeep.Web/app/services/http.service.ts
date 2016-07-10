import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/finally';
import 'rxjs/add/observable/throw';

import { Injectable } from '@angular/core';
import { RequestMethod } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { HttpClient } from '../common/http-client';
import { AuthService } from './auth.service';
import { HttpErrorHandler } from './http-error-handler';

export class RequestData
{
	public headers = {};
	public requestMethod;
	public params: any = {};
	public data: any = {};
}

@Injectable()
export class HttpService
{
	public constructor(private httpClient: HttpClient, private authService: AuthService, private httpErrorHandler: HttpErrorHandler) {}
	
	public get(url: string, params: any = {}): Observable<any>
	{
		return this.request(RequestMethod.Get, url, {}, params);
	}
	
	public post(url: string, data: any = {}, params: any = {}): Observable<any>
	{
		return this.request(RequestMethod.Post, url, data, params);
	}

	private request(requestMethod: RequestMethod, url: string, data: any = {}, params: any = {}): Observable<any>
	{
		let authData = this.authService.getAuthData();
		
		let headers = {};
		
		if(authData != null && authData.access_token)
		{
			headers['Authorization'] = 'Bearer ' + authData.access_token;
		}
		
		headers['Content-Type'] = 'application/json';		

		let stream =  this.httpClient.request(requestMethod, url, data, params, headers)
		.catch((error: any) => {
			if(error.status == 401)
			{
				if(authData != null && authData.refresh_token)
				{
					return this.authService
						.refreshToken({ refreshToken: authData.refresh_token })
						.flatMap((tokenResponse: any) => {
							if(tokenResponse.access_token)
							{
								this.authService.setAuthData(tokenResponse);
								this.authService.loggedIn.emit(true);
								
								// retry request
								headers['Authorization'] = 'Bearer ' + tokenResponse.access_token;
								return this.httpClient.request(requestMethod, url, data, params, headers);
							}
							
							return Observable.throw(error);
						});
				}
			}
			this.httpErrorHandler.handle(error);
            return Observable.throw(error);
		});
		
		return stream;
	}
}