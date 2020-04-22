import { Component, OnInit, Input } from '@angular/core';
import { Contact } from '../models/contact.model';

@Component({
  selector: 'app-top-layout',
  templateUrl: './top-layout.component.html',
  styleUrls: ['./top-layout.component.css']
})
export class TopLayoutComponent implements OnInit {

  constructor() { }
  @Input() contact: Contact;

  ngOnInit(): void {
  }

}
