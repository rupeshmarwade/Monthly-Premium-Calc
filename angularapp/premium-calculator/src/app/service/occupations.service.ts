import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment.prod";
import { HttpClientService } from "./httpclient.service";

@Injectable()
export class OccupationsService
{
    constructor(private httpclientservice: HttpClientService) { }

    getOccupations()
    {
        return this.httpclientservice.get(`${environment.apiUrl}/api/occupations`);
    }
}