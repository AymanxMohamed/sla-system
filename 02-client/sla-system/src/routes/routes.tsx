import {Navigate, Route, Routes, useLocation} from "react-router-dom";
import PageNotFoundView from "../views/pages/errors/views/PageNotFoundView";
import MainLayout from "../views/common/layouts/MainLayout";
import RequireAuth from "./guards/RequireAuth";
import RequireAdmin from "./guards/RequireAdmin";
import RequireUser from "./guards/RequireUser";
import AuthRoute from "./public/AuthRoute";
import LoginView from "../views/pages/authentication/views/LoginView";
import HomePage from "../views/pages/home";


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

                    {/* Client Routes */}

                    <Route element={<RequireAdmin />}>
                        {/*  Admin Routes  */}
                    </Route>

                    <Route element={<RequireUser />}>
                        {/*  User Routes  */}
                    </Route>
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