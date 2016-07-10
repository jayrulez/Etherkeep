import { Injectable, EventEmitter, Output } from '@angular/core';

@Injectable()
export class ConnectivityService
{
	@Output()
	public isOnline: EventEmitter<boolean> = new EventEmitter<boolean>();
}