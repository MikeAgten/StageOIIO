import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ContactService } from './services/contact.service';
import { ClientHomepageComponent } from './client-homepage/client-homepage.component';
import { appRoutes } from './app.routes';
import { RouterModule } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { from } from 'rxjs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppointmentClientComponent } from './appointment-client/appointment-client.component';
import { AddAppointmentClientComponent } from './add-appointment-client/add-appointment-client.component';
import { TopLayoutComponent } from './top-layout/top-layout.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ClientHomepageComponent,
    LoginPageComponent,
    AppointmentClientComponent,
    AddAppointmentClientComponent,
    TopLayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
		ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [ContactService],
  bootstrap: [AppComponent]
})
export class AppModule { }
