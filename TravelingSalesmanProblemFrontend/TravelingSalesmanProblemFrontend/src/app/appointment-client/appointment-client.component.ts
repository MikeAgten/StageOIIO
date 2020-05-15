import { Component, OnInit, Input } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ContactService } from '../services/contact.service';
import { AppointmentDto } from '../models/appointmentDto.model';

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
  appointmentDto: AppointmentDto;

  ngOnInit(): void {
    this.dateString = this.appointmentDto.appointment.date.toString().substr(0, 10);
    this.startHour = this.appointmentDto.appointment.start.toString().substr(11, 5);
    this.endHour = this.appointmentDto.appointment.end.toString().substr(11, 5);
    this.fetchClientById(this.appointmentDto.appointment.clientId);
    this.fetchTenantById(this.appointmentDto.appointment.tenantId);
    if (this.startHour === '00:00'){
      this.startHour = '...';
      this.endHour = '...';
    }
  }

  fetchClientById(id: number) {
    this.contactService.getContactById(id).subscribe(data => {
      this.client = data; });
  }
  fetchTenantById(id: number) {
    this.contactService.getContactById(id).subscribe(data => {
      this.tenant = data; });
  }
}
