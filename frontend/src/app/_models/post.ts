interface User {
    userName: string;
}

export interface Post {
    id: number;
    title: string;
    text: string;
    date: string;
    userId: string;
    userName: string;
    tags: string[];
}