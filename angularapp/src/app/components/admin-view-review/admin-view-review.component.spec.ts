import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewReviewComponent } from './admin-view-review.component';

describe('AdminViewReviewComponent', () => {
  let component: AdminViewReviewComponent;
  let fixture: ComponentFixture<AdminViewReviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewReviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewReviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
