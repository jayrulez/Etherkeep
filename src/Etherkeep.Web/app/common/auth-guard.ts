import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from '../services/auth.service';


@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {}

  canActivate(): boolean
  {
    if (this.authService.isLoggedIn())
	{
		let canActivate = true;
		
		this.authService.logout()
			.subscribe(
				(success) => {
					console.log('here');
					canActivate = false;
					this.router.navigate(['login']);
				}, 
				(failure) => {
					console.log('here');
					canActivate = true;
					this.router.navigate(['login']);
				}
			);
		return canActivate;
    }

    this.router.navigate(['login']);
    return false;
  }
}