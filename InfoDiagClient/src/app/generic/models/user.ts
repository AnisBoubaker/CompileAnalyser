export interface User {
    id: number;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
    token: string;
    role: Role;
}

export enum Role {
    Teacher,
    Admin,
    Public
}
