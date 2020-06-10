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

  connetction = 'https://localhost:44344/api/';

  constructor(private http: HttpClient) { }

  getPosts() {
    return this.http.get('https://diplomawp.000webhostapp.com/wp-json/wp/v2/posts');
  }

  getProducts() {
   return this.http.get(this.connetction + 'catalog/getCatalog');
  }

  getProductById(id: number, type: string) {
    return this.http.get(this.connetction + 'catalog/' + id + '/' + type);
  }

  getProductByType(type: string) {
    return this.http.get(this.connetction + 'catalog/' + 'type/' + type);
  }

  saveAssembly(pc: any) {
    return this.http.post(this.connetction + 'pc/' + 'compareall/', pc);
  }

  setPc(pc: any) {
    this.http.post(this.connetction + 'pc/' + 'setPC/', pc).toPromise();
  }

}
