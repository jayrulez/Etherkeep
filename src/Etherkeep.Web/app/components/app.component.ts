import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { PageHeaderComponent } from './shared/layout/page-header.component';
import { PageFooterComponent } from './shared/layout/page-footer.component';
import { HomeComponent } from './home.component';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';
import { HttpClient } from '../common/http-client';
import { HttpErrorHandler } from '../common/http-error-handler';

@Component({
  selector: 'app',
  templateUrl: 'app/components/app.component.html',
  directives: [
	PageHeaderComponent,
	PageFooterComponent,
	...ROUTER_DIRECTIVES
  ],
  providers: [HttpClient, HttpErrorHandler],
  precompile: [
	HomeComponent,
	LoginComponent,
	RegisterComponent
  ]
})
export class AppComponent { }
