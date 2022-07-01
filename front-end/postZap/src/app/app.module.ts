import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ChatListComponent } from './presentation/pages/chat/chat-list/chat-list.component';
import { ExpandedChatComponent } from './presentation/pages/chat/expanded-chat/expanded-chat.component';
import { LoginComponent } from './presentation/pages/auth/login/login.component';
import { RegisterComponent } from './presentation/pages/auth/register/register.component';
import { PostFormComponent } from './presentation/pages/post/post-form/post-form.component';
import { PostListComponent } from './presentation/pages/post/post-list/post-list.component';
import { HomeComponent } from './presentation/pages/home/home.component';
import { NavbarComponent } from './presentation/shared/navbar/navbar.component';
import { SidebarComponent } from './presentation/shared/sidebar/sidebar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor, JwtInterceptor } from './core/interceptors';
import { AuthenticationService } from './domain/services/authentication.service';
import { LocalDateTimePipe } from './core/pipe/local-date-time.pipe';
import { PostFormUpdateComponent } from './presentation/pages/post/post-form-update/post-form-update.component';
import { ChatInvitationsComponent } from './presentation/pages/chat/chat-invitations/chat-invitations.component';

@NgModule({
  declarations: [
    AppComponent,
    ChatListComponent,
    ExpandedChatComponent,
    LoginComponent,
    RegisterComponent,
    PostFormComponent,
    PostListComponent,
    HomeComponent,
    NavbarComponent,
    SidebarComponent,
    LocalDateTimePipe,
    PostFormUpdateComponent,
    ChatInvitationsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    AuthenticationService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    LocalDateTimePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

