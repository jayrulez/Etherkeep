import { Component, OnInit, Input } from '@angular/core';
import { ROUTER_DIRECTIVES, Router } from '@angular/router';
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
}