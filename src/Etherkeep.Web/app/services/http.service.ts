import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/finally';
import 'rxjs/add/observable/throw';

import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { HttpClient } from '../common/http-client';
import { AuthService } from './auth.service';
import { HttpErrorHandler } from './http-error-handler';

@Injectable()
export class HttpService
{
	public constructor(private httpClient: HttpClient, private authService: AuthService, private httpErrorHandler: HttpErrorHandler) {}
	
	public get(url: string, params: any = {}): Observable<any>
	{
		let authData = this.authService.getAuthData();
		
		let headers = {};
		
		if(authData != null && authData.access_token)
		{
			headers['Authorization'] = 'Bearer ' + authData.access_token;
		}
		
		headers['Content-Type'] = 'application/json';
		
		let vm = this;
		
		let stream = this.httpClient.get(url, params, headers)
		.catch((error: any) => {
			if(error.status == 401)
			{
				if(authData != null && authData.refresh_token)
				{
					return vm.authService
						.refreshToken({ refreshToken: authData.refresh_token })
						.flatMap((tokenResponse: any) => {
							if(tokenResponse.access_token)
							{
								this.authService.setAuthData(tokenResponse);
								this.authService.loggedIn.emit(true);
								
								// retry request
								headers['Authorization'] = 'Bearer ' + tokenResponse.access_token;
								return this.httpClient.get(url, params, headers);
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
	
	public post(url: string, data: any = {}, params: any = {}): Observable<any>
	{
		return this.httpClient.post(url, data, params, {
			'Content-Type': 'application/json'
		});
	}
}