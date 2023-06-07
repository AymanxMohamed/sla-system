import React, { useEffect, useState} from "react";
import { NavLink } from "react-router-dom";
import useRequestApi from "../../../../services/hooks/useRequestApi";
import Request from "../../../../services/types/Api/Entities/Request";
import useAuth from "../../../../services/hooks/useAuthSlice";
import RequestTable from "../components/RequestTable";
import {useAppDispatch} from "../../../../app/hooks";
import {setClientRequests} from "../../../../services/reducers/request";

const ClientRequestsView: React.FC = () => {
    const [requests, setRequests] = useState<Request[]>([]);
    const requestsApi = useRequestApi();
    const { user } = useAuth();
    const dispatch = useAppDispatch();

    useEffect(() => {
        requestsApi.getClientRequests(user?.id).then(requests => {
            setRequests(requests);
            dispatch(setClientRequests(requests));
        })
    }, [requestsApi, user, dispatch]);

    return (
        <>
            <NavLink to={"/client/requests/create"}>Create Request</NavLink>
            <RequestTable requests={requests} />
        </>
    );
};

export default ClientRequestsView;
