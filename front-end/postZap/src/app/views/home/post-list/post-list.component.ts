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
  loaded: boolean = false;

  constructor(
    public postService: PostService
  ) { }

  ngOnInit(): void {
    this.listPosts();
  }

  listPosts(){
    this.postService.listPosts().subscribe(data =>{
      this.posts = data;
      this.loaded = true;
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
