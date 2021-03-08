import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoggingService } from './logging.service';

@Injectable({
    providedIn: 'root'
})
export class HttpClientService
{

    constructor(private http: HttpClient, private logger: LoggingService) { }

    request(method, url, headers, body, params)
    {
        return this.http.request(method, url, {
            body: body || {},
            headers: headers || {},
            params: params || {}
        })
    }

    get(url, params?, headers?, data?)
    {
        return this.request('get', url, headers, data, params)
    }

    post(url, params, headers, data)
    {
        return this.request('post', url, headers, data, params);
    }

    put(url, params, headers, data)
    {
        return this.request('put', url, headers, data, params);
    }

    delete(url, params, headers, data)
    {
        return this.request('delete', url, headers, data, params);
    }
}