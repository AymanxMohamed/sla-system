import React, { useEffect, useState} from "react";
import useRequestApi from "../../../../services/hooks/useRequestApi";
import Request from "../../../../services/types/Api/Entities/Request";
import useAuth from "../../../../services/hooks/useAuthSlice";
import RequestTable from "../components/RequestTable";

const UserMyRequestsView: React.FC = () => {
    const [requests, setRequests] = useState<Request[]>([]);
    const requestsApi = useRequestApi();
    const { user } = useAuth();

    useEffect(() => {
        requestsApi.getUserRequests(user?.id).then(requestsArr => {
            setRequests(requestsArr);
        })
    }, []);

    return (
        <>
            <RequestTable requests={requests} />
        </>
    );
};

export default UserMyRequestsView;
