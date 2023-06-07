import useAuth from "../../services/hooks/useAuthSlice";
import {Navigate, Outlet, useLocation} from "react-router-dom";
import {Role} from "../../services/types/Api/enums/Role";

const RequireClient = () => {
    const {user} = useAuth();
    const location = useLocation();


    return user && user.role === Role.Client ? (
        <Outlet />
    ) : (
        <Navigate to={"/un-authorized"} state={{ from: location }} replace />
    );
}
export default RequireClient;
