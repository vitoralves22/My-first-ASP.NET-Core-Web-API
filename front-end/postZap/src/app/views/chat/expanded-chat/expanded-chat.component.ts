import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Chat } from 'src/app/shared/model';
import { Message } from 'src/app/shared/model';
import { ChatService } from 'src/app/shared/service/chat.service';

@Component({
  selector: 'app-expanded-chat',
  templateUrl: './expanded-chat.component.html',
  styleUrls: ['./expanded-chat.component.css'],
})
export class ExpandedChatComponent implements OnInit {
  messages?: Message[];
  loaded: boolean = false;
  chatId!: number;

  constructor(public chatService: ChatService, private route: ActivatedRoute) {
    this.route.params.subscribe((params) => (this.chatId = params['id']));
  }

  ngOnInit(): void {
    this.listMessagesInChat(this.chatId);
  }

  listMessagesInChat(id: number) {
    this.chatService.listMessagesInChat(id).subscribe((data) => {
      this.messages = data;
      this.loaded = true;
    });
  }

  getChatById(){

  }

  sendMessage(){

  }

}
