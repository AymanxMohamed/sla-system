import React from 'react';
import useAuth from "../../../services/hooks/useAuthSlice";
import {Navigate, useLocation} from "react-router-dom";
import { Role } from '../../../services/types/Api/enums/Role';

const HomePage: React.FC = (): JSX.Element => {
    const { user } = useAuth();
    const location = useLocation();
    console.log(user);
    let navigateTo;
    if (user) {
        switch (user.role) {
            case Role.Admin:
                navigateTo = "/admin/users";
                break;
            case Role.User:
                navigateTo = "/user/requests";
                break;
            case Role.Client:
                navigateTo = "/client/requests";
                break;
            default:
                navigateTo = "/auth/login";
        }
    } else
        navigateTo = "/auth/login";

    return  <Navigate to={navigateTo} state={{ from: location }} replace />
};

export default HomePage;
