import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ContactService } from './services/contact.service';
import { AppointmentService } from './services/appointment.service';
import { ClientHomepageComponent } from './client-homepage/client-homepage.component';
import { appRoutes } from './app.routes';
import { RouterModule } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { from } from 'rxjs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppointmentClientComponent } from './appointment-client/appointment-client.component';
import { AddAppointmentClientComponent } from './add-appointment-client/add-appointment-client.component';
import { TopLayoutComponent } from './top-layout/top-layout.component';
import { TenantHomepageComponent } from './tenant-homepage/tenant-homepage.component';
import { ScheduleModule, RecurrenceEditorModule, DayService, WeekService, WorkWeekService, MonthService, MonthAgendaService } from '@syncfusion/ej2-angular-schedule';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ClientHomepageComponent,
    LoginPageComponent,
    AppointmentClientComponent,
    AddAppointmentClientComponent,
    TopLayoutComponent,
    TenantHomepageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
		ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    ScheduleModule, RecurrenceEditorModule
  ],
  providers: [ContactService, AppointmentService, DayService, WeekService, WorkWeekService, MonthService, MonthAgendaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
