import React from "react";
import RequestRow from "./RequestRow";
import Request from "../../../../services/types/Api/Entities/Request";
import ClientRequestRow from "./ClientRequestRow";

const ClientRequestTable: React.FC<{ requests: Request[] }> = ({ requests }) => {
    return (
        <table border={1}>
            <thead>
                <tr>
                    <th>Request Type</th>
                    <th>Description</th>
                    <th>Created At</th>
                    <th>Request Status</th>
                    <th>Closed At</th>
                </tr>
            </thead>
            <tbody>
            {requests.length > 0 && requests.map((request) => (
                <ClientRequestRow
                    key={request.id}
                    request={request}
                />
            ))}
            </tbody>
        </table>
    );
};

export default ClientRequestTable;
