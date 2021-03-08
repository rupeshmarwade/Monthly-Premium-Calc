import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscriber, Subscription } from 'rxjs';
import { OccupationsService } from '../../service/occupations.service';
import { PremiumCalculatorService } from '../../service/premium-calculator.service';

@Component({
  selector: 'app-premium-monthly-calc',
  templateUrl: './monthlycalculator.component.html',
  styleUrls: ['./monthlycalculator.component.scss']
})
export class MonthlyPremiumCalculatorComponent implements OnInit, OnDestroy
{

  premiumcalform: FormGroup;
  occupations: any;
  result: any;
  monthlyPremium: number = 0;
  showPremium: boolean = false;
  private chnagesubscriber: Subscription;

  constructor(private fb: FormBuilder,
    private occupationsService: OccupationsService,
    private premiumCalculatorService: PremiumCalculatorService) { }

  ngOnInit(): void
  {
    this.premiumcalform = this.fb.group({
      'name': ['', Validators.required],
      'age': ['', Validators.required],
      'dob': ['', Validators.required],
      'deathSumInsured': ['', Validators.required],
      'occupationId': ['', Validators.required]
    });

    this.result = this.occupationsService.getOccupations()
      .subscribe((response) =>
      {
        this.occupations = response;
      });

    this.chnagesubscriber = this.premiumcalform.get('occupationId').valueChanges.subscribe(occupation =>
    {
      let member = this.premiumcalform.value;
      member.OccupationId = occupation;

      this.premiumCalculatorService.getMonthlyPremium(member)
        .subscribe((premiumammount) =>
        {
          this.monthlyPremium = premiumammount as number;
          this.showPremium = true;
        });
    });
  }

  ngOnDestroy(): void
  {
    if (!this.chnagesubscriber.closed) {
      this.chnagesubscriber.unsubscribe();
    }
  }

}
