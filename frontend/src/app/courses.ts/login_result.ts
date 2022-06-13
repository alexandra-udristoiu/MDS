interface UserModel {
    id: string;
    name: string;
}

export interface LoginResult {
    token: string;
    user: UserModel;
}