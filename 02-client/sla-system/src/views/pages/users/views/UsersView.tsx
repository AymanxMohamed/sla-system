import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import UsersTable from "../components/UsersTable";
import useUserApi from "../../../../services/hooks/useUserApi";
import User from "../../../../services/types/Api/Entities/User";
import useUserSlice from "../../../../services/hooks/useUserSlice";

const UsersView: React.FC = () => {
    const [users, setStateUsers] = useState<User[]>([]);
    const usersApi = useUserApi();

    useEffect(() => {
        usersApi.getUsers().then(usersArr => {
            setStateUsers(usersArr);
        });
    }, []);


    return (
      <>
          <NavLink to={"/admin/users/create"}>Create Users</NavLink>
          <UsersTable users={users} />
      </>
    );
};

export default UsersView;
