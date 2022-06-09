import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { timer } from 'rxjs';
import { UserService } from 'src/app/shared/service';

@Component({
  selector: 'app-register-form-dialog',
  templateUrl: './register-form-dialog.component.html',
  styleUrls: ['./register-form-dialog.component.css']
})
export class RegisterFormDialogComponent implements OnInit {
  public registerForm!: FormGroup
  constructor(
    public dialogRef: MatDialogRef<RegisterFormDialogComponent>,
    private fb: FormBuilder,
    private rest: UserService) {
  }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      Username: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      Password: ['', [Validators.required]],
      PasswordConfirm: ['', [Validators.required]]
    });
  }

  newAccount(): void {
    this.rest.newAccount(this.registerForm.value).subscribe(result => {});
    this.dialogRef.close();
    this.registerForm.reset();
    setTimeout(function(){  window.location.reload(); }, 1000);
  }

  cancel(): void {
    this.dialogRef.close();
    this.registerForm.reset();
  }

}
