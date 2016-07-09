import { Component } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { RegisterMode } from '../../common/register-mode';
import { AuthService } from '../../services/auth.service';
import { LoginMode } from '../../common/login-mode';
import { LoginModel } from '../../models/login.model';
import { RegisterModel } from '../../models/register.model';
import { Router } from '@angular/router';

@Component({
  selector: 'register',
  templateUrl: 'app/components/account/register.component.html',
  providers: [AccountService],
  directives: [NgSwitch, NgSwitchCase]
})

export class RegisterComponent
{
	error: string;
	
	registerModel: RegisterModel;
	registerMode = RegisterMode;
	
	constructor(private accountService: AccountService, private authService: AuthService, private router: Router)
	{
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
	
	setRegisterMode(mode: RegisterMode)
	{
		this.registerModel.registerMode = mode;
	}
	
	register()
	{
		this.accountService.register(this.registerModel)
			.subscribe((response) => {
				this.error = null;
				
				this.authService.token({
					username: response.result.userName,
					password: this.registerModel.password,
					persistent: false
				})
				.subscribe(
					(tokenResponse) => {
						console.log(tokenResponse);
						this.authService.setAuthData(tokenResponse);
						this.router.navigate(['']);
					}, (tokenResponse) => {
						this.router.navigate(['login']);
					}
				);
			}, (response) => {
				this.error = response.result.errorDescription || 'An unexpected error has occured.';
			});
	}
}