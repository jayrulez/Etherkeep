import { Component, Output, EventEmitter } from '@angular/core';
import { NgForm }    from '@angular/common';
import { UsersService } from '../../services/users.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ROUTER_DIRECTIVES } from '@angular/router';

@Component({
  templateUrl: 'app/components/users/settings.component.html',
  providers: [],
  directives: [ROUTER_DIRECTIVES]
})

export class SettingsComponent
{
	constructor(private usersService: UsersService, private router: Router) {}
}