import { Component } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { UsersService } from '../../services/users.service';
import { IdentityType } from '../../common/identity-type';
import { ConfirmResetPasswordModel } from '../../models/confirm-reset-password.model';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'app/components/users/confirm-reset-password.component.html',
  providers: [],
  directives: [NgSwitch, NgSwitchCase]
})

export class ConfirmResetPasswordComponent
{
	error: string;
	
	model: ConfirmResetPasswordModel;
	identityType = IdentityType;
	
	constructor(private usersService: UsersService, private router: Router)
	{
		this.model = new ConfirmResetPasswordModel();
	}
	
	confirmResetPassword()
	{
	}
}