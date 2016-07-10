import { Component, OnInit, EventEmitter } from '@angular/core';
import { ROUTER_DIRECTIVES, Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { PageHeaderComponent } from './shared/layout/page-header.component';
import { PageFooterComponent } from './shared/layout/page-footer.component';
import { IndexComponent } from './default/index.component';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';
import { SettingsComponent } from './account/settings.component';
import { HomeComponent } from './default/home.component';
import { HttpClient } from '../common/http-client';
import { AuthGuard } from '../common/auth-guard';
import { AuthService } from '../services/auth.service';
import { HttpService } from '../services/http.service';
import { HttpErrorHandler } from '../services/http-error-handler';
import { AccountService } from '../services/account.service';
import { ConnectivityService } from '../services/connectivity.service';
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
	HttpService, 
	HttpErrorHandler,
	AuthGuard,
	AccountService
  ],
  precompile: [
	IndexComponent,
	LoginComponent,
	RegisterComponent,
	SettingsComponent,
	HomeComponent
  ]
})
export class AppComponent
{ 
	user: UserModel = null;
	
	constructor(private router: Router, private authService: AuthService, private accountService: AccountService, private connectivityService: ConnectivityService)
	{
		connectivityService.isOnline.subscribe(isOnline => {
			if(!isOnline)
			{
				console.log("Offline");
			}
			
		});
		
		authService.loggedIn.subscribe(response => {
			this.getUser();
		});
		
		authService.loggedOut.subscribe(response => {
			this.user = null;
			this.router.navigate(['login']);
		});
		
		if(authService.isLoggedIn())
		{
			this.getUser();
		}
	}
	
	getUser()
	{
		this.accountService.getAccount()
			.subscribe(response => {
				let userData = response;
				
				this.user = {
					id: userData.id,
					emailAddress: userData.emailAddress,
					emailAddressVerified: userData.emailAddressVerified,
					mobileNumber: userData.mobileNumber,
					mobileNumberVerified: userData.mobileNumberVerified,
					username: userData.userName,
					firstName: userData.firstName,
					lastName: userData.lastName
				};
				
			}, error => {
				this.user = null;
			})
	}
}
