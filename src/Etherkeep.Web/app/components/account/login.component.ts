import { Component } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { AuthService } from '../../services/auth.service';
import { LoginMode } from '../../common/login-mode';
import { LoginModel } from '../../models/login.model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'login',
  templateUrl: 'app/components/account/login.component.html',
  providers: [AccountService, AuthService],
  directives: [NgSwitch, NgSwitchCase]
})

export class LoginComponent
{
	error: string;
	
	loginModel: LoginModel;
	loginMode = LoginMode;
	
	constructor(private accountService: AccountService, private authService: AuthService, private router: Router)
	{
		this.loginModel = {
			loginMode: this.loginMode.EmailAddress,
			emailAddress: '',
			countryCallingCode: '',
			areaCode: '',
			subscriberNumber: '',
			password: 'password',
			persistent: true
		};
	}
	
	setLoginMode(mode: LoginMode)
	{
		this.loginModel.loginMode = mode;
	}
	
	login()
	{
		this.accountService.username(this.loginModel)
			.map((response: any) => response.json())
			.catch((response: any) => {
				return Observable.throw(response.json());
			})
			.subscribe(
				(response: any) => {
					this.authService.token({
						username: response.result,
						password: this.loginModel.password,
						persistent: this.loginModel.persistent
					})
					.map((response: any) => response.json())
					.catch((response: any) => {
						return Observable.throw(response.json());
					})
					.subscribe(
						(tokenResponse) => {
							console.log(tokenResponse);
							this.authService.setAuthData(tokenResponse);
							this.router.navigate(['']);
						}, (tokenResponse) => {
							console.log(tokenResponse);
							this.error = tokenResponse.error_description;
						}
					);
				}, (response: any) => {
					console.log(response);
					this.error = response.result.errorDescription;
				}
			);
	}
}