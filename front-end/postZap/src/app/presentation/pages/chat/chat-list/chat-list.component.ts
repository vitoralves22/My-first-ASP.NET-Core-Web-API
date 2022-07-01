import { Component, OnInit } from '@angular/core';
import { RouterEvent } from '@angular/router';
import { Router } from '@angular/router';
import { Chat } from 'src/app/domain/models';
import { ChatService } from 'src/app/domain/services/chat.service';

@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.css']
})
export class ChatListComponent implements OnInit {
  chats: Chat[] = [];
  loaded: boolean = false;

  constructor(
    public chatService: ChatService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.listChats()
  }

  listChats(){
    this.chatService.listChats().subscribe(data =>{
      this.chats = data;
      this.loaded = true;
    });
  }

  openChat(id: number){
    this.router.navigateByUrl('expandedchat/' + id);
  }

  newChat(){
    this.chatService.createChat().subscribe(data =>{});
    window.location.reload();
  }

}
