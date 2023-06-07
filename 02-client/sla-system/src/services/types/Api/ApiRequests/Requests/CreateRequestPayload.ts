import {RequestType} from "../../enums/RequestType";

export default interface CreateRequestPayload {
    RequestType: RequestType;
    Description: string;
    ClientId: string;
}