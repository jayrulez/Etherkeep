import { Component, OnInit } from '@angular/core';
import { ROUTER_DIRECTIVES, Router } from '@angular/router';

import { PageHeaderComponent } from './shared/layout/page-header.component';
import { PageFooterComponent } from './shared/layout/page-footer.component';
import { HomeComponent } from './home.component';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';
import { HttpClient } from '../common/http-client';
import { AuthGuard } from '../common/auth-guard';
import { AuthService } from '../services/auth.service';
import { HttpService } from '../services/http.service';
import { HttpErrorHandler } from '../services/http-error-handler';
import { AccountService } from '../services/account.service';
import { UserModel } from '../models/user.model';

@Component({
  selector: 'app',
  templateUrl: 'app/components/app.component.html',
  directives: [
	PageHeaderComponent,
	PageFooterComponent,
	...ROUTER_DIRECTIVES
  ],
  providers: [
	HttpClient, 
	AuthService, 
	HttpService, 
	HttpErrorHandler,
	AuthGuard,
	AccountService
  ],
  precompile: [
	HomeComponent,
	LoginComponent,
	RegisterComponent
  ]
})
export class AppComponent implements OnInit
{ 
	user: UserModel = null;
	
	constructor(private router: Router, private authService: AuthService, private accountService: AccountService)
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
	
	ngOnInit()
	{
	}
}
