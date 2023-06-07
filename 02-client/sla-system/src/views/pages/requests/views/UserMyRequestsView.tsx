import React, { useEffect, useState} from "react";
import { NavLink } from "react-router-dom";
import useRequestApi from "../../../../services/hooks/useRequestApi";
import Request from "../../../../services/types/Api/Entities/Request";
import useAuth from "../../../../services/hooks/useAuthSlice";
import RequestTable from "../components/RequestTable";
import {setClientRequests, setUserRequests} from "../../../../services/reducers/request";
import {useAppDispatch} from "../../../../app/hooks";

const UserMyRequestsView: React.FC = () => {
    const [requests, setRequests] = useState<Request[]>([]);
    const requestsApi = useRequestApi();
    const { user } = useAuth();
    const dispatch = useAppDispatch();

    useEffect(() => {
        requestsApi.getUserRequests(user?.id).then(requests => {
            setRequests(requests);
            dispatch(setUserRequests(requests));
        })
    }, [requestsApi, user, dispatch]);

    return (
        <>
            <RequestTable requests={requests} />
        </>
    );
};

export default UserMyRequestsView;
