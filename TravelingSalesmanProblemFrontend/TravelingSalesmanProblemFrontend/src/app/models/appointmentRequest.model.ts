export class AppointmentRequest {
  id: number;
  title: string;
  description: string;
  latitude: number;
  longitude: number;
  duration: number;
  date: string;
  clientId: number;
  tenantId: number;

  constructor(id: number, title: string, description: string, latitude: number, longitude: number, duration: number, date: string,
               clientId: number, tenantId: number){
    this.id = id;
    this.title = title;
    this.description = description;
    this.latitude = latitude;
    this.longitude = longitude;
    this.duration = duration;
    this.date = date;
    this.clientId = clientId;
    this.tenantId = tenantId;
  }

}
