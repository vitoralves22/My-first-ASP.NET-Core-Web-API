import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from 'src/app/domain/models';
import { PostService } from 'src/app/domain/services';


@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {

  posts: Post[] = [];
  myPosts: Post[] = [];
  loaded1: boolean = false;
  loaded2: boolean = false;
  active: number = 1;
  error: string = '';
  loading: boolean = false;

  constructor(
    public postService: PostService, private router: Router
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

  editPost(id: number){
    this.router.navigateByUrl('postformupdate/' + id);
  }

  deletePost(id: number){
    this.postService.deletePost(id).subscribe(d =>{
    });
    setTimeout(function(){  window.location.reload(); }, 1000);
  }

  likePost(id: number){
    this.postService.doLike(id).subscribe(d =>{
    });
    window.location.reload()
  }

  undoLike(id: number){
    this.postService.undoLike(id).subscribe(d =>{
    },
    error => {
        this.error = error.error;
        console.log(error)
        this.loading = false;
    });
    window.location.reload()
  }

}
