import { Navigate, useLocation, useRoutes } from "react-router-dom";
import React from "react";
import RequireClient from "../guards/RequireClient";
import ClientRequestsView from "../../views/pages/requests/views/ClientRequestsView";
import CreateRequestView from "../../views/pages/requests/views/CreateRequestView";

export default function ClientRoute() {
    const location = useLocation();
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
