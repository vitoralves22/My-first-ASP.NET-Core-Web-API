import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Post } from '../model/post.model';
import { User } from '../model';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class PostService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  public listPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(environment.apiUrl + '/post/list-posts')
  }

  public postPosts(post: any): Observable<Post> {
    return this.http.post<any>(environment.apiUrl + '/post/create-post', post, this.httpOptions);
  }

  public listUserPosts() {
    return this.http.get<Post[]>(`${environment.apiUrl}/post/list-posts-by-current-user`);
  }

  deletePost(id: number): Observable<number> {
    return this.http.delete<number>(`${environment.apiUrl}/post/delete-post?postId=`+ id);
  }

  doLike(postId: number): Observable<number> {
    console.log('post id:', postId)
    return this.http.post<number>(environment.apiUrl + '/like/do-like', postId, this.httpOptions);
  }

}
