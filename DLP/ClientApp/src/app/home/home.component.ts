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

  ngOnInit() {
    this.posts = '';
    this.getPosts();
  }

  getPosts() {
    this.service.getProducts().subscribe((data: any) => {
      this.posts = data;
      console.log(this.posts[0].content.rendered);
    }  );
  }

}
