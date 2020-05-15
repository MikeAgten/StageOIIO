export class Contact {
  id: number;
  type: number;
  firstName: string;
  surname: string;

  constructor(  id: number, type: number, firstName: string, surname: string){
    this.id = id;
    this.type = type;
    this.firstName = firstName;
    this.surname = surname;
  }
}
