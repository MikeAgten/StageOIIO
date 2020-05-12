import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Contact} from '../models/contact.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({providedIn: 'root'})
export class ContactService {
    private apiurl: string = 'https://localhost:5001/';
    private localUrl: string = '../assets/data/contacts.json';
    constructor(private http: HttpClient) { }


    getContacts(): Observable<Contact[]>{
      return this.http.get<Contact[]>(this.apiurl + 'api/contacts').pipe(
        map(this.parseContacts));
    }

    getContactsByContactType(contactType: number): Observable<Contact[]>{
      return this.http.get<Contact[]>(this.apiurl + 'api/contacts').pipe(
        map(this.parseContacts),
        map((contacts: Contact[]) => {
          return contactType !== null ? this.filterByContactTypeContacts(contacts, contactType) : contacts;
        })

      );
    }

    getContactById(id: number): Observable<Contact>{
      return this.http.get<Contact>(this.apiurl + 'api/contacts/' +id);
    }

    PostContact(toAddContact: Contact): Observable<Contact>{
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json'
        })
      };
      let stringToAddContact = JSON.stringify(toAddContact);
      console.log("Adding Contact =" + stringToAddContact);
      return this.http.post<Contact>(this.apiurl + 'api/contacts', toAddContact, httpOptions);
    }
    /*
    getGiftsFirst(): Observable<Object[]>{
      return this.http.get<Object[]>('api/gifts/1');
    }

    PostGifts(toAddGift: Contact): void{
      this.http.post('api/gifts', toAddGift);
    }

    putGifts(toUpdateGift: Contact): void{
      this.http.put('api/gifts', toUpdateGift);
    }

    deleteGiftsFirst(id: number): Observable<any> {
      console.log( this.http.delete('/api/gifts/' + id));
      return this.http.delete('/api/gifts/' + id);
    }

    getCategories(): Observable<Contact[]>{
      return this.http.get<Contact[]>('api/categories').pipe(
        map(this.parseCategories)
      );
    }*/

    parseContacts(rawContacts: any[]): Contact[] {
      return Object.keys(rawContacts).map(key => {
        let contact = rawContacts[key];
        return new Contact(
          contact.id,
          contact.type,
          contact.firstName,
          contact.surname,
          contact.emailAddress
          );
      });
  }

  filterByContactTypeContacts(contacts: Contact[], type: number): Contact[] {
    console.log(contacts);
    return contacts.filter(contact => contact.type === type);
  }
}



/*
 GET /api/gifts                  // alle gift objecten
 GET /api/gifts?description=j    // gifts waarbij description 'j' bevat
 GET /api/gifts/1                // gift met als id=1
 POST /api/gifts                 // gift object toevoegen
 PUT /api/gifts                  // gift object updaten
 DELETE /api/gifts/1             // delete gift met als id=1
 GET /api/categories             // alle category objecten
 */
