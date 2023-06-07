import Queue from "../../../../services/types/Api/Entities/Queue";
import React, { useEffect, useState} from "react";
import useQueuesApi from "../../../../services/hooks/useQueuesApi";
import QueuesTable from "../components/QueuesTable";
import { NavLink } from "react-router-dom";

const QueuesView: React.FC = () => {
    const [queues, setQueues] = useState<Queue[]>([]);
    const queuesApi = useQueuesApi();

    useEffect(() => {
        queuesApi.getQueues().then(queues => {
            setQueues(queues);
        })
    }, [queuesApi]);

    return (
      <>
          <NavLink to={"/admin/queues/create"}>Create Queue</NavLink>
          <QueuesTable queues={queues} />
      </>
    );
};

export default QueuesView;
