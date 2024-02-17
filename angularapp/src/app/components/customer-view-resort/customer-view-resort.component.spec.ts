import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerViewResortComponent } from './customer-view-resort.component';

describe('CustomerViewResortComponent', () => {
  let component: CustomerViewResortComponent;
  let fixture: ComponentFixture<CustomerViewResortComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerViewResortComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerViewResortComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
