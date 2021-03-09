import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MonthlyPremiumCalculatorComponent } from './premium-calculator/monthly-calculator/monthlycalculator.component';
import { HttpClientModule } from '@angular/common/http';
import { OccupationsService } from './service/occupations.service';
import { PremiumCalculatorService } from './service/premium-calculator.service';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { CurrencyPipe } from '@angular/common'

@NgModule({
  declarations: [
    AppComponent,
    MonthlyPremiumCalculatorComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    OccupationsService,
    PremiumCalculatorService,
    { provide: MAT_DATE_LOCALE, useValue: 'en-AU' },
    CurrencyPipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
