import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { PostRepository } from '../repositories/post.repository';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private postRepository: PostRepository) { }

  public listPosts() {
    return this.postRepository.listPosts();
  }

  public listMyPosts() {
    return this.postRepository.listMyPosts();
  }

  public postPosts(post: any) {
    return this.postRepository.postPosts(post);
  }

  public listUserPosts() {
    return this.postRepository.listUserPosts();
  }

  public deletePost(post: any) {
    return this.postRepository.deletePost(post);
  }

  public editPost(id: number) {
    return this.postRepository.editPost(id);
  }

  public doLike(postId: number) {
    return this.postRepository.doLike(postId);
  }

  public undoLike(postId: number) {
    return this.postRepository.undoLike(postId);
  }

  public getPost(postId: number) {
    return this.postRepository.getPost(postId);
  }

}
