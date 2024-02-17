import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminViewResortComponent } from './admin-view-resort.component';

describe('AdminViewResortComponent', () => {
  let component: AdminViewResortComponent;
  let fixture: ComponentFixture<AdminViewResortComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminViewResortComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminViewResortComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
