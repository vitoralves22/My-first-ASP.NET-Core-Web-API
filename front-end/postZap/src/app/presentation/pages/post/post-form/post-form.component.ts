import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenticationService, PostService } from 'src/app/domain/services';


@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.css'],
})
export class PostFormComponent implements OnInit {

  postForm!: FormGroup;
  error = '';
  loading = false;

  constructor(
    private fb: FormBuilder,
    private rest: PostService,
    private auth: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.postForm = this.fb.group({
      titulo: ['', [Validators.required]],
      conteudo: ['', [Validators.required]],
    });
  }

  createPost() {
    console.log(this.postForm.value);
    this.rest.createPost(this.postForm.value).subscribe((result) => {},
    error => {
        this.error = error.error;
        console.log(error)
        this.loading = false;
    });
    this.postForm.reset();
  }

  deletePost(id: number) {
    this.rest.deletePost(id).subscribe((d) => {});
    setTimeout(function () {
      window.location.reload();
    }, 1000);
  }

  cancel() {
    this.postForm.reset();
  }

}
