import { useAppSelector } from "../../app/hooks";

const useRequestSlice = () => {
    return useAppSelector(selector => selector.request);
}

export default  useRequestSlice;
