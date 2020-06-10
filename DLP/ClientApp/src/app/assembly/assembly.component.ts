import { Component, OnInit } from '@angular/core';
import {ContentService} from '../services/content/content.service';
import { Pc } from '../models/pc';

@Component({
  selector: 'app-assembly',
  templateUrl: './assembly.component.html',
  styleUrls: ['./assembly.component.scss']
})
export class AssemblyComponent implements OnInit {

  items:Pc[] = [];

  constructor(private service: ContentService) {
   }

  ngOnInit() {
    this.getAssemblies();
  }

  getAssemblies() {
    this.service.getAssemblies().subscribe((data: any) => {
      this.items = data;
    }  );
  }

}
