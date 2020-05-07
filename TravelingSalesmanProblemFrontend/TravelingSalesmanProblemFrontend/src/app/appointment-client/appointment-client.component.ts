import { Component, OnInit, Input } from '@angular/core';
import { Contact } from '../models/contact.model';
import { Appointment } from '../models/appointment.model';
import { AppointmentService } from '../services/appointment.service';
import { ContactService } from '../services/contact.service';

@Component({
  selector: 'app-appointment-client',
  templateUrl: './appointment-client.component.html',
  styleUrls: ['./appointment-client.component.css']
})
export class AppointmentClientComponent implements OnInit {
  dateString: string;
  startHour: string;
  endHour: string;
  tenant: Contact;
  client: Contact;


  constructor(private contactService: ContactService) { }

  @Input()
  appointment: Appointment;

  ngOnInit(): void {
    this.dateString = this.appointment.date.toString().substr(0,10);
    this.startHour = this.appointment.start.toString().substr(11,5);
    this.endHour = this.appointment.end.toString().substr(11,5);
    this.fetchClientById(this.appointment.clientId);
    this.fetchTenantById(this.appointment.tenantId);
    if(this.startHour === "00:00"){
      this.startHour = "...";
      this.endHour = "...";
    }
  }

  fetchClientById(id: number) {
    this.contactService.getContactById(id).subscribe(data => {
      this.client = data;});
  }
  fetchTenantById(id: number) {
    this.contactService.getContactById(id).subscribe(data => {
      this.tenant = data;});
  }
}
