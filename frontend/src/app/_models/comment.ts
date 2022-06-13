interface User {
    userName: string;
}
export interface Comment {
    id: number;
    text: string;
    date: string;
    userId: string;
    userName: string;
    postId: number;
    user: User;
    createdDate: string
}