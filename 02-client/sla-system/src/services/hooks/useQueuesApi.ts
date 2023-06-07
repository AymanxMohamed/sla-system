import {useAppDispatch} from "../../app/hooks";

import useAxios from "./useAxios";
import Result from "../types/Api/ApiResponses/Result";
import CreateQueueRequest from "../types/Api/ApiRequests/Queues/CreateQueueRequest";
import Queue from "../types/Api/Entities/Queue";
import {addQueue, setQueues} from "../reducers/queue";
import {AxiosResponse} from "axios";

const useQueueApi = () => {
    const dispatch = useAppDispatch();
    const axiosClient = useAxios();
    const controllerName =  "Queue";

    const getQueues = async (): Promise<Queue[]> => {

        try {
            const response: AxiosResponse<Result<Queue[]>> = await axiosClient.get(`/${controllerName}/GetQueues`);
            dispatch(setQueues(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const createQueue = async (payload: CreateQueueRequest) : Promise<Queue> => {
        try {
            const response: AxiosResponse<Result<Queue>> = await axiosClient.post(`${controllerName}/CreateQueue`,
                payload);
            dispatch(addQueue(response.data.value));
            return response.data.value;
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

export default useQueueApi;
