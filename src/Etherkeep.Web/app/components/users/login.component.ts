import { Component, Output, EventEmitter } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { UsersService } from '../../services/users.service';
import { AuthService } from '../../services/auth.service';
import { IdentityType } from '../../common/identity-type';
import { LoginModel } from '../../models/login.model';
import { ROUTER_DIRECTIVES, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'login',
  templateUrl: 'app/components/users/login.component.html',
  directives: [
	  NgSwitch, 
	  NgSwitchCase,
	  ROUTER_DIRECTIVES
  ]
})

export class LoginComponent
{
	error: string;
	
	model: LoginModel;
	identityType = IdentityType;
	
	constructor(private usersService: UsersService, private authService: AuthService, private router: Router)
	{
		this.model = {
			identityType: this.identityType.EmailAddress,
			emailAddress: '',
			countryCallingCode: '',
			areaCode: '',
			subscriberNumber: '',
			password: '',
			persistent: true
		};
	}
	
	setIdentityType(type: IdentityType)
	{
		this.model.identityType = type;
	}
	
	login()
	{
		let username = this.model.identityType == IdentityType.EmailAddress ? this.model.emailAddress : this.model.countryCallingCode +"-"+ this.model.areaCode +"-"+ this.model.subscriberNumber;
		
		this.authService.token({
			username: username,
			password: this.model.password,
			persistent: this.model.persistent
		})
		.subscribe(
			(tokenResponse) => {
				this.authService.setAuthData(tokenResponse);
				
				this.router.navigate(['home']);
				
			}, (tokenResponse) => {
				this.error = tokenResponse.error_description;
			}
		);
	}
}