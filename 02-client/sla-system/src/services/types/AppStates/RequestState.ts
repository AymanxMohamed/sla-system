import Request from "../Api/Entities/Request";

export default interface RequestState {
    ClientRequests: Request[];
    UserRequests: Request[];
}