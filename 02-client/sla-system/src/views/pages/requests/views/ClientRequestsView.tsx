import React from "react";
import { NavLink } from "react-router-dom";

import ClientRequestTable from "../components/ClientRequestTable";
import useRequestSlice from "../../../../services/hooks/useRequestSlice";

const ClientRequestsView: React.FC = () => {
    const { ClientRequests } = useRequestSlice();

    return (
        <>
            <NavLink to={"/client/requests/create"}>Create Request</NavLink>
            <ClientRequestTable requests={ClientRequests} />
        </>
    );
};

export default ClientRequestsView;
