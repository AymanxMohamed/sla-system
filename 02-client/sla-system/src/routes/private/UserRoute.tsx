import { Navigate, useLocation, useRoutes } from "react-router-dom";
import React from "react";
import RequireUser from "../guards/RequireUser";
import UserMyRequestsView from "../../views/pages/requests/views/UserMyRequestsView";
import UserRequestsView from "../../views/pages/requests/views/UserRequestsView";
import RequestClose from "../../views/pages/requests/components/RequestClose";
import CloseRequestView from "../../views/pages/requests/views/CloseRequestView";

export default function UserRoute() {
    const location = useLocation();
    return useRoutes([
        {
            path: "/",
            element: <RequireUser />,
            children: [
                {
                    path: "",
                    element: <Navigate to={"my-requests"} state={{ from: location }} replace />,
                },
                { path: "requests", element: <UserRequestsView /> },
                { path: "requests/my-requests", element: <UserMyRequestsView /> },
                { path: "requests/:id/close", element: <CloseRequestView /> },
                { path: "*", element: <Navigate to={"/404"} /> },
            ],
        },
    ]);
}
