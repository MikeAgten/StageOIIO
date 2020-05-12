export class Contact {
  id: number;
  type: number;
  firstName: string;
  surname: string;
  emailAddress: string;

  constructor(  id: number, type: number, firstName: string, surname: string, emailAddress: string){
    this.id = id;
    this.type = type;
    this.firstName = firstName;
    this.surname = surname;
    this.emailAddress = emailAddress;

  }
}
