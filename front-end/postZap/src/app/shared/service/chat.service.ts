import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Chat } from '../model';
import { environment } from 'src/environments/environment';
import { Message } from '../model';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  public listChats(): Observable<Chat[]> {
    return this.http.get<Chat[]>(environment.apiUrl + '/chat/list-chat')
  }

  public listMessagesInChat(id: number): Observable<Message[]> {
    return this.http.get<Message[]>(`${environment.apiUrl}/chat/list-messages-from-chat?ChatId=`+ id)
  }

  public getChat(id: number): Observable<Chat> {
    return this.http.get<Chat>(`${environment.apiUrl}/chat/get-chat?chatId=`+ id)
  }

  public sendMessage(message: Message): Observable<Message> {
    return this.http.post<Message>(environment.apiUrl + '/chat/send-message', message, this.httpOptions);
  }

  deleteMessage(messageId: number): Observable<number> {
    return this.http.post<number>(environment.apiUrl + '/chat/delete-message', messageId, this.httpOptions);
  }

}
