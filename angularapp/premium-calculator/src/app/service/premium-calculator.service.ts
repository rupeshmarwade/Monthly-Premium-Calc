import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment.prod";
import { HttpClientService } from "./httpclient.service";
import { LoggingService } from "./logging.service";
import { map } from 'rxjs/operators';

@Injectable()
export class PremiumCalculatorService
{
    constructor(private logger: LoggingService,
        private httpclientservice: HttpClientService) { }

    getMonthlyPremium(member: any)
    {
        let apiUrl = `${environment.apiUrl}/api/premium/monthly`;
        return this.httpclientservice.post(apiUrl, null, null, member);
    }
}