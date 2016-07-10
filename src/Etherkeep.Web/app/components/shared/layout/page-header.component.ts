import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES, Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { AccountService } from '../../../services/account.service';
import { UserModel } from '../../../services/account.service';

@Component({
  selector: 'page-header',
  templateUrl: 'app/components/shared/layout/page-header.component.html',
  directives: [
	ROUTER_DIRECTIVES
  ],
  providers: [AuthService, AccountService]
})

export class PageHeaderComponent implements OnInit
{ 
	user: UserModel = {};
	constructor(private router: Router, private authService: AuthService, private accountService: AccountService)
	{

	}
	
	ngOnInit()
	{
		this.accountService.getProfile()
			.subscribe(response => {
				
				let userData = response.result;
				
				this.user = {
					id: userData.id,
					emailAddress: userData.emailAddress,
					emailAddressVerified: userData.emailAddressVerified,
					mobileNumber: userData.mobileNumber,
					mobileNumberVerified: userData.mobileNumberVerified,
					username: userData.userName,
					firstName: userData.firstName,
					lastName: userData.lastName
				}
				
			}, errorResponse => {
				this.authService.logout()
					.subscribe(response => this.router.navigate(['login']));
			});
	}
}