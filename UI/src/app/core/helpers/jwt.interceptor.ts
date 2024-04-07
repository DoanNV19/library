import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor() {
    //TODO
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!request.url.includes('assets')) {
      const authToken = localStorage.getItem('token');
      if (authToken) {
        request = request.clone({
          setHeaders: {
            Authorization: `Bearer ${authToken}`
          }
        });
      }
      if (authToken && !request.url.includes('https://') && !request.url.includes('http://')) {
        request = request.clone({
          url: environment.webApi + request.url,
          setHeaders: {
            Authorization: `Bearer ${authToken}`
          }
        });
      } else if (!request.url.includes('https://') && !request.url.includes('http://')) {
        request = request.clone({
          url: environment.webApi + request.url
        });
      }
    }
    return next.handle(request);
  }
}
