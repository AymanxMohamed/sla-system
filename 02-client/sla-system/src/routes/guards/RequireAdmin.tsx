import useAuth from "../../services/hooks/useAuthSlice";
import {Navigate, Outlet, useLocation} from "react-router-dom";
import {Role} from "../../services/types/Api/enums/Role";

const RequireAdmin = () => {
    const {user} = useAuth();
    const location = useLocation();
    console.log("called");


    return user && user.role === Role.Admin ? (
        <Outlet />
    ) : (
        <Navigate to={"/auth"} state={{ from: location }} replace />
    );
}
export default RequireAdmin;
