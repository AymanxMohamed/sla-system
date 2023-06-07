import { useAppSelector } from "../../app/hooks";

const useAuthSlice = () => {
    return useAppSelector(selector => selector.auth);
}

export default  useAuthSlice;
