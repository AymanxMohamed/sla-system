import {useAppDispatch} from "../../app/hooks";

import useAxios from "./useAxios";
import {setUser} from "../reducers/auth";
import Result from "../types/Api/ApiResponses/Result";
import CreateQueueRequest from "../types/Api/ApiRequests/Queues/CreateQueueRequest";
import Queue from "../types/Api/Entities/Queue";

const useAuthApi = () => {
    const dispatch = useAppDispatch();
    const axiosClient = useAxios();
    const controllerName =  "Queue";

    const getQueues = async (): Promise<Result<Queue[]>> => {

        try {
            const response = await axiosClient.get(`/${controllerName}/GetQueues`);
            return response.data as Result<Queue[]>;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const createQueue = async (payload: CreateQueueRequest, checked: any) => {
        try {
            const response = await axiosClient.post(`${controllerName}/CreateQueue`,
                payload);

            dispatch(set(response.data.value));
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw new Error(err.response.data.message);
        }
    };
    return {
        getQueues,
        createQueue,
    };
};

export default useAuthApi;
