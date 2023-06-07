import {RequestType} from "../enums/RequestType";
import User from "./User";
import Sla from "./Sla";
import {RequestStatus} from "../enums/RequestStatus";
import {SlaStatus} from "../enums/SlaStatus";

export default interface Request {
    id: string;
    requestType: RequestType;
    description: string;
    ownerId: string;
    owner: User;
    client: User;
    clientId: string;
    sla: Sla;
    slaId: string;
    createdAt: Date;
    requestStatus: RequestStatus;
    slaStatus: SlaStatus;
    slaExpiredOn: Date;
    closedAt: Date;
}