import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ContactService } from '../services/contact.service';
import { appRoutes } from '../app.routes';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  contacts: Contact[];
  currentContactId: number;
  contactType: number;
  title = 'TravelingSalesmanProblemFrontend';

  constructor(private contactService: ContactService) { }

  ngOnInit() {
    this.contactType = 0;
    this.fetchContacts();
  }

  fetchContacts() {
    this.contactService.getContactsByContactType(this.contactType).subscribe(data => { this.contacts = data; });
  }

  changeContactType(event: Event){
    if(this.contactType === 1){
      this.contactType = 0;
    } else{
    this.contactType = 1;
    }
    this.fetchContacts();
  }

  changeCurrentContact(id: number){
    this.currentContactId = id;
  }

  loginHandle(event: Event){
    console.log("current contact" + this.currentContactId);
  }

}
