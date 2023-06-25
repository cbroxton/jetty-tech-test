import { HttpContextToken, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, switchMap } from "rxjs";
import { AuthService } from "../services/shared/auth/auth.service";

export const BYPASS_AUTH = new HttpContextToken(() => false);

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  // this obviously doesn't account for token refreshing etc
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (req.context.get(BYPASS_AUTH)) {
      return next.handle(req);
    }

    return this.authService.getToken()
      .pipe(switchMap(token =>
        next.handle(req.clone({
          setHeaders: {
            Authorization: `Bearer ${token}`
          }
        }))
      ));
  }
}
