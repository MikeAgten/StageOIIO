import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ContactService } from '../services/contact.service';
import { appRoutes } from '../app.routes';
import { ActivatedRoute, Router } from '@angular/router';

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

  constructor(private contactService: ContactService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.currentContactId = 1;
    this.contactType = 0;
    this.fetchContacts();
  }

  fetchContacts() {
    this.contactService.getContactsByContactType(this.contactType).subscribe(data => {
      this.contacts = data; this.currentContactId = this.contacts[0].id; });
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
    console.log("changed to" + this.currentContactId);
  }

  changeCurrentContactByType(){
    console.log("changed to" + this.currentContactId);
  }

  loginHandle(event: Event){
    console.log("current contact" + this.currentContactId);
    if(this.contactType == 0){
      this.router.navigate(['/tenant/', this.currentContactId]);
    }
    if(this.contactType == 1){
      this.router.navigate(['/contact/', this.currentContactId]);
    }
  }

}
