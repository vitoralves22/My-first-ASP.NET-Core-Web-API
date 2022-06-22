import { User } from "./user.model";

export class Post {
    postId!: number;
    titulo?: string;
    conteudo?: string;
    data?: string;
    owner?: String;
    likesCount?: String;
    applicationUserId?: string;
    applicationUser?: User;
    likedByMe?: boolean;

}
