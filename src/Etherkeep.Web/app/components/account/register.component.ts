import { Component } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { AuthService } from '../../services/auth.service';
import { IdentityType } from '../../common/identity-type';
import { LoginModel } from '../../models/login.model';
import { RegisterModel } from '../../models/register.model';
import { Router } from '@angular/router';

@Component({
  selector: 'register',
  templateUrl: 'app/components/account/register.component.html',
  providers: [],
  directives: [NgSwitch, NgSwitchCase]
})

export class RegisterComponent
{
	error: string;
	
	model: RegisterModel;
	identityType = IdentityType;
	
	constructor(private accountService: AccountService, private authService: AuthService, private router: Router)
	{
		this.model = {
			identityType: this.identityType.EmailAddress,
			emailAddress: '',
			countryCallingCode: '',
			areaCode: '',
			subscriberNumber: '',
			password: '',
			firstName: '',
			lastName: ''
		};
	}
	
	setIdentityType(type: IdentityType)
	{
		this.model.identityType = type;
	}
	
	register()
	{
		this.accountService.register(this.model)
			.subscribe((response) => {
				this.error = null;
				
				this.authService.token({
					username: response.userName,
					password: this.model.password,
					persistent: false
				})
				.subscribe(
					(tokenResponse) => {
						this.authService.setAuthData(tokenResponse);
						this.router.navigate(['home']);
					}, (errorResponse) => {
						this.router.navigate(['login']);
					}
				);
			}, (errorResponse) => {
				this.error = errorResponse.error_description;
			});
	}
}