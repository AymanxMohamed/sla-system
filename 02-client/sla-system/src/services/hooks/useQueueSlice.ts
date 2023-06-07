import { useAppSelector } from "../../app/hooks";

const useQueueSlice = () => {
    return useAppSelector(selector => selector.sla);
}

export default  useQueueSlice;
