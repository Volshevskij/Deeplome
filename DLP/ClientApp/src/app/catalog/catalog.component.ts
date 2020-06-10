import { Component, OnInit, Inject } from '@angular/core';
import { ContentService } from '../services/content/content.service';
import { Injectable } from '@angular/core';



@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent implements OnInit {
  tmp: any;
  constructor( private service: ContentService) { }

  ngOnInit() {
    this.tmp  = [];
    this.getPosts();
  }



  getPosts() {
    this.service.getProducts().subscribe((data: any) => {
      this.tmp = data;
      console.log(this.tmp);
    }  );
  }

}
