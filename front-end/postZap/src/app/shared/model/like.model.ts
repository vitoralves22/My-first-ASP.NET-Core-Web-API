import { Post } from "./post.model";
import { User } from "./user.model";

export class Like {
  id?: number;
  applicationUserId?: string;
  applicationUser?: User;
  data?: string;
  post?: Post;
  postId?: number;

}
