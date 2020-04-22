export class Appointment {
  id: number;
  title: string;
  description: string;
  latitude: number;
  longitude: number;
  start: Date;
  end: Date;
  clientId: number;
  tenantId: number;

  constructor(id: number, title: string, description: string, latitude: number, longitude: number,
              start: Date, end: Date, clientId: number, tenantId: number){
    this.id = id;
    this.title = title;
    this.description = description;
    this.latitude = latitude;
    this.longitude = longitude;
    this.start = start;
    this.end = end;
    this.clientId = clientId;
    this.tenantId = tenantId;
  }

}
