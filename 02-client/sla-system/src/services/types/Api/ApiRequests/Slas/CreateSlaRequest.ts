import {RequestType} from "../../enums/RequestType";
import {Severity} from "../../enums/Severity";

export default interface CreateSlaRequest {
    RequestType: RequestType;
    Severity: Severity;
    DurationInHours: Date;
}