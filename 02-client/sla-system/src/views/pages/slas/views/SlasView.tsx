import React, { useEffect, useState} from "react";
import { NavLink } from "react-router-dom";
import SlasTable from "../components/SlasTable";
import Sla from "../../../../services/types/Api/Entities/Sla";
import {useAppDispatch} from "../../../../app/hooks";
import { setSlas } from "../../../../services/reducers/sla";
import useSlaApi from "../../../../services/hooks/useSlasApi";

const SlasView: React.FC = () => {
    const [slas, setStateSlas] = useState<Sla[]>([]);
    const slasApi = useSlaApi();
    const dispatch = useAppDispatch();

    useEffect(() => {
        slasApi.getSlas().then(queues => {
            setStateSlas(slas);
            dispatch(setSlas(slas));
        })
    }, [slasApi, dispatch, slas]);

    return (
      <>
          <NavLink to={"/admin/slas/create"}>Create Sla</NavLink>
          <SlasTable slas={slas} />
      </>
    );
};

export default SlasView;
