import Queue from "../../../../services/types/Api/Entities/Queue";
import React from "react";
import {formatDate, mapPropertyValueToEnumName} from "../../../../services/utils/appUtils";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import Request from "../../../../services/types/Api/Entities/Request";
import {SlaStatus} from "../../../../services/types/Api/enums/SlaStatus";
import {RequestStatus} from "../../../../services/types/Api/enums/RequestStatus";

const RequestRow: React.FC<{ request: Request }> = ({ request }): JSX.Element => {
    const requestType = mapPropertyValueToEnumName(RequestType, request.requestType);
    return (
        <tr>
            <td>{requestType}</td>
            <td>{request.description}</td>
            <td>{request.owner.userName}</td>
            <td>{request.client.userName}</td>
            <td>{requestType} Sla</td>
            <td>{formatDate(request.createdAt)}</td>
            <td>{mapPropertyValueToEnumName(RequestStatus, request.requestStatus)}</td>
            <td>{mapPropertyValueToEnumName(SlaStatus, request.slaStatus)}</td>
            <td>{formatDate(request.slaExpiredOn)}</td>
            <td>{formatDate(request.closedAt)}</td>
        </tr>
    );
};

export default RequestRow;
