import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Review } from 'src/app/models/review.model'; // Assuming you have a Review model
import { ResortService } from 'src/app/services/resort.service';

@Component({
  selector: 'app-admin-view-review',
  templateUrl: './admin-view-review.component.html',
  styleUrls: ['./admin-view-review.component.css']
})
export class AdminViewReviewComponent implements OnInit {
  showDeletePopup = false;
  selectedReview: Review;
  isEditing = false;
  reviews: Review[] = [];

  constructor(private router: Router, private resortService: ResortService) { }

  ngOnInit(): void {
    this.getAllReviews();
  }

  getAllReviews() {
    this.resortService.getAllReviews().subscribe(
      (data: Review[]) => {
        this.reviews = data;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
