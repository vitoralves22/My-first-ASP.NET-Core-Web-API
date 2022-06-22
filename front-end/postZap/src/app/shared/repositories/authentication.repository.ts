import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { SsoDTO, User } from '../model';

@Injectable({ providedIn: 'root' })
export class AuthenticationRepository {

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<SsoDTO> {
    console.log('entrei na  repository');
    return this.http
      .post<any>(`${environment.apiUrl}/auth/sign-in`, { username, password })
      .pipe(
        map((data) => {
          let ssoDTO = data;
          return ssoDTO;
        })
      );
  }

  register(user: any): Observable<User> {
    return this.http
    .post<any>(`${environment.apiUrl}/auth/sign-up`, { user })
    .pipe(
      map((data) => {
        let user = data;
        return user;
      })
    );
  }

}
