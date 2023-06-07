import {Role} from "../enums/Role";

export default interface User {
    id: string;
    userName: string;
    password: string;
    role: Role;
    zone: string;
    queueId: string;
}