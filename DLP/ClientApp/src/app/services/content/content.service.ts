import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpClientModule, HttpRequest } from '@angular/common/http';
import { map } from 'rxjs/operators';


/*const options = {
  headers: new HttpHeaders({
    // tslint:disable-next-line: max-line-length
    'Authorization': 'Basic ' + btoa( 'ck_4153a2425f568602ad67973b58573efd471b3a70:cs_2f0673fccbf6cb052df8ae1cc8baedaf06ea54b9' )
  })
};*/



@Injectable({
  providedIn: 'root'
})
export class ContentService {

  private headers = new HttpHeaders();


  constructor(private http: HttpClient) {
    this.headers.append('Access-Control-Allow-Origin','*');
    this.headers.append('Authorization','Basic ' + btoa( 'ck_4153a2425f568602ad67973b58573efd471b3a70:cs_2f0673fccbf6cb052df8ae1cc8baedaf06ea54b9'));
   }

  getPosts() {
    let header = new HttpHeaders();
    header.append('Authorization','Basic ' + btoa( 'ck_4153a2425f568602ad67973b58573efd471b3a70:cs_2f0673fccbf6cb052df8ae1cc8baedaf06ea54b9'));
    let body = { headers:header }
    let options = new HttpRequest("GET",'https://diplomawp.000webhostapp.com/wp-json/wp/v2/posts',body);
    return this.http.request(options);
    //return this.http.get('https://diplomawp.000webhostapp.com/wp-json/wp/v2/posts', null);
  }

  getProducts() {
   return this.http.get('https://diplomawp.000webhostapp.com/wp-json/wc/v2/products');
  }

}
