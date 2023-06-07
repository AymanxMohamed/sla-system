import React, { useEffect, useState} from "react";
import useRequestApi from "../../../../services/hooks/useRequestApi";
import Request from "../../../../services/types/Api/Entities/Request";
import useAuth from "../../../../services/hooks/useAuthSlice";
import RequestTable from "../components/RequestTable";
import {setTypeRequests} from "../../../../services/reducers/request";
import {useAppDispatch} from "../../../../app/hooks";
import {NavLink} from "react-router-dom";

const UserRequestsView: React.FC = () => {
    const [requests, setStateRequests] = useState<Request[]>([]);
    const requestsApi = useRequestApi();
    const { user } = useAuth();
    const dispatch = useAppDispatch();

    useEffect(() => {
        requestsApi.getUserRequests(user?.id).then(requests => {
            setStateRequests(requests);
            dispatch(setTypeRequests(requests));
        })
    }, [requestsApi, user, dispatch]);

    return (
        <>
            <NavLink to={"/user/requests/my-requests"}>My Request</NavLink>
            <RequestTable requests={requests} />
        </>
    );
};

export default UserRequestsView;
