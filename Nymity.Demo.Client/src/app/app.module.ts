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
import { OrderComponent } from './order/order.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { AuthGuard } from './auth-guard';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpModule,
    NgbModule.forRoot()
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    WelcomeComponent,
    OrderComponent,
    OrderDetailComponent
  ],
  providers: [
    AuthenticationService,
    OrderService,
    AuthGuard
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
