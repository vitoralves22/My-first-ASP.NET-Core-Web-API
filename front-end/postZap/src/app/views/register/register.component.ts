import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthenticationService } from 'src/app/shared/service';

@Component({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {
  public registerForm!: FormGroup;
  loading = false;

  constructor(private fb: FormBuilder, private rest: AuthenticationService) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
      confirmPassword: ['', [Validators.required]],
    });
  }

  newAccount(): void {
    this.rest.register(this.registerForm.value).subscribe((result) => {});
    this.registerForm.reset();
    window.location.reload();
  }
}
