import React from "react";
import {formatDate, mapPropertyValueToEnumName} from "../../../../services/utils/appUtils";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import Request from "../../../../services/types/Api/Entities/Request";
import {SlaStatus} from "../../../../services/types/Api/enums/SlaStatus";
import {RequestStatus} from "../../../../services/types/Api/enums/RequestStatus";
import useRequestApi from "../../../../services/hooks/useRequestApi";
import useAuthSlice from "../../../../services/hooks/useAuthSlice";
import AssignRequestPayload from "../../../../services/types/Api/ApiRequests/Requests/AssignRequestPayload";
import {NavLink} from "react-router-dom";

const RequestRow: React.FC<{ request: Request, requestAssigned: any }> = ({ request, requestAssigned }): JSX.Element => {
    const requestType = mapPropertyValueToEnumName(RequestType, request.requestType);
    const requestApi = useRequestApi();
    const { user } = useAuthSlice();

    const handlePick = () => {
        let assignPayload: AssignRequestPayload = {
            RequestId: request.id,
            OwnerId: user?.id || ""
        }

        requestApi.assignRequest(assignPayload).then(req => {
            requestAssigned();
        });
    }

    return (
        <tr>
            <td>{requestType}</td>
            <td>{request.description}</td>
            <td>{request.owner?.userName}</td>
            <td>{request.client.userName}</td>
            <td>{requestType} Sla</td>
            <td>{formatDate(request.createdAt)}</td>
            <td>{mapPropertyValueToEnumName(RequestStatus, request.requestStatus)}</td>
            <td>{mapPropertyValueToEnumName(SlaStatus, request.slaStatus)}</td>
            <td>{formatDate(request.slaExpiredOn)}</td>
            <td>{formatDate(request.closedAt)}</td>
            { request.ownerId === '00000000-0000-0000-0000-000000000000' ?
                (
                    <button onClick={handlePick} >Pick</button>
                ) : request.requestStatus === RequestStatus.Active &&(
                     ( <NavLink key={request.id}  to={`${request.id}/close`}>
                        Handle
                    </NavLink>)
                )
            }
        </tr>
    );
};

export default RequestRow;
