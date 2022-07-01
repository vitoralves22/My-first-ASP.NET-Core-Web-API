import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// import { HomeComponent } from './home';
import { HomeComponent } from './presentation/pages/home/home.component';
import { AuthGuard } from './core/security';
import { PostListComponent } from './presentation/pages/post/post-list/post-list.component';
import { PostFormComponent } from './presentation/pages/post/post-form/post-form.component';
import { ChatListComponent } from './presentation/pages/chat/chat-list/chat-list.component';
import { ExpandedChatComponent } from './presentation/pages/chat/expanded-chat/expanded-chat.component';
import { LoginComponent } from './presentation/pages/auth/login/login.component';
import { RegisterComponent } from './presentation/pages/auth/register/register.component';
import { PostFormUpdateComponent } from './presentation/pages/post/post-form-update/post-form-update.component';
import { ChatInvitationsComponent } from './presentation/pages/chat/chat-invitations/chat-invitations.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'postlist', component: PostListComponent },
      { path: 'postform', component: PostFormComponent },
      { path: 'postformupdate/:id', component: PostFormUpdateComponent },
      { path: 'chatlist', component: ChatListComponent },
      { path: 'expandedchat/:id', component: ExpandedChatComponent },
      { path: 'chatinvitations', component: ChatInvitationsComponent },
    ],
  },

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  // otherwise redirect to home
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
