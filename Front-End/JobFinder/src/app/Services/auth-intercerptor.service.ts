import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class AuthIntercerptorService implements HttpInterceptor{

  constructor(private auth: AuthenticationService) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
// Pegue o token da sua fonte (por exemplo, do serviço de autenticação)
const authToken = this.auth.getToken();

// Clone the request and set the new header
const authReq = req.clone({
  headers: req.headers.set('Authorization', 'Bearer ' + authToken)
});

// Pass the cloned request instead of the original request to the next handle
return next.handle(authReq);
}
}
