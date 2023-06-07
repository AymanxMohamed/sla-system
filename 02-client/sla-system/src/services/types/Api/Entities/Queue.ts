import User from "./User";

export default interface Queue {
    id: string;
    queueName: string;
    requestType: string;
    users: User[];
}