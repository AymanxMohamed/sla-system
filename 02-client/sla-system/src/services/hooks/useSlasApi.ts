import {useAppDispatch} from "../../app/hooks";

import useAxios from "./useAxios";
import Result from "../types/Api/ApiResponses/Result";
import Sla from "../types/Api/Entities/Sla";
import CreateSlaRequest from "../types/Api/ApiRequests/Slas/CreateSlaRequest";
import { AxiosResponse } from "axios";
import {addSla, setSlas} from "../reducers/sla";

const useSlaApi = () => {
    const dispatch = useAppDispatch();
    const axiosClient = useAxios();
    const controllerName =  "SLA";

    const getSlas = async (): Promise<Sla[]> => {

        try {
            const response: AxiosResponse<Result<Sla[]>> = await axiosClient.get(`/${controllerName}/GetSlas`);
            console.log(response.data.value);
            dispatch(setSlas(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const createSla = async (payload: CreateSlaRequest): Promise<Sla> => {
        try {
            const response: AxiosResponse<Result<Sla>> = await axiosClient.post(`${controllerName}/CreateSla`,
                payload);
            dispatch(addSla(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw new Error(err.response.data.message);
        }
    };
    return {
        getSlas,
        createSla,
    };
};

export default useSlaApi;
