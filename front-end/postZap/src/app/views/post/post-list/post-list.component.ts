import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/shared/model/post.model';
import { PostService } from 'src/app/shared/service/post.service';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {

  posts?: Post[];
  myPosts?: Post[];
  loaded1: boolean = false;
  loaded2: boolean = false;
  active = 1;
  constructor(
    public postService: PostService
  ) { }

  ngOnInit(): void {
    this.listPosts();
    this.listMyPosts();
  }

  listPosts(){
    this.postService.listPosts().subscribe(data =>{
      this.posts = data;
      this.loaded1 = true;
    });
  }

  listMyPosts(){
    this.postService.listMyPosts().subscribe(data =>{
      this.myPosts = data;
      this.loaded2 = true;
    });
  }

  deletePost(id: number){
    this.postService.deletePost(id).subscribe(d =>{
    });
    setTimeout(function(){  window.location.reload(); }, 1000);
  }

  likePost(id: number){
    this.postService.doLike(id).subscribe(d =>{
    });
    console.log("entrei like post")
    // setTimeout(function(){  window.location.reload(); }, 1000);
  }



}
