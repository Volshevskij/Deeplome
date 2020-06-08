import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
  headers: new HttpHeaders({
    // tslint:disable-next-line: max-line-length
    'Authorization': 'Basic ' + btoa( 'ck_4153a2425f568602ad67973b58573efd471b3a70:cs_2f0673fccbf6cb052df8ae1cc8baedaf06ea54b9' )
  })
};


@Injectable({
  providedIn: 'root'
})
export class ContentService {

  constructor(private http: HttpClient) { }

  getPosts() {
    return this.http.get('https://diplomawp.000webhostapp.com/wp-json/wp/v2/posts');
  }

  getProducts() {
   const headers = new HttpHeaders({
      // tslint:disable-next-line: max-line-length
      'Authorization': 'Basic' + btoa( 'ck_4153a2425f568602ad67973b58573efd471b3a70:cs_2f0673fccbf6cb052df8ae1cc8baedaf06ea54b9' )
    });

   return this.http.get('https://diplomawp.000webhostapp.com/wp-json/wc/v2/products');
  }

}
