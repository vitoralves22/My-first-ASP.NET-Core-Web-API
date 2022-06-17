import { User } from "./user.model";

export class Chat {
  chatId!: number;
  initiatorName?: string;
  chatMembers?: string[];
  data?: string;
}
