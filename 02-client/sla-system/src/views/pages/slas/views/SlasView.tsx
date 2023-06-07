import React, { useEffect, useState} from "react";
import SlasTable from "../components/SlasTable";
import Sla from "../../../../services/types/Api/Entities/Sla";
import useSlaApi from "../../../../services/hooks/useSlasApi";

const SlasView: React.FC = () => {
    const [slas, setStateSlas] = useState<Sla[]>([]);
    const slasApi = useSlaApi();

    useEffect(() => {
        slasApi.getSlas().then(slaArr => {
            setStateSlas(slaArr);
        })
    }, []);

    console.log(slas);

    return (
      <>
          <SlasTable slas={slas} />
      </>
    );
};

export default SlasView;
