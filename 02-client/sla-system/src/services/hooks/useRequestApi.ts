import {useAppDispatch} from "../../app/hooks";

import useAxios from "./useAxios";
import Result from "../types/Api/ApiResponses/Result";
import { AxiosResponse } from "axios";
import EmptyResult from "../types/Api/ApiResponses/EmptyResult"
import {addRequest, setClientRequests, setUserRequests, updateRequest} from "../reducers/request";
import Request from "../types/Api/Entities/Request";
import CreateRequestPayload from "../types/Api/ApiRequests/Requests/CreateRequestPayload";
import AssignRequestPayload from "../types/Api/ApiRequests/Requests/AssignRequestPayload";

const useRequestApi = () => {
    const dispatch = useAppDispatch();
    const axiosClient = useAxios();
    const controllerName =  "Request";

    const getClientRequests = async (clientId: string | undefined): Promise<Request[]> => {

        try {
            const response: AxiosResponse<Result<Request[]>> =
                await axiosClient.get(`/${controllerName}/GetClientRequests/${clientId}`);
            dispatch(setClientRequests(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const getUserRequests = async (userId: string | undefined): Promise<Request[]> => {

        try {
            const response: AxiosResponse<Result<Request[]>> =
                await axiosClient.get(`/${controllerName}/GetUserRequests/${userId}`);
            dispatch(setUserRequests(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const getRequest = async (requestId: string): Promise<Request> => {

        try {
            const response: AxiosResponse<Result<Request>> =
                await axiosClient.get(`/${controllerName}/GetRequest/${requestId}`);
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const createRequest = async (payload: CreateRequestPayload): Promise<Request> => {
        try {
            const response: AxiosResponse<Result<Request>> =
                await axiosClient.post(`${controllerName}/CreateRequest`, payload);
            dispatch(addRequest(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw new Error(err.response.data.message);
        }
    };

    const closeRequest = async (requestId: string): Promise<Request | null> => {
        try {
            const response: AxiosResponse<EmptyResult> =
                await axiosClient.patch(`${controllerName}/CloseRequest/${requestId}`);
            let request: Request | null = null;
            if (response.data.isSuccess) {
                request= await getRequest(requestId);
                dispatch(updateRequest(request));
            }
            return request;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw new Error(err.response.data.message);
        }
    };

    const assignRequest = async (payload: AssignRequestPayload): Promise<Request | null> => {
        try {
            const response: AxiosResponse<EmptyResult> =
                await axiosClient.patch(`${controllerName}/AssignRequest`, payload);
            let request: Request | null = null;
            if (response.data.isSuccess) {
                request= await getRequest(payload.RequestId);
                dispatch(updateRequest(request));
            }
            return request;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw new Error(err.response.data.message);
        }
    };

    return {
        getClientRequests,
        getUserRequests,
        getRequest,
        createRequest,
        closeRequest,
        assignRequest
    };
};

export default useRequestApi;
