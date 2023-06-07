import React, { useEffect, useState} from "react";
import { NavLink } from "react-router-dom";
import {useAppDispatch} from "../../../../app/hooks";
import UsersTable from "../components/UsersTable";
import useUserApi from "../../../../services/hooks/useUserApi";
import {setUsers} from "../../../../services/reducers/user";
import User from "../../../../services/types/Api/Entities/User";

const UsersView: React.FC = () => {
    const [users, setStateUsers] = useState<User[]>([]);
    const usersApi = useUserApi();
    const dispatch = useAppDispatch();

    useEffect(() => {
        usersApi.getUsers().then(queues => {
            setStateUsers(users);
            dispatch(setUsers(users));
        })
    }, [usersApi, dispatch, users]);

    return (
      <>
          <NavLink to={"/admin/slas/create"}>Create Sla</NavLink>
          <UsersTable users={users} />
      </>
    );
};

export default UsersView;
