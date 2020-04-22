import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Appointment } from '../models/appointment.model';
import { AppointmentPost } from '../models/appointmentPost.model';

@Injectable({providedIn: 'root'})
export class AppointmentService {
    private apiurl: string = 'https://localhost:5001/';
    constructor(private http: HttpClient) { }


    getAppointments(): Observable<Appointment[]>{
      return this.http.get<Appointment[]>(this.apiurl + 'api/appointments').pipe(
        map(this.parseAppointments));
    }


    getAppointmentsByClientId(clientId: number): Observable<Appointment[]>{
      return this.http.get<Appointment[]>(this.apiurl + 'api/appointments').pipe(
        map(this.parseAppointments),
        map((appointments: Appointment[]) => {
          return clientId !== null ? this.filterByClientIdAppointments(appointments, clientId) : appointments;
        })

      );
    }

    getAppointmentById(id: number): Observable<Appointment>{
      return this.http.get<Appointment>(this.apiurl + 'api/appointments/' + id);
    }



    PostAppointment(toAddAppointment: Appointment): Observable<Appointment>{
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type':  'application/json'
        })
      };
      let stringToAddAppointment = JSON.stringify(toAddAppointment);
      console.log("Adding appointment =" + stringToAddAppointment);
      return this.http.post<Appointment>(this.apiurl + 'api/appointments', toAddAppointment, httpOptions);
    }
    /*
    getGiftsFirst(): Observable<Object[]>{
      return this.http.get<Object[]>('api/gifts/1');
    }

    PostGifts(toAddGift: Appointment): void{
      this.http.post('api/gifts', toAddGift);
    }

    putGifts(toUpdateGift: Appointment): void{
      this.http.put('api/gifts', toUpdateGift);
    }

    deleteGiftsFirst(id: number): Observable<any> {
      console.log( this.http.delete('/api/gifts/' + id));
      return this.http.delete('/api/gifts/' + id);
    }

    getCategories(): Observable<Appointment[]>{
      return this.http.get<Appointment[]>('api/categories').pipe(
        map(this.parseCategories)
      );
    }*/

    parseAppointments(rawAppointments: any[]): Appointment[] {
      return Object.keys(rawAppointments).map(key => {
        let appointment = rawAppointments[key];
        return new Appointment(
          appointment.id,
          appointment.title,
          appointment.description,
          appointment.latitude,
          appointment.longitude,
          appointment.start,
          appointment.end,
          appointment.clientId,
          appointment.tenantId,
          );
      });
  }

  filterByClientIdAppointments(appointments: Appointment[], clientId: number): Appointment[] {
    console.log(appointments);
    return appointments.filter(appointment => appointment.clientId === clientId);
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
