import React from "react";
import User from "../../../../services/types/Api/Entities/User";
import UserRow from "./UserRow";

const UserTable: React.FC<{ users: User[] }> = ({ users }) => {
    return (
        <table>
            <thead>
                <tr>
                    <th>User Name</th>
                    <th>Role</th>
                    <th>Zone</th>
                </tr>
            </thead>
            <tbody>
            {users.length > 0 && users.map((user) => (
                <UserRow
                    key={user.id}
                    user={user}
                />
            ))}
            </tbody>
        </table>
    );
};

export default UserTable;
