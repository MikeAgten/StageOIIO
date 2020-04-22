import {Routes} from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { ClientHomepageComponent } from './client-homepage/client-homepage.component';
import { AddAppointmentClientComponent } from './add-appointment-client/add-appointment-client.component';


export const appRoutes: Routes = [
    { path: 'login', component: LoginPageComponent },
    { path: 'contact/:id', component: ClientHomepageComponent },
    { path: 'addAppointment/:id', component: AddAppointmentClientComponent},
    { path: '', redirectTo: '/login', pathMatch: 'full' }
];
