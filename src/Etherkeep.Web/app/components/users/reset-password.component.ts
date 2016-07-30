import { Component } from '@angular/core';
import { NgSwitch, NgSwitchCase, NgSwitchDefault } from '@angular/common';
import { NgForm }    from '@angular/common';
import { ROUTER_DIRECTIVES, Router } from '@angular/router';
import { UsersService } from '../../services/users.service';
import { IdentityType } from '../../common/identity-type';
import { ResetPasswordModel } from '../../models/reset-password.model';

@Component({
  templateUrl: 'app/components/users/reset-password.component.html',
  providers: [],
  directives: [
	  ROUTER_DIRECTIVES
  ]
})

export class ResetPasswordComponent
{
	error: string;
	
	model: ResetPasswordModel;
	identityType = IdentityType;
	
	constructor(private usersService: UsersService, private router: Router)
	{
		this.model = new ResetPasswordModel();
	}
	
	resetPassword()
	{
        this.usersService.resetPassword(this.model)
        .subscribe((response) => {
            console.log('finished');
            //this.router.navigate(['confirm-reset-password']);
        }, (errorResponse) => {
            console.log('finished with error');
            console.log(errorResponse);
        });
	}
}