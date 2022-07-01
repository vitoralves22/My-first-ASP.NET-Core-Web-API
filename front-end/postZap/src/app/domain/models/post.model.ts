import { User } from "./user.model";

export class Post {

    postId: number = 0;
    titulo: string = '';
    conteudo: string = '';
    data: string = '';
    owner: String = '';
    likesCount: String = '';
    applicationUserId: string = '';
    applicationUser: User = new User;
    likedByMe: boolean = false;

}
