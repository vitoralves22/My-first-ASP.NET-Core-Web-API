import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PostService } from 'src/app/domain/services';

@Component({
  selector: 'app-post-form-update',
  templateUrl: './post-form-update.component.html',
  styleUrls: ['./post-form-update.component.css'],
})
export class PostFormUpdateComponent implements OnInit {

  postForm!: FormGroup;
  error: string = '';
  loading: boolean = false;
  id: number = 0;
  titulo: string = '';
  conteudo: string = '';

  constructor(
    private fb: FormBuilder,
    private rest: PostService,
    private route: ActivatedRoute,
  ) {
    this.route.params.subscribe((params) => (this.id = params['id']));
  }

  ngOnInit(): void {
    this.getPostById(this.id);
    this.postForm = this.fb.group({
      id: [this.id, Validators.required],
      titulo: ['', [Validators.required]],
      conteudo: ['', [Validators.required]],
    });
  }

  deletePost(id: number) {
    this.rest.deletePost(id).subscribe((d) => {},
    error => {
      this.error = error.error;
      console.log(error)
      this.loading = false;
    });
    setTimeout(function () {
      window.location.reload();
    }, 1000);
  }

  editPost(){
    if(this.postForm.value.titulo == '' || this.postForm.value.titulo == null){
      this.postForm.value.titulo = this.titulo;
    }
    if(this.postForm.value.conteudo == '' || this.postForm.value.conteudo == null){
      this.postForm.value.conteudo = this.conteudo;
    }
    this.rest.editPost(this.postForm.value).subscribe((result) => {},
    error => {
        this.error = error.error;
        console.log(error)
        this.loading = false;
    });
    this.postForm.reset();
  }

  getPostById(id: number){
    this.rest.getPost(id).subscribe((data) => {
      this.titulo = data.titulo;
      this.conteudo = data.conteudo;
    });
  }
  cancel() {
    this.postForm.reset();
  }

}
