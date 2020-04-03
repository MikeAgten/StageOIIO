export class Contact {
  id: number;
  contactType: number;
  firstName: string;
  surname: string;
  emailAddress: string;
  createdDateUtc: string;

  constructor(  id: number, contactType: number, firstName: string, surname: string, emailAddress: string, createdDateUtc: string){
    this.id = id;
    this.contactType = contactType;
    this.firstName = firstName;
    this.surname = surname;
    this.emailAddress = emailAddress;
    this.createdDateUtc = createdDateUtc;
  }
}
