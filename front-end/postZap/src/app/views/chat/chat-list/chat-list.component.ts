import { Component, OnInit } from '@angular/core';
import { RouterEvent } from '@angular/router';
import { Chat } from 'src/app/shared/model';
import { ChatService } from 'src/app/shared/service/chat.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chat-list',
  templateUrl: './chat-list.component.html',
  styleUrls: ['./chat-list.component.css']
})
export class ChatListComponent implements OnInit {
  chats?: Chat[];
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

}
