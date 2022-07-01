import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { AuthenticationRepository } from '../repositories/authentication.repository';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

  private currentUserSubject: BehaviorSubject<User>;
  public currentUserObservable: Observable<User>;

  private accessTokenSubject: BehaviorSubject<string>;
  public accessTokenObservable: Observable<string>;

  constructor(private authRepository: AuthenticationRepository) {
    this.currentUserSubject = new BehaviorSubject<User>(
      JSON.parse(localStorage.getItem('currentUser')!)
    );
    this.currentUserObservable = this.currentUserSubject.asObservable();

    this.accessTokenSubject = new BehaviorSubject<string>(
      JSON.parse(localStorage.getItem('accessToken')!)
    );
    this.accessTokenObservable = this.accessTokenSubject.asObservable();
  }

  public get currentUser(): User {
    return this.currentUserSubject.value;
  }

  public get accessToken(): string {
    return this.accessTokenSubject.value;
  }

  login(username: string, password: string) {
    return this.authRepository.login(username, password).pipe(
      map((data) => {
        localStorage.setItem('currentUser', JSON.stringify(data.me));
        localStorage.setItem('accessToken', JSON.stringify(data.access_token));
        this.currentUserSubject.next(data.me);
        this.accessTokenSubject.next(data.access_token);
        return data;
      })
    );
  }

  register(user: any) {
    return this.authRepository.register(user);
  }

  logout() {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('accessToken');
    this.currentUserSubject.next(null!);
    this.accessTokenSubject.next(null!);
  }

}
