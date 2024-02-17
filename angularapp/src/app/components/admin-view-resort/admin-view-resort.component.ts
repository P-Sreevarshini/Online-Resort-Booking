import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Resort } from 'src/app/models/resort.model';
import { ResortService } from 'src/app/services/resort.service';

@Component({
  selector: 'app-admin-view-resort',
  templateUrl: './admin-view-resort.component.html',
  styleUrls: ['./admin-view-resort.component.css']
})
export class AdminViewResortComponent implements OnInit {
  showDeletePopup = false;
  selectedResort: Resort ;
  selectedItem: any = {};
  isEditing = false;
  resorts: any[] = [];

  constructor(private router: Router, private resortService: ResortService) { }

  ngOnInit(): void {
    this.getAllResorts();
  }

  getAllResorts() {
    this.resortService.getAllResorts().subscribe(
      (data: any) => {
        this.resorts = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  deleteResort(resortDetails: any) {
    this.resortService.deleteResort(resortDetails.resortId).subscribe(
      (data: any) => {
        console.log('Resort deleted successfully', data);
        this.getAllResorts();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  editResort(resort: Resort) {
    console.log('Edit Resort - Selected Resort Before:', this.selectedResort);
    console.log('Edit Resort - Resort to Edit:', resort);
    
    // Set the selected resort and enter edit mode
    this.selectedResort = resort ; // Create a copy to avoid direct modification
    this.isEditing = true;

    console.log('Edit Resort - Selected Resort After:', this.selectedResort);
}

  updateResort(resortDetails: any) {
    // Implement your update logic here, using the resortService.put() method
    this.resortService.updateResort(resortDetails).subscribe(
      (data: any) => {
        console.log('Resort updated successfully', data);
        this.getAllResorts();
        this.cancelEdit(); // Exit edit mode after successful update
      },
      (err) => {
        console.log(err);
      }
    );
  }

  cancelEdit() {
    this.isEditing = false;
    this.selectedResort = null;
  }
}
