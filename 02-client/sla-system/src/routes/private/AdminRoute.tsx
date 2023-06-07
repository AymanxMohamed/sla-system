import { Navigate, useLocation, useRoutes } from "react-router-dom";
import React from "react";
import RequireAdmin from "../guards/RequireAdmin";
import QueuesView from "../../views/pages/queues/views/QueuesView";
import SlasView from "../../views/pages/slas/views/SlasView";
import UsersView from "../../views/pages/users/views/UsersView";
import CreateUserView from "../../views/pages/users/views/CreateUserView";
import CreateQueueView from "../../views/pages/queues/views/CreateQueueView";
import CreateSlaView from "../../views/pages/slas/views/CreateSlaView";

export default function AdminRoute() {
    const location = useLocation();
    return useRoutes([
        {
            path: "/",
            element: <RequireAdmin />,
            children: [
                {
                    path: "",
                    element: <Navigate to={"users"} state={{ from: location }} replace />,
                },
                { path: "users", element: <UsersView /> },
                { path: "users/create", element: <CreateUserView /> },
                { path: "queues", element: <QueuesView /> },
                { path: "queues/create", element: <CreateQueueView /> },
                { path: "slas", element: <SlasView /> },
                { path: "slas/create", element: <CreateSlaView /> },
                { path: "*", element: <Navigate to={"/404"} /> },
            ],
        },
    ]);
}
