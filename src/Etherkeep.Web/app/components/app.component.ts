import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

import { PageHeaderComponent } from './shared/layout/page-header.component';
import { PageFooterComponent } from './shared/layout/page-footer.component';

@Component({
  selector: 'app',
  templateUrl: 'app/components/app.component.html',
  directives: [
	PageHeaderComponent,
	PageFooterComponent,
	...ROUTER_DIRECTIVES
  ]
})
export class AppComponent { }
