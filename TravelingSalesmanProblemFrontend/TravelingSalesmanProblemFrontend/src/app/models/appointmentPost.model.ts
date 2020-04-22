export class AppointmentPost {
  id: number;
  title: string;
  description: string;
  latitude: number;
  longitude: number;
  start: Date;
  end: Date;
  clientId: number;
  tenantId: number;

  constructor(title: string, description: string, latitude: number, longitude: number,
              start: Date, end: Date, clientId: number, tenantId: number){
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
