import React from "react";
import RequestRow from "./RequestRow";
import Request from "../../../../services/types/Api/Entities/Request";

const RequestTable: React.FC<{ requests: Request[], requestAssigned?: any }> = ({ requests, requestAssigned }) => {
    const handleRequestAssigned= () => {
        requestAssigned();
    }
    return (
        <table border={1}>
            <thead>
                <tr>
                    <th>Request Type</th>
                    <th>Description</th>
                    <th>Owner</th>
                    <th>Client</th>
                    <th>Sla</th>
                    <th>Created At</th>
                    <th>Request Status</th>
                    <th>Sla Status</th>
                    <th>Sla Expired on</th>
                    <th>Closed At</th>
                    <th>Actions</th>

                </tr>
            </thead>
            <tbody>
            {requests.length > 0 && requests.map((request) => (
                <RequestRow
                    key={request.id}
                    request={request}
                    requestAssigned={handleRequestAssigned}
                />
            ))}
            </tbody>
        </table>
    );
};

export default RequestTable;
