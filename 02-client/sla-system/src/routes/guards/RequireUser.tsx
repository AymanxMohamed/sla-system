import useAuth from "../../services/hooks/useAuthSlice";
import {Navigate, Outlet, useLocation} from "react-router-dom";
import {Role} from "../../services/types/Api/enums/Role";

const RequireUser = () => {
    const {user} = useAuth();
    const location = useLocation();


    return user && user.role === Role.User ? (
        <Outlet />
    ) : (
        <Navigate to={"/un-authorized"} state={{ from: location }} replace />
    );
}
export default RequireUser;
