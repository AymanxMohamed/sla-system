import {useAppDispatch} from "../../app/hooks";

import useAxios from "./useAxios";
import Result from "../types/Api/ApiResponses/Result";
import { AxiosResponse } from "axios";
import {Role} from "../types/Api/enums/Role";
import User from "../types/Api/Entities/User";
import {adduser, setUsers} from "../reducers/user";
import CreateUserRequest from "../types/Api/ApiRequests/Users/CreateUserRequest";

const useUserApi = () => {
    const dispatch = useAppDispatch();
    const axiosClient = useAxios();
    const controllerName =  "User";

    const getUsers = async (): Promise<User[]> => {

        try {
            const response: AxiosResponse<Result<User[]>> =
                await axiosClient.get(`/${controllerName}/GetUsers/${Role.User}`);
            dispatch(setUsers(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw err.response.data;
        }
    };

    const createUser = async (payload: CreateUserRequest): Promise<User> => {
        try {
            const response: AxiosResponse<Result<User>> = await axiosClient.post(`${controllerName}/CreateUser`,
                payload);
            dispatch(adduser(response.data.value));
            return response.data.value;
        } catch (err: any) {
            if (err.message === "Network Error") {
                throw new Error("Server is Offline Now");
            }
            throw new Error(err.response.data.message);
        }
    };
    return {
        getUsers,
        createUser,
    };
};

export default useUserApi;
