import { Component } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { IdentityType } from '../../common/identity-type';
import { ConfirmResetPasswordModel } from '../../models/confirm-reset-password.model';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'app/components/account/confirm-reset-password.component.html',
  providers: [],
  directives: [NgSwitch, NgSwitchCase]
})

export class ConfirmResetPasswordComponent
{
	error: string;
	
	model: ConfirmResetPasswordModel;
	identityType = IdentityType;
	
	constructor(private accountService: AccountService, private router: Router)
	{
		this.model = new ConfirmResetPasswordModel();
	}
	
	confirmResetPassword()
	{
	}
}