import {Router} 	from '@angular/router';
import {Injectable} from '@angular/core';
import {Http, Response, Headers, RequestOptions} from '@angular/http';

@Injectable()
export class HttpService
{	
	public constructor(private http: Http, private router: Router) {}

	public get(url: string, params: Map<string, any>)
	{
		let { body, options} = this.getRequestDetails(url, params);

		return this.http.get(url + "?" + body, options)
				    .toPromise();
	}

	public post(url: string, params: Map<string, any>)
	{	
		let {body, options} = this.getRequestDetails(url, params);

		return this.http.post(url, body, options)
				    .toPromise();
	}

	public put(url: string, params: Map<string, any>)
	{	
		let {body, options} = this.getRequestDetails(url, params);

		return this.http.put(url, body, options)
				    .toPromise();
	}

	public delete(url: string, params: Map<string, any>)
	{	
		let {body, options} = this.getRequestDetails(url, params);

		return this.http.delete(url + "?" + body, options)
				    .toPromise();
		});
	}

	private getRequestDetails(url: string, params: Map<string, any>)
	{	
		let headers = new Headers({
			'Content-Type': 'application/x-www-form-urlencoded'
		});

		let options = new RequestOptions({
			headers: headers
		});
		
		let body = this.getRequestBody(params);

		return {body, options};
	}

	private getRequestBody(params: Map<string, any>)
	{	
		// TODO: Encode the values using encodeURIComponent().
		let array: string[] = [];
		let body: string;

		params.forEach((value, key) => {
			array.push(key + "=" + value);
		});

		return array.join("&");
	}
}