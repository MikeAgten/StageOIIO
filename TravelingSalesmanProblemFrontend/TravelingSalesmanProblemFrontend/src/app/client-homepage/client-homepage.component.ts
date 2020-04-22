import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ContactService } from '../services/contact.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { AppointmentService } from '../services/appointment.service';
import { Appointment } from '../models/appointment.model';

@Component({
  selector: 'app-client-homepage',
  templateUrl: './client-homepage.component.html',
  styleUrls: ['./client-homepage.component.css']
})
export class ClientHomepageComponent implements OnInit {

  constructor(private contactService: ContactService,private appointmentService: AppointmentService, private route: ActivatedRoute) { }
  private routeSub: Subscription;
  appointments: Appointment[];
  contact: Contact;
  contactId: number;
  ngOnInit(){
    this.routeSub = this.route.params.subscribe(params => {
      var idParameter = params['id'];
      this.contactId = Number(idParameter);
    });
    this.fetchContactById();
    this.fetchAppointments();
    console.log("current contact = " + this.contact);
  }


  fetchContactById() {
    this.contactService.getContactById(this.contactId).subscribe(data => { this.contact = data; });
  }

  async fetchAppointments(){
   await this.appointmentService.getAppointmentsByClientId(this.contactId).subscribe(data => { this.appointments = data; });
  }

}
