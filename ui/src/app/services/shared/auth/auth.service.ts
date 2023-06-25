import { HttpClient, HttpContext } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, shareReplay } from "rxjs";
import { BYPASS_AUTH } from "src/app/interceptors/jwt-interceptor";

@Injectable({providedIn: 'root'})
export class AuthService {
  private token$?: Observable<string>;

  constructor(private httpClient: HttpClient) {}

  getToken(): Observable<string> {
    return this.token$ ??= this.httpClient
      .get('Authenticate/generate', {
        context: new HttpContext().set(BYPASS_AUTH, true),
        responseType: 'text'
      })
      .pipe(shareReplay(1));
  }
}
