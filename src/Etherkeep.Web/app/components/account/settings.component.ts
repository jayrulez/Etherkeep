import { Component, Output, EventEmitter } from '@angular/core';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ROUTER_DIRECTIVES } from '@angular/router';

@Component({
  templateUrl: 'app/components/account/settings.component.html',
  providers: [],
  directives: [ROUTER_DIRECTIVES]
})

export class SettingsComponent
{
	constructor(private accountService: AccountService, private router: Router) {}
}