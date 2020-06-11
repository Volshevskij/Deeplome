import { Component, OnInit } from '@angular/core';
import { ContentService } from '../services/content/content.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private service: ContentService) { }

  posts: any;
  item: any;

  ngOnInit() {
    this.getPosts();
    this.getPostById(1);
  }

  getPosts() {
    this.service.getPosts().subscribe((data: any) => {
      this.posts = data;
    }  );
  }

  getPostById(id: number) {
    this.service.getPostById(id).subscribe((data: any) => {
      this.item = data;
    }  );
  }

}
