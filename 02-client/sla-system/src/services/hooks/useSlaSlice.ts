import { useAppSelector } from "../../app/hooks";

const useSlaSlice = () => {
    return useAppSelector(selector => selector.sla);
}

export default  useSlaSlice;
