import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class HttpErrorHandler {

    constructor(private _router: Router) { }

    handle(error: any) {
        if (error.status === 401) {
            this._router.navigate(['login']);
        }
    }
}