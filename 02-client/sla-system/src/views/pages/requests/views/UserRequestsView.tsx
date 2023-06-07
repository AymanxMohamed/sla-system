import React, { useEffect, useState} from "react";
import useRequestApi from "../../../../services/hooks/useRequestApi";
import Request from "../../../../services/types/Api/Entities/Request";
import useAuth from "../../../../services/hooks/useAuthSlice";
import RequestTable from "../components/RequestTable";
import {NavLink} from "react-router-dom";

const UserRequestsView: React.FC = () => {
    const [requests, setStateRequests] = useState<Request[]>([]);
    const requestsApi = useRequestApi();
    const { user } = useAuth();

    useEffect(() => {
        requestsApi.getRequestsForQueue(user?.queueId).then(requestsArr => {
            setStateRequests(requestsArr);
        })
    }, []);

    const handleRequestAssigned = () => {
        requestsApi.getRequestsForQueue(user?.queueId).then(requestsArr => {
            setStateRequests(requestsArr);
        })
    }

    return (
        <>
            <NavLink to={"/user/requests/my-requests"}>My Request</NavLink>
            <RequestTable requests={requests} requestAssigned={handleRequestAssigned} />
        </>
    );
};

export default UserRequestsView;
