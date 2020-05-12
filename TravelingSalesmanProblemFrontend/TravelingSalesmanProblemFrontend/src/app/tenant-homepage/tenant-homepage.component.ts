import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { AppointmentService } from '../services/appointment.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Appointment } from '../models/appointment.model';
import { Contact } from '../models/contact.model';
import { CalculateInfo } from '../models/calculateInfo.model';
import { AppointmentDto } from '../models/appointmentDto.model';

@Component({
  selector: 'app-tenant-homepage',
  templateUrl: './tenant-homepage.component.html',
  styleUrls: ['./tenant-homepage.component.css']
})
export class TenantHomepageComponent implements OnInit {

    constructor(private contactService: ContactService, private appointmentService: AppointmentService, private route: ActivatedRoute) { }
    private routeSub: Subscription;
    appointmentDtos: AppointmentDto[];
    distinctDates: String[];
    sortingDate: string;
    contact: Contact;
    tenantId: number;
    toCalculateInfo: CalculateInfo;
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
     await this.appointmentService.getAppointmentDtosByTenantId(this.tenantId).subscribe(data => { this.appointmentDtos = data;
      this.distinctDates = this.appointmentService.filterByDistinctDateAppointmentDtos(this.appointmentDtos); });
    }

    async changeSortingDate(date: string){
      console.log("changed to " + date);
      this.sortingDate = date;
      if(!date.includes("-")){
        this.fetchAppointments();
      } else{
        await this.appointmentService.getAppointmentDtosByDate(date).subscribe(data => { this.appointmentDtos = data; });
      }
    }

    calculateDay(event: Event){
      this.toCalculateInfo = new CalculateInfo(this.sortingDate, this.tenantId);
      this.appointmentService.CalculateRoute(this.toCalculateInfo).subscribe(
        data => console.log("succes!", data),
        error => console.error("Error!", error));
      console.log("calculating route for day " + this.sortingDate);
    }

  }
