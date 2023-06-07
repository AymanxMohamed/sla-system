import {useAppDispatch} from "../../app/hooks";

import useAxios from "./useAxios";
import Result from "../types/Api/ApiResponses/Result";
import CreateQueueRequest from "../types/Api/ApiRequests/Queues/CreateQueueRequest";
import Queue from "../types/Api/Entities/Queue";
import {addQueue, setQueues} from "../reducers/queue";

const useAuthApi = () => {
    const dispatch = useAppDispatch();
    const axiosClient = useAxios();
    const controllerName =  "Queue";

    const getQueues = async (): Promise<Queue[]> => {

        try {
            const response = await axiosClient.get(`/${controllerName}/GetQueues`);
            let result = response.data as Result<Queue[]>;
            dispatch(setQueues(result.value));
            return result.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const createQueue = async (payload: CreateQueueRequest) => {
        try {
            const response = await axiosClient.post(`${controllerName}/CreateQueue`,
                payload);

            dispatch(addQueue(response.data.value));
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
