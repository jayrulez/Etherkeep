import { Injectable, EventEmitter, Output } from '@angular/core';
import { Response } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import {Subject } from 'rxjs/Subject';
import 'rxjs/Rx';

import { HttpClient } from '../common/http-client';
import { AccessTokenModel, RefreshTokenModel } from '../models/auth-model';

@Injectable()
export class AuthService
{
	@Output()
	public loggedIn: EventEmitter<any> = new EventEmitter();
	
	@Output()
	public loggedOut: EventEmitter<any> = new EventEmitter();
	
	private authServerUrl: string = 'http://localhost:5001';
	
	public constructor(private httpClient: HttpClient)
	{
	}
	
	public token(model: AccessTokenModel): Observable<Response>
	{
		let scope = 'openid profile email';
		
		if(model.persistent)
		{
			scope += ' offline_access';
		}
		
		let data = {
			grant_type: 'password',
			username: model.username,
			password: model.password,
			scope: scope
		};
		
		return this.httpClient.post(this.authServerUrl + '/connect/token', data, {}, {
			'Content-Type': 'application/x-www-form-urlencoded'
		});
	}
	
	public refreshToken(model: RefreshTokenModel): Observable<Response>
	{
		let data = {
			grant_type: 'refresh_token',
			refresh_token: model.refreshToken
		};
		
		return this.httpClient.post(this.authServerUrl + '/connect/token', data, {}, {
			'Content-Type': 'application/x-www-form-urlencoded'
		});
	}
		
	public userInfo(): Observable<Response>
	{
		let accessToken: string = 'invalid_access_token';
		let authData = this.getAuthData();
		
		if(authData != null && authData.access_token)
		{
			accessToken = authData.access_token;
		}
		
		return this.httpClient.get(this.authServerUrl + '/connect/userinfo', {}, {
			'Content-Type': 'application/x-www-form-urlencoded',
			'Authorization': 'Bearer ' + accessToken
		});
	}
	
	public getAuthData(): any
	{
		return JSON.parse(localStorage.getItem('authData'));
	}
	
	public setAuthData(authData: any)
	{
		localStorage.setItem('authData', JSON.stringify(authData));
		
		this.loggedIn.emit(true);
	}
	
	public isLoggedIn(): boolean
	{
		return this.getAuthData() != null;
	}
	
	public logout(): Observable<any>
	{
		localStorage.removeItem('authData');
		
		this.loggedOut.emit(true);
		
		return Observable.of(true);
	}
}