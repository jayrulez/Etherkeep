import { Component, Output, EventEmitter } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { AuthService } from '../../services/auth.service';
import { IdentityType } from '../../common/identity-type';
import { LoginModel } from '../../models/login.model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'login',
  templateUrl: 'app/components/account/login.component.html',
  providers: [],
  directives: [NgSwitch, NgSwitchCase]
})

export class LoginComponent
{
	error: string;
	
	loginModel: LoginModel;
	identityType = IdentityType;
	
	constructor(private accountService: AccountService, private authService: AuthService, private router: Router)
	{
		this.loginModel = {
			identityType: this.identityType.EmailAddress,
			emailAddress: '',
			countryCallingCode: '',
			areaCode: '',
			subscriberNumber: '',
			password: 'password',
			persistent: true
		};
	}
	
	setIdentityType(type: IdentityType)
	{
		this.loginModel.identityType = type;
	}
	
	login()
	{
		this.accountService.username(this.loginModel)
			.subscribe(
				(response: any) => {
					this.authService.token({
						username: response.result,
						password: this.loginModel.password,
						persistent: this.loginModel.persistent
					})
					.subscribe(
						(tokenResponse) => {
							this.authService.setAuthData(tokenResponse);
							
							this.router.navigate(['home']);
							
						}, (tokenResponse) => {
							this.error = tokenResponse.error_description;
						}
					);
				}, (response: any) => {
					this.error = response.result.error_description;
				}
			);
	}
}