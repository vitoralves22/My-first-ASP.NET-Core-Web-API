import { User } from './user.model';

export class Message {
  chatId?: number;
  messageId?: number;
  content?: string;
  senderName?: string;
  senderId?: string;
  footer?: string;
  data?: string;
  isMine?: boolean;
}
