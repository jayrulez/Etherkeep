import { Component } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { RegisterMode } from '../../common/register-mode';
import { RegisterModel } from '../../models/register.model';

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
	
	constructor(private accountService: AccountService)
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