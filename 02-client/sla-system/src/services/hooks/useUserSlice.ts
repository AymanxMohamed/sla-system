import { useAppSelector } from "../../app/hooks";

const useUserSlice = () => {
    return useAppSelector(selector => selector.user);
}

export default  useUserSlice;
