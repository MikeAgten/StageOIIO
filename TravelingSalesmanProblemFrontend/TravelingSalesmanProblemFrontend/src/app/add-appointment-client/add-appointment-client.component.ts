import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact.model';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Appointment } from '../models/appointment.model';
import { AppointmentService } from '../services/appointment.service';


@Component({
  selector: 'app-add-appointment-client',
  templateUrl: './add-appointment-client.component.html',
  styleUrls: ['./add-appointment-client.component.css']
})
export class AddAppointmentClientComponent implements OnInit {
  private routeSub: Subscription;
  contacts: Contact[];
  contact: Contact;
  contactId: number;
  date: Date;
  dateString: string;
  currentContactId: number;
  toAddAppointment: Appointment;

  constructor(private contactService: ContactService, private appointmentService: AppointmentService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      var idParameter = params['id'];
      this.contactId = Number(idParameter);
    });
    this.fetchContactById();
    this.fetchContactsByContactType(0);
    this.toAddAppointment = new Appointment(null, null, null, null, null, null, null, null, null, null, null);
    this.toAddAppointment.clientId = this.contactId;
    this.date = new Date();
  }

  fetchContactById() {
    this.contactService.getContactById(this.contactId).subscribe(data => { this.contact = data; });
  }
  fetchContactsByContactType(contactType: number) {
    this.contactService.getContactsByContactType(contactType).subscribe(data => {
       this.contacts = data; this.currentContactId = this.contacts[0].id; });
  }

  changeCurrentContact(id: number){
    console.log(id);
    this.currentContactId = id;
  }

  submit(appointmentform): void {
    this.dateString = this.date.toISOString().slice(0,19);
    let appointment = new Appointment(
      null,
      this.toAddAppointment.title,
      this.toAddAppointment.description,
      this.toAddAppointment.latitude,
      this.toAddAppointment.longitude,
      Number(this.toAddAppointment.duration),
      this.toAddAppointment.date,
      '0001-01-01T00:00:00',
      '0001-01-01T00:00:00',
      this.contactId,
      Number(this.toAddAppointment.tenantId)
    );
    this.appointmentService.PostAppointment(appointment).subscribe(
      data => console.log("succes!", data),
      error => console.error("Error!", error));
    appointmentform.reset();
  }
}
