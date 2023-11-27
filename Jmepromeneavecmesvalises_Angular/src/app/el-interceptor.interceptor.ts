import {Injectable} from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable()
export class ElInterceptor implements HttpInterceptor {

  constructor() {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = localStorage.getItem('token');
    let url = new URL(request.url)

    if (url.hostname == 'localhost') {
      request = request.clone({
        setHeaders: {
          'Authorization': 'Bearer ' + token
        }
      })
    }

    return next.handle(request);
  }
}
