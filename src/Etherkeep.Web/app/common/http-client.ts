import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/finally';
import 'rxjs/add/observable/throw';

import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, RequestMethod, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';

import { HttpErrorHandler } from './http-error-handler';

export class HttpOptions
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
	public constructor(private http: Http, private httpErrorHandler: HttpErrorHandler)
	{
	}
	
	public get(url: string, params: Map<string, any>): Observable<Response>
	{
		let options = new HttpOptions();
		
		options.method = RequestMethod.Get;
        options.url = url;
        options.params = params;
		
		return this.request(options);
	}
	
	public post(url: string, data: Map<string, any>, params: Map<string, any>)
	{
		let options = new HttpOptions();
		
        options.method = RequestMethod.Post;
        options.url = url;
        options.params = params;
        options.data = data;
		
		return this.request(options);
	}
	
	public put(url: string)
	{
	}
	
	public delete(url: string)
	{
	}
	
	private request(options: HttpOptions) : Observable<any>
	{
		let currentInstance = this;
		
        options.method = (options.method || RequestMethod.Get);
        options.url = (options.url || '');
        options.headers = (options.headers || {});
        options.params = (options.params || {});
        options.data = (options.data || {});
		
        this.interpolateUrl(options);
        this.addXsrfToken(options);
        this.addContentType(options);
		this.addAuthorization(options);

        let requestOptions = new RequestOptions();
        requestOptions.method = options.method;
        requestOptions.url = options.url;
        requestOptions.headers = options.headers;
        requestOptions.search = this.buildUrlSearchParams(options.params);
        requestOptions.body = JSON.stringify(options.data);

        let stream = this.http.request(options.url, requestOptions)
            .catch((error: any) => {
				if(error && error.status == 401)
				{
					//access_token may be expired
					//try to refresh token
					/*
    return me.authService
             .refreshAuthenticationObservable()
             //Use flatMap instead of map
             .flatMap((authenticationResult:AuthenticationResult) => {
                   if (authenticationResult.IsAuthenticated == true) {
                     // retry with new token
                     me.authService.setAuthorizationHeader(request.headers);
                     return this.http.request(url, request);
                   }
                   return Observable.throw(initialError);
    });*/
				}
				
                this.httpErrorHandler.handle(error);
                return Observable.throw(error);
            })
            .map(this.unwrapHttpValue)
            .catch((error: any) => {
                return Observable.throw(this.unwrapHttpError(error));
            })
            .finally(() => {
            });

        return stream;
	}
	
    private addContentType(options: HttpOptions): HttpOptions
	{
        if (options.method !== RequestMethod.Get) {
            options.headers['Content-Type'] = 'application/json; charset=UTF-8';
        }
        return options;
    }
	
    private extractValue(collection: any, key: string): any
	{
        let value = collection[key];
        delete (collection[key]);
        return value;
    }
	
    private addXsrfToken(options: HttpOptions): HttpOptions
	{
        let xsrfToken = this.getXsrfCookie();
        if (xsrfToken) {
            options.headers['X-XSRF-TOKEN'] = xsrfToken;
        }
        return options;
    }

    private getXsrfCookie(): string
	{
        let matches = document.cookie.match(/\bXSRF-TOKEN=([^\s;]+)/);
		
        try
		{
            return (matches && decodeURIComponent(matches[1]));
        } catch (decodeError)
		{
            return ('');
        }
    }
	
	private addAuthorization(options: HttpOptions)
	{
		let accessToken = localStorage.getItem('access_token');
		
		if(accessToken != null)
		{
			options.headers.Authorization = 'Bearer ' + accessToken;
		}
		
		return options;
	}
	
    private addCors(options: HttpOptions): HttpOptions
	{
        options.headers['Access-Control-Allow-Origin'] = '*';
        return options;
    }

    private buildUrlSearchParams(params: any): URLSearchParams
	{
        let searchParams = new URLSearchParams();
		
        for (let key in params)
		{
            if (params.hasOwnProperty(key)) {
                searchParams.append(key, params[key]);
            }
        }
        return searchParams;
    }

    private interpolateUrl(options: HttpOptions): HttpOptions
	{
        options.url = options.url.replace(/:([a-zA-Z]+[\w-]*)/g, ($0, token) => {
            // Try to move matching token from the params collection.
            if (options.params.hasOwnProperty(token))
			{
                return (this.extractValue(options.params, token));
            }
			
            // Try to move matching token from the data collection.
            if (options.data.hasOwnProperty(token))
			{
                return (this.extractValue(options.data, token));
            }
            // If a matching value couldn't be found, just replace
            // the token with the empty string.
            return ('');
        });
		
        // Clean up any repeating slashes.
        //options.url = options.url.replace(/\/{2,}/g, '/');
		
        // Clean up any trailing slashes.
        options.url = options.url.replace(/\/+$/g, '');

        return options;
    }

    private unwrapHttpError(error: any): any
	{
        try
		{
            return (error.json());
        } catch (jsonError) {
            return ({
                error: -1,
                error_description: 'An unexpected error occurred.'
            });
        }
    }

    private unwrapHttpValue(value: Response): any
	{
        return (value.json());
    }
}