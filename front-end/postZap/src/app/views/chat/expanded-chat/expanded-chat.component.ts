import { Component, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  chat!: Chat;
  members?: String[];
  messageForm!: FormGroup;
  error?: '';
  loading = false;


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

  // ngOnChanges(changes: SimpleChanges): void{

  // }

  listMessagesInChat(id: number) {
    this.chatService.listMessagesInChat(id).subscribe((data) => {
      this.messages = data;
      this.loaded = true;
    });
  }

  getChatById(id: number){
    this.chatService.getChat(id).subscribe((data) => {
      this.chat = data;
      this.members = data.chatMembers;
      this.loaded = true;
    });
  }

  sendMessage(){
    this.chatService.sendMessage(this.messageForm.value).subscribe((result) => {});
    this.messageForm.reset();
    window.location.reload();
  }

  deleteMessage(id: number){
    this.chatService.deleteMessage(id).subscribe(d =>{
    },
    error => {
        this.error = error.error;
        console.log(error)
        this.loading = false;
    });
    console.log("entrei undolike post")
    console.log(this.error)
    window.location.reload()
    // setTimeout(function(){  window.location.reload(); }, 1000);

  }

}
