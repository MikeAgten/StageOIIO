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
  currentContactId: number;
  toAddAppointment: Appointment;

  constructor(private contactService: ContactService, private appointmentService: AppointmentService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      var idParameter = params['id'];
      this.contactId = Number(idParameter);
    });
    this.fetchContactById();
    this.fetchContactsByContactType(0);
    this.toAddAppointment.clientId = this.contactId;
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

  submit(form): void {
    let contact = new Contact(
      null, 1, "Hubert", "Hermans", "mikea@gmail.com"
    );
    this.contactService.PostContact(contact).subscribe(
      data => console.log("succes!", data),
      error => console.error("Error!", error));
    let appointment = new Appointment(
      null, "posttest", "posttest", 55.9761276, 15.8207892, null, null, 10, 2
    );
    form.reset();
    console.log(appointment);
    this.appointmentService.PostAppointment(appointment).subscribe(
      data => console.log("succes!", data),
      error => console.error("Error!", error));
  }
}
