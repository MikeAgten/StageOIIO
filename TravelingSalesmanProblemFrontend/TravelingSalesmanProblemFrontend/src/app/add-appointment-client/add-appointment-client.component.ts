import { Component, OnInit } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact.model';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { Appointment } from '../models/appointment.model';
import { AppointmentService } from '../services/appointment.service';
import { Address } from '../models/address.model';


@Component({
  selector: 'app-add-appointment-client',
  templateUrl: './add-appointment-client.component.html',
  styleUrls: ['./add-appointment-client.component.css']
})
export class AddAppointmentClientComponent implements OnInit {
  private routeSub: Subscription;
  addresses: Address[];
  contacts: Contact[];
  contact: Contact;
  contactId: number;
  date: Date;
  dateString: string;
  currentContactId: number;
  currentContactType: number;
  toAddAppointment: Appointment;
  currentAddress: Address;

  constructor(private contactService: ContactService, private appointmentService: AppointmentService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe(params => {
      var idParameter = params['id'];
      this.contactId = Number(idParameter);
    });
    this.fillAddresses();
    this.fetchContactById();
    console.log(this.currentContactType);
    this.fetchContactsByContactType(this.currentContactType);
    this.toAddAppointment = new Appointment(null, null, null, null, null, null, null, null, null, null, null);
    this.toAddAppointment.clientId = this.contactId;
    this.date = new Date();
  }

  fetchContactById() {
    this.contactService.getContactById(this.contactId).subscribe(data => { this.contact = data;
      this.currentContactType = data.contactType;});
  }
  fetchContactsByContactType(contactType: number) {
    this.contactService.getContactsByContactType(contactType).subscribe(data => {
       this.contacts = data; this.currentContactId = this.contacts[0].id; });
  }

  changeCurrentContact(id: number){
    console.log(id);
    this.currentContactId = id;
  }

  changeCurrentAddress(address: Address){
    //this.currentAddress = address;
    console.log("changed to" + address.latitude);
  }

  submit(appointmentform): void {
    console.log("current address : " + this.currentAddress.number);
    this.dateString = this.date.toISOString().slice(0,19);
    let appointment = new Appointment(
      null,
      this.toAddAppointment.title,
      this.toAddAppointment.description,
      this.currentAddress.latitude,
      this.currentAddress.longitude,
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

  fillAddresses() {
    this.addresses = [{latitude: 50.976131, longitude:5.8186005, street:"Mijnweg", number:3, postal:"6167 AC", city: "Geleen", country:"Nederland"},
    {latitude: 51.2294444, longitude:5.3105231, street:"Kerkstraat", number:51, postal:"3920", city: "Lommel", country:"België"},
    {latitude: 51.1427211, longitude:5.3583471, street:"De Vreedestraat", number:3, postal:"3940", city: "Eksel", country:"België"},
    {latitude: 51.0026234, longitude:5.4996789, street:"Hoevezavellaan", number:20, postal:"3600", city: "Genk", country:"België"},
    {latitude: 50.9371883, longitude:5.3464778, street:"Elfde-Liniestraat", number:25, postal:"3500", city: "Hasselt", country:"België"},
    {latitude: 51.2104694, longitude:5.4199029, street:"Dorpsstraat", number:91, postal:"3900", city: "Pelt", country:"België"},
    {latitude: 50.8579426, longitude:5.709894, street:"Generaal Marshalllaan", number:3, postal:"6224 XG", city: "Maastricht", country:"Nederland"},
    {latitude: 51.1150045, longitude:5.2725964, street:"Zegeplaats", number:18, postal:"3970", city: "Leopoldsburg", country:"België"},
    {latitude: 50.973324, longitude:5.4931739, street:"Nieuwe kuilenweg", number:80, postal:"3600", city: "Genk", country:"België"},
    {latitude: 51.1919203, longitude:5.1196979, street:"Leenhofstraat", number:15, postal:"2400", city: "Mol", country:"België"},
  ]
  }
}
