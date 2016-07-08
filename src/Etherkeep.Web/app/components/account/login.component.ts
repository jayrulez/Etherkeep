import { Component } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { LoginMode } from '../../common/login-mode';
import { LoginModel } from '../../models/login.model';

@Component({
  selector: 'login',
  templateUrl: 'app/components/account/login.component.html',
  providers: [AccountService],
  directives: [NgSwitch, NgSwitchCase]
})

export class LoginComponent
{
	error: string;
	
	loginModel: LoginModel;
	loginMode = LoginMode;
	
	constructor(private accountService: AccountService)
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
		
		accountService.getUserInfo();
	}
	
	setLoginMode(mode: LoginMode)
	{
		this.loginModel.loginMode = mode;
	}
	
	login()
	{
		this.accountService.login(this.loginModel)
			.then((data) => {
				console.log(data.json());
				this.error = null;
			})
			.catch((error) => {
				console.log(error.json());
				this.error = error.json().error_description;
			});
	}
}