import { Appointment } from './appointment.model';
import { Address } from './address.model';

export class AppointmentDto {
  appointment: Appointment;
  address: Address;

  constructor(appointment: Appointment, address: Address){
    this.appointment = appointment;
    this.address = address;
  }

}
