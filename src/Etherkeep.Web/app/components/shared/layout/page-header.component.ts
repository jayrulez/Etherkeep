import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ROUTER_DIRECTIVES, Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { UserModel } from '../../../models/user.model';

@Component({
  selector: 'page-header',
  templateUrl: 'app/components/shared/layout/page-header.component.html',
  directives: [
	ROUTER_DIRECTIVES
  ]
})

export class PageHeaderComponent
{
	@Input() user: UserModel = null;
	
	constructor(private authService: AuthService) {}
	
	logout(event)
	{
		this.authService.loggedOut.emit(true);
	}
}