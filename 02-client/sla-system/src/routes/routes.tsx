import {Navigate, Route, Routes, useLocation} from "react-router-dom";
import PageNotFoundView from "../views/pages/errors/views/PageNotFoundView";
import MainLayout from "../views/common/layouts/MainLayout";
import RequireAuth from "./guards/RequireAuth";
import AuthRoute from "./public/AuthRoute";
import HomePage from "../views/pages/home";
import ClientRoute from "./private/ClientRoute";
import AdminRoute from "./private/AdminRoute";
import UserRoute from "./private/UserRoute";
import React from "react";


const AppRoutes: React.FC = (): JSX.Element => {
    const location = useLocation();
    return(
        <Routes>
            <Route element={<MainLayout />}>
                {/* Public Routes */}
                <Route path="/" element={<HomePage />} />
                <Route path="auth/*" element={<AuthRoute />} />
                {/* Protected Routes */}
                <Route element={<RequireAuth />}>
                    <Route path="client/*" element={<ClientRoute />} />
                    <Route path="admin/*" element={<AdminRoute />} />
                    <Route path="user/*" element={<UserRoute />} />
                </Route>
            </Route>
            <Route path="404" element={<PageNotFoundView /> }/>
            <Route path="un-authorized" element={<PageNotFoundView /> }/>
            <Route
                path="*"
                element={ <Navigate to={"404"} state={{ from: location }} replace /> }
            >
            </Route>
        </Routes>
    )
}
export default AppRoutes;