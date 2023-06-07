import {Link, NavLink, useNavigate} from "react-router-dom";
import { useAppDispatch } from "../../../app/hooks";
import useAuthSlice from "../../../services/hooks/useAuthSlice";
import { logout } from "../../../services/reducers/auth";
import {Role} from "../../../services/types/Api/enums/Role";


const navigation = [
    { name: 'Home', to: '/' },
]

const userNavigations = [
    ...navigation,
    { name: 'Requests', to: '/user/requests' },
]

const adminNavigation = [
    ...navigation,
    { name: 'Users', to: '/admin/users' },
    { name: 'Slas', to: '/admin/slas' },
    { name: 'Queues', to: '/admin/queues' },
]

const clientNavigation = [
    ...navigation,
    { name: 'My Requests', to: '/client/requests' },
]

const visitorNavigation = [
    ...navigation,
    { name: 'Login', to: '/auth/login' },
    { name: 'Register', to: '/auth/register' },
]
export default function Navbar() {
    const dispatch = useAppDispatch();
    const {user} = useAuthSlice();
    const logoutHandler = () => {
        dispatch(logout());
    };

    let authNavigation = visitorNavigation;
    if (user) {
        switch (user.role) {
            case Role.Admin:
                authNavigation = adminNavigation;
                break;
            case Role.User:
                authNavigation = userNavigations;
                break;
            case Role.Client:
                authNavigation = clientNavigation;
                break;
            default:
                authNavigation = visitorNavigation;
        }
    }

    return (
        <>
            {authNavigation.map((item: {name: string, to: string}) => (
                <NavLink
                    key={item.name}
                    to={item.to}
                >
                    {item.name}
                </NavLink>
            ))}
            {user &&
            <Link to="/auth/login" onClick={logoutHandler}>
                Logout
            </Link>}
        </>
    );
}