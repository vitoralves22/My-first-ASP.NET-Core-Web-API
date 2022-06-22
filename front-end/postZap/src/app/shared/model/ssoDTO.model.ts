import { User } from "./user.model";

export class SsoDTO {
  me: User = new User();
  access_token: string = '';

}
