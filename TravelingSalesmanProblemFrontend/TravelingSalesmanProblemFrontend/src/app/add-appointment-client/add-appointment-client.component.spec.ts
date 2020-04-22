import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAppointmentClientComponent } from './add-appointment-client.component';

describe('AddAppointmentClientComponent', () => {
  let component: AddAppointmentClientComponent;
  let fixture: ComponentFixture<AddAppointmentClientComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddAppointmentClientComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAppointmentClientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
