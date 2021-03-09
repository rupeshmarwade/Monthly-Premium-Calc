import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';
import { Moment } from 'moment';
import { Subscription } from 'rxjs';
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
  private occupationsubscription: Subscription;
  private premiumSubscription: Subscription;

  constructor(private fb: FormBuilder,
    private occupationsService: OccupationsService,
    private premiumCalculatorService: PremiumCalculatorService) { }

  ngOnInit(): void
  {
    this.premiumcalform = this.fb.group({
      'name': ['', Validators.required],
      'age': ['', [Validators.required, Validators.min(0), Validators.max(100)]],
      'dob': ['', Validators.required],
      'deathSumInsured': ['', Validators.required],
      'occupationId': ['', Validators.required]
    });

    this.occupationsubscription = this.occupationsService.getOccupations()
      .subscribe((response) =>
      {
        this.occupations = response;
      });
  }


  dateFilter = (d: Date): boolean =>
  {
    const dateRange = [new Date(new Date().getFullYear() - 100, 0, 1),
    new Date(new Date())]
    return (d >= dateRange[0] && d <= dateRange[1])
  }

  handleDOBChange(event)
  {
    const m: Moment = event.value;
    if (m) {
      this.premiumcalform.get("age").setValue(moment().diff(m, 'years', false));
    }
  }

  getPremium(): void
  {
    if (this.premiumcalform.valid) {
      this.premiumSubscription = this.premiumCalculatorService.getMonthlyPremium(this.premiumcalform.value)
        .subscribe((premiumammount) =>
        {
          this.monthlyPremium = premiumammount as number;
          this.showPremium = true;
        });
    }
  }

  onSubmit(): void
  {
    this.getPremium();
  }

  ngOnDestroy(): void
  {
    if (!this.occupationsubscription.closed) {
      this.occupationsubscription.unsubscribe();
    }

    if (!this.premiumSubscription.closed) {
      this.premiumSubscription.unsubscribe();
    }
  }

}
