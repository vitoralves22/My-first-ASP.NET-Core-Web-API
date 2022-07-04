import { Component, OnInit } from '@angular/core';
import { Router} from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService } from 'src/app/domain/services';

@Component({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {

  public registerForm!: FormGroup;
  loading = false;
  error: string = '';

  constructor(private fb: FormBuilder, private rest: AuthenticationService, private router: Router) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      passwordConfirm: ['', [Validators.required]],
    });
  }

  newAccount(): void {
    this.rest.register(this.registerForm.value).subscribe(
      data => {},
      error => {
        this.error = error.error;
        console.log(error)
        this.loading = false;
      }
    );
    this.registerForm.reset();
  }

  login(){
    this.router.navigateByUrl('login');
  }

}
