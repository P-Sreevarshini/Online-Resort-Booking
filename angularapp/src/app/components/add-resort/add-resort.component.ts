import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ResortService } from 'src/app/services/resort.service';
import { Resort } from 'src/app/models/resort.model';

@Component({
  selector: 'app-add-resort',
  templateUrl: './add-resort.component.html',
  styleUrls: ['./add-resort.component.css']
})
export class AddResortComponent implements OnInit {

  addResortForm: FormGroup;
  errorMessage = '';

  constructor(private fb: FormBuilder, private resortService: ResortService, private route: Router) {
    this.addResortForm = this.fb.group({
      resortName: ['', Validators.required],
      resortImageUrl: ['', Validators.required],
      resortLocation: ['', Validators.required],
      description: ['', Validators.required],
      resortAvailableStatus: ['', Validators.required],
      price: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      capacity: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
    });
  }

  ngOnInit(): void {
  }

  onSubmit(): void {
    if (this.addResortForm.valid) {
      const newResort = this.addResortForm.value;
      const requestObj: Resort = {
        // userId: localStorage.getItem('userId'),
        resortName: newResort.resortName,
        resortImageUrl: newResort.resortImageUrl,
        resortLocation: newResort.resortLocation,
        description: newResort.description,
        resortAvailableStatus: newResort.resortAvailableStatus,
        price: newResort.price,
        capacity: newResort.capacity,
      };
      console.log("requestObj",requestObj);

      this.resortService.addResort(requestObj).subscribe(
        (response) => {
          console.log('Resort added successfully', response);
          this.route.navigate(['/admin/dashboard']);
          this.addResortForm.reset(); // Reset the form
        },
        (error) => {
          console.error('Error adding resort', error);
        }
      );
    } else {
      this.errorMessage = "All fields are required";
    }
  }

}
