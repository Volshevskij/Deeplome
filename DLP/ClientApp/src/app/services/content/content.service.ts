import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContentService {

  constructor(private http: HttpClient) { }

  getPosts() {
    return this.http.get('https://diplomawp.000webhostapp.com/wp-json/wp/v2/posts');
  }
}
