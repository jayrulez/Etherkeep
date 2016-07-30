import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/finally';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/toPromise';

import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions} from '@angular/http';
import { Observable }     from 'rxjs/Observable';

import { HttpService } from './http.service';

@Injectable()
export class WalletsService
{
	private baseUrl = 'http://localhost:5001/api';
	
	public constructor(private httpService: HttpService) {}
	
	public getPrimaryWallet()
	{
		return this.httpService.get(this.baseUrl + '/wallets/primary');
	}
}