import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerViewBookingComponent } from './customer-view-booking.component';

describe('CustomerViewBookingComponent', () => {
  let component: CustomerViewBookingComponent;
  let fixture: ComponentFixture<CustomerViewBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerViewBookingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerViewBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
