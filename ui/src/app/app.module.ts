import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'
import { ApiUrlInterceptor } from './interceptors/api-url.interceptor';
import { JwtInterceptor } from './interceptors/jwt-interceptor';
import { EmployeesModule } from './features/employees/employees.module';
import { HomeComponent } from './features/home/components/home/home.component';
import { NotFoundComponent } from './core/components/not-found/not-found/not-found.component';
import { ErrorPageComponent } from './core/components/error-page/error-page.component';
import { HttpErrorInterceptor } from './interceptors/http-error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundComponent,
    ErrorPageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    EmployeesModule,
    AppRoutingModule
  ],
  providers: [
    AppComponent,
    { provide: HTTP_INTERCEPTORS, useClass: ApiUrlInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
