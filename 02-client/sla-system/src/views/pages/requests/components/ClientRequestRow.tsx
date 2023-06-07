import React from "react";
import {formatDate, mapPropertyValueToEnumName} from "../../../../services/utils/appUtils";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import Request from "../../../../services/types/Api/Entities/Request";
import {RequestStatus} from "../../../../services/types/Api/enums/RequestStatus";

const ClientRequestRow: React.FC<{ request: Request }> = ({ request }): JSX.Element => {
    const requestType = mapPropertyValueToEnumName(RequestType, request.requestType);
    return (
        <tr>
            <td>{requestType}</td>
            <td>{request.description}</td>
            <td>{formatDate(request.createdAt)}</td>
            <td>{mapPropertyValueToEnumName(RequestStatus, request.requestStatus)}</td>
            <td>{formatDate(request.closedAt)}</td>
        </tr>
    );
};

export default ClientRequestRow;
