import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom, tap } from "rxjs";
import { HttpDeleteOptions } from "../interfaces/http/http-delete-options";
import { HttpGetOptions } from "../interfaces/http/http-get-options";
import { HttpPostOptions } from "../interfaces/http/http-post-options";
import { HttpPutOptions } from "../interfaces/http/http-put-options";

@Injectable({
    providedIn: 'root',
  })
  
  export class HttpService {
    
    constructor(
      private http: HttpClient,
    ) {}
  
    public get = (url: string, options?: HttpGetOptions): Promise<any> =>
      this.request('GET', url, options);
  
    public post = (
      url: string,
      options?: HttpPostOptions
    ): Promise<any> => this.request('POST', url, options);;
  
    public put = (url: string, options?: HttpPutOptions): Promise<any> =>
      this.request('PUT', url, options);
  
    public patch = (
      url: string,
      body: any | null,
      options?: HttpPutOptions
    ): Promise<any> => firstValueFrom(this.http.patch(url, body, options))
  
  
    public delete = (url: string, options?: HttpDeleteOptions): Promise<any> =>
      this.request('DELETE', url, options);
  
    private request(
      method: string,
      url: string,
      options: any
    ): Promise<Object> {
      return firstValueFrom(this.http.request(method, url, options));
    }
  
  }
  