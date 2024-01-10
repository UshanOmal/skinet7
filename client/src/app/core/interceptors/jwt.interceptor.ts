import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AcountService } from 'src/app/account/acount.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  token?: string;

  constructor(private accountService : AcountService) {}


  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => this.token = user?.token
    })

    if(this.token){
      request = request.clone({
        setHeaders : {
          Authorization: `Bearer ${this.token}`
        }
      })
    }

    return next.handle(request);

  }
}
