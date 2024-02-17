import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ResortService } from 'src/app/services/resort.service';

@Component({
  selector: 'app-customer-view-resort',
  templateUrl: './customer-view-resort.component.html',
  styleUrls: ['./customer-view-resort.component.css']
})
export class CustomerViewResortComponent implements OnInit {
  resorts: any = [];

  constructor(private resortService: ResortService, private router: Router) { }

  ngOnInit(): void {
    this.getAllResorts();
  }

  getAllResorts() {
    this.resortService.getAllResorts().subscribe((response: any) => {
      console.log(response);
      this.resorts = response;
    });
  }

  navigateToAddBooking() {
    this.router.navigate(['/customer/add/booking']);
  }
}
