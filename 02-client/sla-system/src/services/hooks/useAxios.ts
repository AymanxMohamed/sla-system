import axiosInstance from "../../app/axiosClient";

const useAxios = () => {
    axiosInstance.interceptors.request.use(async (req: any) => {

        return req;
    });
    return axiosInstance;
};

export default useAxios;
