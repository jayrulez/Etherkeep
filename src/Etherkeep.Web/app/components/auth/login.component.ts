import { Component } from '@angular/core';
import { NgForm }    from '@angular/common';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'login',
  templateUrl: 'app/components/auth/login.component.html',
  providers: [AuthService]
})

export class LoginComponent
{
	loginMode: string = 'email';
	
	loginModel = {
		loginMode: 'email',
		email: 'waprave@gmail.com',
		countryCallingCode: '1',
		areaCode: '876',
		subscriberNumber: '4590021',
		password: 'password',
		persistent: true,
		error: ''
	};
	
	constructor(private authService: AuthService) {}
	
	enableEmailLogin()
	{
		this.loginModel.loginMode = 'email';
	}
	
	enablePhoneNumberLogin()
	{
		this.loginModel.loginMode = 'phone';
	}
	
	login()
	{
		if(this.loginModel.loginMode == 'phone')
		{
			this.authService.phoneNumberLogin(this.loginModel.countryCallingCode, this.loginModel.areaCode, this.loginModel.subscriberNumber, this.loginModel.password, this.loginModel.persistent)
				.then((data) => {
					console.log(data.json());
					this.loginModel.error = '';
				})
				.catch((error) => {
					console.log(error.json());
					this.loginModel.error = error.json().error_description;
				});
		}else if(this.loginModel.loginMode == 'email')
		{
			this.authService.emailLogin(this.loginModel.email, this.loginModel.password, this.loginModel.persistent)
				.then((data) => {
					console.log(data.json());
					this.loginModel.error = '';
				})
				.catch((error) => {
					console.log(error.json());
					this.loginModel.error = error.json().error_description;
				});
		}else{
			
		}
	}
}