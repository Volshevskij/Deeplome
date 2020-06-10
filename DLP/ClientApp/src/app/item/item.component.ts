import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ContentService } from '../services/content/content.service';
import { HardwareViewModel } from '../models/HardwareViewModel';
import { AttributeViewModel } from '../models/AttributeViewModel';


@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss']
})
export class ItemComponent implements OnInit {

  id: number;
  type: string;
  constructor(private http: HttpClient, private router: Router, private route: ActivatedRoute, private service: ContentService) {
    this.id = route.snapshot.params['id'];
    this.type = route.snapshot.params['type'];
  }

  item: any;

  ngOnInit() {
    this.getPosts();
  }

  getPosts() {
    this.service.getProductById(this.id, this.type).subscribe((data: any) => {
      this.item = data;
      console.log(this.item);
    }  );
  }

}
