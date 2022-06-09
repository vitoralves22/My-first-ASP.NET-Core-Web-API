import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpUserEvent } from '@angular/common/http';
import { User } from '../model/user.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UserService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };
  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<User[]>(`${environment.apiUrl}/users`);
  }

  newAccount(user: any): Observable<any> {
    return this.http.post<any>(
      `${environment.apiUrl}/auth/sign-up`,
      user,
      this.httpOptions
    );
  }
}
