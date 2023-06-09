import {useAppDispatch} from "../../app/hooks";

import useAxios from "./useAxios";
import {setUser} from "../reducers/auth";
import User from "../types/Api/Entities/User";
import RegisterRequest from "../types/Api/ApiRequests/Auth/RegisterRequest";
import Result from "../types/Api/ApiResponses/Result";
import LoginRequest from "../types/Api/ApiRequests/Auth/LoginRequest";
import {AxiosResponse} from "axios";

const useAuthApi = () => {
    const dispatch = useAppDispatch();
    const axiosClient = useAxios();
    const controllerName =  "Auth";
    const register = async (payload: RegisterRequest): Promise<User> => {

        try {
            const response: AxiosResponse<Result<User>> = await axiosClient.post(`/${controllerName}/Register`,
                payload);
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const login = async (payload: LoginRequest, checked: []): Promise<User> => {
        try {
            const response: AxiosResponse<Result<User>> = await axiosClient.post(`${controllerName}/Login`, payload);
            if (checked.length) {
                localStorage.setItem("userData", JSON.stringify(response.data.value));
            } else {
                sessionStorage.setItem("userData", JSON.stringify(response.data.value));
            }
            dispatch(setUser(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw new Error(err.response.data.message);
        }
    };
    return {
        login,
        register,
    };
};

export default useAuthApi;
