export class Address {
  latitude: number;
  longitude: number;
  street: string;
  number: number;
  postal: string;
  city: string;
  country: string;

  constructor(  latitude: number, longitude: number, street: string, number: number, postal: string, city: string, country: string){
    this.latitude = latitude;
    this.longitude = longitude;
    this.street = street;
    this.number = number;
    this.postal = postal;
    this.city = city;
    this.country = country;
  }

}
