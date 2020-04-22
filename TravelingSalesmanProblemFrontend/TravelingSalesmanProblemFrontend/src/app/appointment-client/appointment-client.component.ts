import { Component, OnInit, Input } from '@angular/core';
import { Contact } from '../models/contact.model';
import { Appointment } from '../models/appointment.model';
import { AppointmentService } from '../services/appointment.service';

@Component({
  selector: 'app-appointment-client',
  templateUrl: './appointment-client.component.html',
  styleUrls: ['./appointment-client.component.css']
})
export class AppointmentClientComponent implements OnInit {
  dateString: string;
  startHour: string;
  endHour: string;


  constructor() { }

  @Input()
  appointment: Appointment;

  ngOnInit(): void {
    this.dateString = this.appointment.start.toString().substr(0,10);
    this.startHour = this.appointment.start.toString().substr(11,5);
    this.endHour = this.appointment.end.toString().substr(11,5);
  }
}
