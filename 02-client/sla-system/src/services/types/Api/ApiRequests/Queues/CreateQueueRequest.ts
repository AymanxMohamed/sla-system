import {RequestType} from "../../enums/RequestType";

export default interface CreateQueueRequest {
    RequestType: RequestType;
    QueueName: string;
}