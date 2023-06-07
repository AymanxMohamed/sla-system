import { Navigate, useLocation, useRoutes } from "react-router-dom";
import React, { useEffect } from "react";
import RequireClient from "../guards/RequireClient";
import ClientRequestsView from "../../views/pages/requests/views/ClientRequestsView";
import CreateRequestView from "../../views/pages/requests/views/CreateRequestView";
import useRequestApi from "../../services/hooks/useRequestApi";
import useAuth from "../../services/hooks/useAuthSlice";

export default function ClientRoute() {
    const location = useLocation();

    const requestsApi = useRequestApi();
    const { user } = useAuth();

    useEffect(() => {
        requestsApi.getClientRequests(user?.id).then();
    }, []);

    return useRoutes([
        {
            path: "/",
            element: <RequireClient />,
            children: [
                {
                    path: "",
                    element: <Navigate to={"requests"} state={{ from: location }} replace />,
                },
                { path: "requests", element: <ClientRequestsView /> },
                { path: "requests/create", element: <CreateRequestView /> },
                { path: "*", element: <Navigate to={"/404"} /> },
            ],
        },
    ]);
}
