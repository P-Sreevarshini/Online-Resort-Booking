import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewBookingComponent } from './admin-view-booking.component';

describe('AdminViewBookingComponent', () => {
  let component: AdminViewBookingComponent;
  let fixture: ComponentFixture<AdminViewBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewBookingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
