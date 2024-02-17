import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { ErrorComponent } from './components/error/error.component';
import { HomeComponent } from './components/home/home.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { CustomerDashboardComponent } from './components/customer-dashboard/customer-dashboard.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AdminViewBookingComponent } from './components/admin-view-booking/admin-view-booking.component';
import { CustomerViewBookingComponent } from './components/customer-view-booking/customer-view-booking.component';
import { AddBookingComponent } from './components/add-booking/add-booking.component';
import { AddResortComponent } from './components/add-resort/add-resort.component';
import { AddReviewComponent } from './components/add-review/add-review.component';
import { AdminViewReviewComponent } from './components/admin-view-review/admin-view-review.component';
import { AdminViewResortComponent } from './components/admin-view-resort/admin-view-resort.component';
import { CustomerViewResortComponent } from './components/customer-view-resort/customer-view-resort.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    ErrorComponent,
    HomeComponent,
    AdminDashboardComponent,
    CustomerDashboardComponent,
    NavbarComponent,
    AdminViewBookingComponent,
    CustomerViewBookingComponent,
    AddBookingComponent,
    AddResortComponent,
    AddReviewComponent,
    AdminViewReviewComponent,
    AdminViewResortComponent,
    CustomerViewResortComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
