import {Role} from "./Api/enums/Role";

export default interface User {
    id: string;
    userName: string;
    password: string;
    role: Role;

}


