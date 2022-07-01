import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChatInvitation } from 'src/app/domain/models/chatInvitation.model';
import { ChatService } from 'src/app/domain/services/chat.service';

@Component({
  selector: 'app-chat-invitations',
  templateUrl: './chat-invitations.component.html',
  styleUrls: ['./chat-invitations.component.css']
})
export class ChatInvitationsComponent implements OnInit {

  chatInvitations: ChatInvitation[] = [];
  loaded: boolean = false;

  constructor(
    public chatService: ChatService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.listReceivedChatInvitations()
  }

  listReceivedChatInvitations(){
    this.chatService.listReceivedChatInvitations().subscribe(data =>{
      if(data != null){
        this.chatInvitations = data;
      }
      this.loaded = true;
    });
  }

  acceptChatInvitation(invitationId: number){
    this.chatService.acceptChatInvitation(invitationId).subscribe((result) => {});
  }

  denyChatInvitation(invitationId: number){
    this.chatService.denyChatInvitation(invitationId).subscribe((result) => {});
  }

}
