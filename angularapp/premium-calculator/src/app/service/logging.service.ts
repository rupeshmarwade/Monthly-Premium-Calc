import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment.prod";

@Injectable({
    providedIn: 'root'
})
export class LoggingService
{
    private consoleLogging: boolean = true;
    private serveranonymouslogging: boolean = false;
    private isprodenv: boolean = false;

    constructor(private http: HttpClient)
    {
        this.isprodenv = environment.production;
    }

    log(message: string, jsondata: any)
    {
        if (this.consoleLogging && !this.isprodenv) {
            console.log(message);
        }
    }

    info(message: string, jsondata: any)
    {

    }

    warn(message: string, jsondata: any)
    {

    }

    error(message: string, jsondata: any)
    {

    }
}