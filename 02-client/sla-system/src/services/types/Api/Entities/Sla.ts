import {RequestType} from "../enums/RequestType";
import {Severity} from "../enums/Severity";

export default interface Sla {
    id: string;
    requestType: RequestType;
    severity: Severity;
    durationInHours: number;
}