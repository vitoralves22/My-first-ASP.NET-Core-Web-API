import { Post } from "./post.model";
import { User } from "./user.model";

export class Like {

  id: number = 0;
  applicationUserId: string = '';
  applicationUser: User = new User();
  data: string = '';
  post: Post = new Post();
  postId: number = 0;

}
