export interface User {
    id: number;
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    Role: Role;
}

export enum Role {
    Teacher,
    Admin,
    Public
}
