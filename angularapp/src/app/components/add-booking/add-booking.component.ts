import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookingService } from 'src/app/services/booking.service';
import { Booking } from 'src/app/models/booking.model';
import { ResortService } from 'src/app/services/resort.service';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.css'],
})
export class AddBookingComponent implements OnInit {
  resorts: any = [];
  addBookingForm: FormGroup;
  errorMessage = '';
  showSuccessPopup: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private resortService: ResortService,
    private bookingService: BookingService,
    private router: Router
  ) {
    this.addBookingForm = this.fb.group({
      resortId: ['', Validators.required],
      resortName: [''],
      address: ['', Validators.required],
      noOfPersons: ['', Validators.required],
      fromDate: ['', Validators.required],
      toDate: ['', Validators.required],
      totalPrice: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.getAllResorts();
  }

  getAllResorts() {
    this.resortService.getAllResorts().subscribe((response: any) => {
      console.log(response);
      this.resorts = response;
      // this.addBookingForm.patchValue({
      //   totalPrice: response.price,
      //   resortName: response.resortName
      // });
    });
  }

  onSubmit(): void {
    if (this.addBookingForm.valid) {
      const newBooking = this.addBookingForm.value;
      const requestObj: Booking = {
        userId: Number(localStorage.getItem('userId')),
        resortId: Number(newBooking.resortId),
        resort: {
          resortName: newBooking.resortName,
          resortImageUrl: '',
          resortLocation: '',
          resortAvailableStatus: '',
          price: 0,
          capacity: 0,
          description: '',
        },
        address: newBooking.address,
        noOfPersons: newBooking.noOfPersons,
        fromDate: newBooking.fromDate,
        toDate: newBooking.toDate,
        totalPrice: newBooking.totalPrice,
        status: 'PENDING',
      };
console.log(requestObj)
      this.bookingService.addBooking(requestObj).subscribe(
        (response) => {
          console.log('Booking added successfully', response);
          this.showSuccessPopup = true;
          // this.router.navigate(['/customer/dashboard']);
          this.addBookingForm.reset(); // Reset the form
        },
        (error) => {
          console.error('Error adding booking', error);
        }
      );
    } else {
      this.errorMessage = 'All fields are required';
    }
  }

  updatePrice(): void {
    const selectedResortId = this.addBookingForm.get('resortId').value;
    const selectedResort = this.resorts.find(resort => resort.resortId === Number(selectedResortId));
    if (selectedResort) {
      this.addBookingForm.patchValue({
        totalPrice: selectedResort.price,
        resortName: selectedResort.resortName
      });
    }
    console.log(selectedResort)
  }

  navigateToDashboard() {
    this.router.navigate(['/']);
}
}
