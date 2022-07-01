import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { SsoDTO} from '../models';

@Injectable({ providedIn: 'root' })
export class AuthenticationRepository {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<SsoDTO> {
    return this.http
      .post<SsoDTO>(`${environment.apiUrl}/auth/sign-in`, { username, password })
      .pipe(
        map((data) => {
          let ssoDTO: SsoDTO = data;
          return ssoDTO;
        })
      );
  }

  register(user: any): Observable<any> {
    return this.http.post<any>(`${environment.apiUrl}/auth/sign-up`, user);
  }

}
