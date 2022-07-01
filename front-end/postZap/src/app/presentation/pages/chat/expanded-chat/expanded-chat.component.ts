import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Chat, Message } from 'src/app/domain/models';
import { ChatService } from 'src/app/domain/services/chat.service';


@Component({
  selector: 'app-expanded-chat',
  templateUrl: './expanded-chat.component.html',
  styleUrls: ['./expanded-chat.component.css'],
})
export class ExpandedChatComponent implements OnInit, OnChanges {

  messages?: Message[];
  loaded: boolean = false;
  chatId: number = 0;
  chat: Chat = new Chat;
  members: String[] = [];
  messageForm!: FormGroup;
  error = '';
  loading = false;
  email : string = '';

  constructor(
      public chatService: ChatService,
      private route: ActivatedRoute,
      private formBuilder: FormBuilder,
  ) {
      this.route.params.subscribe((params) => (this.chatId = params['id']));
  }

  ngOnInit(): void {
    this.listMessagesInChat(this.chatId);
    this.getChatById(this.chatId);
    this.messageForm = this.formBuilder.group({
      chatId: [this.chatId, Validators.required],
      content: ['', Validators.required]
  });
  }

  ngOnChanges(changes: SimpleChanges) {
    this.chatService.listMessagesInChat(this.chatId).subscribe((data) => {
      this.messages = data;
      this.loaded = true;
    });
  }

  listMessagesInChat(id: number) {
    this.chatService.listMessagesInChat(id).subscribe((data) => {
      this.messages = data;
      this.loaded = true;
    });
  }

  getChatById(id: number) {
    this.chatService.getChat(id).subscribe((data) => {
      this.chat = data;
      if(data.chatMembers != null){
        this.members = data.chatMembers;
      }
      this.loaded = true;
    });
  }

  sendMessage() {
    this.chatService.sendMessage(this.messageForm.value).subscribe((result) => {});
    this.messageForm.reset();
    window.location.reload();
  }

  sendInvitation() {
    this.chatService.sendInvitation(this.email, this.chatId).subscribe((result) => {});
    console.log(this.email, this.chatId);
  }

  deleteMessage(id: number) {
    this.chatService.deleteMessage(id).subscribe(d =>{
    },
    error => {
        this.error = error.error;
        console.log(error)
        this.loading = false;
    });
    console.log(this.error)
    window.location.reload()
  }

}
