import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { Chat } from '../models';
import { Message } from '../models';
import { ChatRepository } from '../repositories/chat.repository';
import { ChatInvitation } from '../models/chatInvitation.model';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private chatRepository: ChatRepository) { }

  public listChats() {
    return this.chatRepository.listChats();
  }

  public listMessagesInChat(id: number) {
    return this.chatRepository.listMessagesInChat(id);
  }

  public getChat(id: number) {
    return this.chatRepository.getChat(id);
  }

  public sendMessage(message: Message) {
    return this.chatRepository.sendMessage(message);
  }

  public deleteMessage(messageId: number) {
    return this.chatRepository.deleteMessage(messageId);
  }

  public createChat() {
    return this.chatRepository.createChat();
  }

  public listReceivedChatInvitations() {
    return this.chatRepository.listReceivedChatInvitations();
  }

  public sendInvitation(email: String, chatId: Number) {
    return this.chatRepository.sendInvitation(email, chatId);
  }

  public acceptChatInvitation(id: number) {
    return this.chatRepository.acceptChatInvitation(id);
  }

  public denyChatInvitation(id: number) {
    return this.chatRepository.acceptChatInvitation(id);
  }

}
