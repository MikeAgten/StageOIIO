export class Appointment {
  id: number;
  title: string;
  description: string;
  latitude: number;
  longitude: number;
  duration: number;
  date: string;
  start: string;
  end: string;
  clientId: number;
  tenantId: number;

  constructor(id: number, title: string, description: string, latitude: number, longitude: number, duration: number, date: string,
              start: string, end: string, clientId: number, tenantId: number){
    this.id = id;
    this.title = title;
    this.description = description;
    this.latitude = latitude;
    this.longitude = longitude;
    this.duration = duration;
    this.date = date;
    this.start = start || '00:00';
    this.end = end || '00:00';
    this.clientId = clientId;
    this.tenantId = tenantId;
  }

}
