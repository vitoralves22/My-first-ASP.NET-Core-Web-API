import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Post } from '../models/post.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostRepository {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  public listPosts() {
    return this.http.get<Post[]>(environment.apiUrl + '/post/list-posts')
  }

  public listMyPosts() {
    return this.http.get<Post[]>(environment.apiUrl + '/post/list-posts-by-current-user')
  }

  public postPosts(post: any) {
    return this.http.post<any>(environment.apiUrl + '/post/create-post', post, this.httpOptions);
  }

  public listUserPosts() {
    return this.http.get<Post[]>(`${environment.apiUrl}/post/list-posts-by-current-user`);
  }

  public deletePost(id: number) {
    return this.http.delete<number>(`${environment.apiUrl}/post/delete-post?postId=`+ id);
  }

  public editPost(post: any) {
    return this.http.put<any>(environment.apiUrl + '/post/update-post', post, this.httpOptions);
  }

  public doLike(postId: number) {
    console.log('post id:', postId)
    return this.http.post<number>(environment.apiUrl + '/like/do-like', postId, this.httpOptions);
  }

  public undoLike(postId: number) {
    console.log('post id:', postId)
    return this.http.post<number>(environment.apiUrl + '/like/undo-like', postId, this.httpOptions);
  }

  public getPost(id: number) {
    return this.http.get<Post>(`${environment.apiUrl}/post/get-post?postId=`+ id)
  }

}
