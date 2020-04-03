import { Component, OnInit } from '@angular/core';
import { Contact } from '../models/contact.model';
import { ContactService } from '../services/contact.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-client-homepage',
  templateUrl: './client-homepage.component.html',
  styleUrls: ['./client-homepage.component.css']
})
export class ClientHomepageComponent implements OnInit {

  constructor(private contactService: ContactService, private route: ActivatedRoute) { }
  private routeSub: Subscription;
  contact: Contact;
  contactId: number;
  ngOnInit(){
    this.routeSub = this.route.params.subscribe(params => {
      this.contactId = params['id'];
    });
    this.fetchContactById(this.contactId);
  }


  fetchContactById(id: number) {
    this.contactService.getContactById(id).subscribe(data => { this.contact = data; });
    console.log("current contact" + this.contact);
  }

}
