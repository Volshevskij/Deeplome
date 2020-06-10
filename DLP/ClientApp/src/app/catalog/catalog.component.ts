import { Component, OnInit } from '@angular/core';
import {ContentService} from '../services/content/content.service';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent implements OnInit {
  items: any;
  constructor( private service: ContentService) { }

  ngOnInit() {
    this.getPosts();
  }



  getPosts() {
    this.service.getProducts().subscribe((data: any) => {
      this.items = data;
    }  );
  }

}
