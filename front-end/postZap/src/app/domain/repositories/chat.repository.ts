import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Chat } from '../models';
import { environment } from 'src/environments/environment';
import { Message } from '../models';
import { ChatInvitation } from '../models/chatInvitation.model';

@Injectable({
  providedIn: 'root'
})
export class ChatRepository {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  public listChats() {
    return this.http.get<Chat[]>(environment.apiUrl + '/chat/list-chat')
  }

  public listMessagesInChat(id: number) {
    return this.http.get<Message[]>(`${environment.apiUrl}/chat/list-messages-from-chat?ChatId=`+ id)
  }

  public getChat(id: number) {
    return this.http.get<Chat>(`${environment.apiUrl}/chat/get-chat?chatId=`+ id)
  }

  public sendMessage(message: Message) {
    return this.http.post<Message>(environment.apiUrl + '/chat/send-message', message, this.httpOptions);
  }

  public deleteMessage(messageId: number) {
    return this.http.post<number>(environment.apiUrl + '/chat/delete-message', messageId, this.httpOptions);
  }

  public createChat() {
    return this.http.post<any>(environment.apiUrl + '/chat/initiate-chat', [], this.httpOptions);
  }

  public listReceivedChatInvitations() {
    return this.http.get<ChatInvitation[]>(environment.apiUrl + '/chat/list-my-received-chat-invitations')
  }

  public sendInvitation(email: String, chatId: Number) {
    return this.http.post<any>(`${environment.apiUrl}/chat/send-invitation?email=`+ email + `&chatId=` + chatId, this.httpOptions);
  }

  public acceptChatInvitation(id: number) {
    console.log("Entrei Repository")
    return this.http.post<any>(`${environment.apiUrl}/chat/accept-invitation?ChatInvitationId=`+ id, this.httpOptions);
  }

  public denyChatInvitation(id: number) {
    return this.http.post<any>(`${environment.apiUrl}/chat/deny-invitation?ChatInvitationId=`+ id, this.httpOptions);
  }

}
