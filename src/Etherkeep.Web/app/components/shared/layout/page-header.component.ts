import { Component } from '@angular/core';
import { ROUTER_DIRECTIVES } from '@angular/router';

@Component({
  selector: 'page-header',
  templateUrl: 'app/components/shared/layout/page-header.component.html',
  directives: [
	ROUTER_DIRECTIVES
  ]
})

export class PageHeaderComponent { }