import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, RequestMethod, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';

export class Options
{
	method: RequestMethod;
	url: string;
	headers: any = {};
	params = {};
	data = {};
}

@Injectable()
export class HttpClient
{
	public constructor(private http: Http) { }
	
	public get(url: string, params: any = {}, headers: any = {}): Observable<Response>
	{
		let options = new Options();
		
		options.method = RequestMethod.Get;
		options.headers = headers;
		options.url = url;
		options.params = params;
		
		return this.request(options);
	}
	
	public post(url: string, data: any = {}, params: any = {}, headers: any = {})
	{
		let options = new Options();
		
		options.method = RequestMethod.Post;
		options.headers = headers;
		options.url = url;
		options.params = params;
		options.data = data;
		
		return this.request(options);
	}
	
	public put(url: string, headers: any = {})
	{
		let options = new Options();
		
		options.method = RequestMethod.Put;
		options.headers = headers;
		options.url = url;
		
		return this.request(options);
	}
	
	public delete(url: string, headers: any = {})
	{
		let options = new Options();
		
		options.method = RequestMethod.Delete;
		options.headers = headers;
		options.url = url;
		
		return this.request(options);
	}
	
	private request(options: Options) : Observable<Response>
	{
		options.method = (options.method || RequestMethod.Get);
        options.url = (options.url || '');
        options.headers = (options.headers || {});
        options.params = (options.params || {});
        options.data = (options.data || {});

        let requestOptions = new RequestOptions();
        requestOptions.method = options.method;
        requestOptions.url = options.url;
        requestOptions.headers = options.headers;
        requestOptions.search = new URLSearchParams();
		
		for(let key in options.params)
		{
			requestOptions.search.append(key, options.params[key]);
		}
		
		
		if(requestOptions.headers['Content-Type'] == 'application/x-www-form-urlencoded')
		{
			let body: string[] = [];
			
			for(let key in options.data)
			{
				if(options.data.hasOwnProperty(key))
				{
					body.push(key + '=' + encodeURIComponent(options.data[key]));
				}
			}
			
			requestOptions.body = body.join('&');
		}else{
			requestOptions.body = JSON.stringify(options.data);
		}

        return this.http.request(options.url, requestOptions);
	}
}