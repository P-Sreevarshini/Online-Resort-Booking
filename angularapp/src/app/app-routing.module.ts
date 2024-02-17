import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './components/authguard/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ErrorComponent } from './components/error/error.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AdminViewBookingComponent } from './components/admin-view-booking/admin-view-booking.component';
import { CustomerViewBookingComponent } from './components/customer-view-booking/customer-view-booking.component';
import { AddBookingComponent } from './components/add-booking/add-booking.component';
import { AddResortComponent } from './components/add-resort/add-resort.component';
import { AdminViewResortComponent } from './components/admin-view-resort/admin-view-resort.component';
import { CustomerViewResortComponent } from './components/customer-view-resort/customer-view-resort.component';
import { AddReviewComponent } from './components/add-review/add-review.component';
import { AdminViewReviewComponent } from './components/admin-view-review/admin-view-review.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: RegistrationComponent },
  { path: 'admin/add/resort', component: AddResortComponent, canActivate: [AuthGuard]},
  { path: 'admin/view/resort', component: AdminViewResortComponent, canActivate: [AuthGuard]},
  { path: 'admin/view/review', component: AdminViewReviewComponent, canActivate: [AuthGuard]},
  { path: 'admin/view/bookings', component: AdminViewBookingComponent, canActivate: [AuthGuard]},
  { path: 'customer/view/resort', component: CustomerViewResortComponent, canActivate: [AuthGuard]},
  { path: 'customer/add/booking', component: AddBookingComponent, canActivate: [AuthGuard]},
  { path: 'customer/view/bookings', component: CustomerViewBookingComponent, canActivate: [AuthGuard]},
    { path: 'customer/add/review', component: AddReviewComponent, canActivate: [AuthGuard]},
  { path: 'error', component: ErrorComponent, data: { message: 'Oops! Something went wrong.' }},
  { path: '**', redirectTo: '/error', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
