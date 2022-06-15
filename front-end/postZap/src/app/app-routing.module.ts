import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// import { HomeComponent } from './home';
import { LoginComponent } from './views/login';
import { HomeComponent } from './views/home/home.component';
import { AuthGuard } from './shared/helpers';
import { PostListComponent } from './views/post/post-list/post-list.component';
import { PostFormComponent } from './views/post/post-form/post-form.component';
import { ChatListComponent } from './views/chat/chat-list/chat-list.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'postlist', component: PostListComponent },
      { path: 'postform', component: PostFormComponent },
      { path: 'chatlist', component: ChatListComponent },
    ],
  },

  { path: 'login', component: LoginComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
