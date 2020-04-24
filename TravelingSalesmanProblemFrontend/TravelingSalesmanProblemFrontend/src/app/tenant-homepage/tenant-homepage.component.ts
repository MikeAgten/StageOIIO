import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { AppointmentService } from '../services/appointment.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Appointment } from '../models/appointment.model';
import { Contact } from '../models/contact.model';

@Component({
  selector: 'app-tenant-homepage',
  templateUrl: './tenant-homepage.component.html',
  styleUrls: ['./tenant-homepage.component.css']
})
export class TenantHomepageComponent implements OnInit {

    constructor(private contactService: ContactService, private appointmentService: AppointmentService, private route: ActivatedRoute) { }
    private routeSub: Subscription;
    appointments: Appointment[];
    distinctDates: String[];
    contact: Contact;
    tenantId: number;
    ngOnInit(){
      this.routeSub = this.route.params.subscribe(params => {
        var idParameter = params['id'];
        this.tenantId = Number(idParameter);
      });
      this.fetchContactById();
      this.fetchAppointments();
      this.fetchDatesDistinct();
      console.log("current contact = " + this.contact);
    }

    fetchDatesDistinct() {
    }

    fetchContactById() {
      this.contactService.getContactById(this.tenantId).subscribe(data => { this.contact = data; });
    }

    async fetchAppointments(){
     await this.appointmentService.getAppointmentsByTenantId(this.tenantId).subscribe(data => { this.appointments = data;
      console.log("getting dates" + this.appointments);
      this.distinctDates = this.appointmentService.filterByDistinctDateAppointments(this.appointments);
      console.log("HELLO");});
    }

  }
