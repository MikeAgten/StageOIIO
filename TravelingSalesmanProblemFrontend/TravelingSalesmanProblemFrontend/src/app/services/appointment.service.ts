import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Appointment } from '../models/appointment.model';
import { CalculateInfo } from '../models/calculateInfo.model';
import { AppointmentDto } from '../models/appointmentDto.model';

@Injectable({providedIn: 'root'})
export class AppointmentService {

    private apiurl = 'https://localhost:5001/';
    constructor(private http: HttpClient) { }

    getAppointmentsDtoByClientId(clientId: number): Observable<AppointmentDto[]>{
      return this.http.get<AppointmentDto[]>(this.apiurl + 'api/appointments').pipe(
        map(this.parseAppointmentsDto),
        map((appointments: AppointmentDto[]) => {
          return clientId !== null ? this.filterByClientIdAppointmentsDto(appointments, clientId) : appointments;
        })

      );
    }

    getAppointmentDtosByTenantId(tenantId: number): Observable<AppointmentDto[]>{
      console.log('getting appointments for ' + tenantId);
      return this.http.get<AppointmentDto[]>(this.apiurl + 'api/appointments').pipe(
        map(this.parseAppointmentsDto),
        map((appointments: AppointmentDto[]) => {
          console.log('before map ' + appointments);
          return tenantId !== null ? this.filterByTenantIdAppointmentDtos(appointments, tenantId) : appointments;
        })
      );
    }

    getAppointmentDtosByDate(date: string): Observable<AppointmentDto[]>{
      return this.http.get<AppointmentDto[]>(this.apiurl + 'api/appointments').pipe(
        map(this.parseAppointmentsDto),
        map((appointments: AppointmentDto[]) => {
          return date !== null ? this.filterByDateppointmentDtos(appointments, date) : appointments;
        })
      );
    }

    getAppointmentById(id: number): Observable<Appointment>{
      return this.http.get<Appointment>(this.apiurl + 'api/appointments/' + id);
    }

    PostAppointment(toAddAppointment: Appointment): Observable<Appointment>{
      return this.http.post<Appointment>(this.apiurl + 'api/appointments', toAddAppointment);
    }

    CalculateRoute(toCalculateInfo: CalculateInfo): Observable<CalculateInfo>{
      return this.http.post<CalculateInfo>(this.apiurl + 'api/Appointments/calculateroute', toCalculateInfo);
    }

  parseAppointmentsDto(rawAppointmentsDto: any[]): AppointmentDto[] {
    return Object.keys(rawAppointmentsDto).map(key => {
      const appointmentDto = rawAppointmentsDto[key];
      return new AppointmentDto(
        appointmentDto.appointment,
        appointmentDto.address
        );
    });
  }

  filterByClientIdAppointmentsDto(appointments: AppointmentDto[], clientId: number): AppointmentDto[] {
    console.log(appointments);
    return appointments.filter(appointment => appointment.appointment.clientId === clientId);
  }

  filterByTenantIdAppointmentDtos(appointments: AppointmentDto[], tenantId: number): AppointmentDto[] {
    console.log(appointments);
    return appointments.filter(appointment => appointment.appointment.tenantId === tenantId);
  }

  filterByDistinctDateAppointmentDtos(appointments: AppointmentDto[]): string[] {
    console.log(appointments);
    return appointments.map(item => item.appointment.date.substring(0, 10))
    .filter((value, index, self) => self.indexOf(value) === index);
  }

  filterByDateppointmentDtos(appointments: AppointmentDto[], date: string): AppointmentDto[] {
    console.log(appointments);
    return appointments.filter(appointment => appointment.appointment.date.substr(0, 10) === date);
  }

}
