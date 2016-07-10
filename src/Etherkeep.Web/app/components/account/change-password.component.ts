import { Component, Output, EventEmitter } from '@angular/core';
import { NgForm }    from '@angular/common';
import { AccountService } from '../../services/account.service';
import { ChangePasswordModel } from '../../models/change-password.model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ROUTER_DIRECTIVES } from '@angular/router';

@Component({
  templateUrl: 'app/components/account/change-password.component.html',
  providers: [],
  directives: [ROUTER_DIRECTIVES]
})

export class ChangePasswordComponent
{
	error: string;
	model: ChangePasswordModel;
	constructor(private accountService: AccountService, private router: Router) {
    this.model = new ChangePasswordModel();
  }

  changePassword()
  {
    this.accountService.changePassword(this.model)
    .subscribe((response) => {
      console.log(response);
    }, (error) => {
      console.log(error);
      this.error = error.error_description;
    });
  }
}