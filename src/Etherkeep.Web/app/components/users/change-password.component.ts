import { Component, Output, EventEmitter } from '@angular/core';
import { NgForm }    from '@angular/common';
import { UsersService } from '../../services/users.service';
import { ChangePasswordModel } from '../../models/change-password.model';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { ROUTER_DIRECTIVES } from '@angular/router';

@Component({
  templateUrl: 'app/components/users/change-password.component.html',
  providers: [],
  directives: [ROUTER_DIRECTIVES]
})

export class ChangePasswordComponent
{
	error: string;
	model: ChangePasswordModel;
	constructor(private usersService: UsersService, private router: Router) {
    this.model = new ChangePasswordModel();
  }

  changePassword()
  {
    this.usersService.changePassword(this.model)
    .subscribe((response) => {
      console.log(response);
    }, (error) => {
      console.log(error);
      this.error = error.error_description;
    });
  }
}