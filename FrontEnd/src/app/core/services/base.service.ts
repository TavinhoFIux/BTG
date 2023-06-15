import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { tap, catchError } from 'rxjs/operators';
import { Injectable, isDevMode } from '@angular/core';
//import { OAuthService } from 'angular-oauth2-oidc';
import { Header } from '../interfaces/http/header';

@Injectable({
    providedIn: 'root'
})
export abstract class BaseService {

   // constructor(protected oAuthService: OAuthService) { }
   constructor() {}

    protected baseUrl(): string {
        if(isDevMode()) {
            return environment.api
        }else {
            return environment.api
        }
    }

    protected getHeaderJson(extras?: Header[]): { headers: HttpHeaders } {
        return { headers: this.getHeaders(extras) };
    }

    protected getHeaders(extras?: Header[]): HttpHeaders {
        let headers: HttpHeaders = new HttpHeaders();

        const commonHeaders = [
            { name: 'Content-Type', value: 'application/json' },
            { name: 'Access-Control-Allow-Headers', value: 'X-Requested-With, Content-Type, Authorization, Origin, Accept' },
        ];

        // if (this.oAuthService.authorizationHeader()) {
        //     commonHeaders.push({ name: 'Authorization', value: this.oAuthService.authorizationHeader() });
        // }

        commonHeaders.forEach(header => headers = headers.append(header.name, header.value));

        if (extras) {
            extras.forEach((extra) => {
                headers = headers.append(extra.key, extra.value);
            });
        }

        return headers;
    }

    protected extractData = (response: any) => response || {};

    protected async serviceError(response: Response | any): Promise<any> {
        if (response instanceof HttpErrorResponse) {
            if (response.status === 304) {
                return;
            }
        }

        throw new Error(response);
    }
}