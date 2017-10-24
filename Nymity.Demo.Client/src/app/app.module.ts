import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';

import { AppComponent }         from './app.component';

import { AppRoutingModule }     from './app-routing.module';
import { LoginComponent } from './login/login.component';
import { AuthenticationService } from './services/authentication.service';
import { OrderService } from './services/order.service';
import { HttpModule } from '@angular/http';
import { WelcomeComponent } from './welcome/welcome.component';
import { AlertService } from './services/alert.service';
import { OrderComponent } from './order/order.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpModule
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    WelcomeComponent,
    OrderComponent
  ],
  providers: [
    AuthenticationService,
    OrderService,
    AlertService
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
