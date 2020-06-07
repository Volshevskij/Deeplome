import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpHandler, HttpHeaders,HttpClientModule, HttpInterceptor,HttpEvent,} from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable({
    providedIn: 'root'
  })
export class HeaderInsterseptor implements HttpInterceptor{
    intercept(req: HttpRequest<any>, next: HttpHandler):Observable<HttpEvent<any>> {
        //return next.handle(req);
        const modifiedReq = req.clone({ 
          headers: req.headers.set('Authorization', /*`Bearer ${userToken}`*/'Basic ' + btoa( 'ck_4153a2425f568602ad67973b58573efd471b3a70:cs_2f0673fccbf6cb052df8ae1cc8baedaf06ea54b9')),
        });
        return next.handle(modifiedReq);
      }
}