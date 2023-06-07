import {useAppDispatch} from "../../app/hooks";

import useAxios from "./useAxios";
import {setUser} from "../reducers/auth";
import User from "../types/Api/Entities/User";
import RegisterRequest from "../types/Api/ApiRequests/Auth/RegisterRequest";
import Result from "../types/Api/ApiResponses/Result";
import LoginRequest from "../types/Api/ApiRequests/Auth/LoginRequest";

const useAuthApi = () => {
    const dispatch = useAppDispatch();
    const axiosClient = useAxios();

    const register = async (registerRequest: RegisterRequest): Promise<Result<User>> => {

        try {
            const response = await axiosClient.post("/Register", registerRequest);
            return response.data as Result<User>;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const login = async (loginRequest: LoginRequest, checked: any) => {
        try {
            const response = await axiosClient.post("users/login", loginRequest);
            if (checked.length) {
                localStorage.setItem("userData", JSON.stringify(response.data.user));
            } else {
                sessionStorage.setItem("userData", JSON.stringify(response.data.user));
            }
            dispatch(setUser(response.data.user));
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
