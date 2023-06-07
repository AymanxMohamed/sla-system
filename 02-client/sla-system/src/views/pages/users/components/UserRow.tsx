import React from "react";
import User from "../../../../services/types/Api/Entities/User";

const UserRow: React.FC<{ user: User }> = ({ user }): JSX.Element => {
    return (
       <tr>
           <td>{user.userName}</td>
           <td>{user.role}</td>
           <td>{user.zone}</td>
       </tr>
    );
};

export default UserRow;
