import React from "react";
import {formatDate, mapPropertyValueToEnumName} from "../../../../services/utils/appUtils";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import Request from "../../../../services/types/Api/Entities/Request";
import {SlaStatus} from "../../../../services/types/Api/enums/SlaStatus";
import {RequestStatus} from "../../../../services/types/Api/enums/RequestStatus";

const RequestClose: React.FC = (): JSX.Element => {
    // const requestType = mapPropertyValueToEnumName(RequestType, request.requestType);
    return (
        <>
            <p>This is the request close view</p>
                {/*<p>Request Type: {requestType}</p>*/}
                {/*<p>Description: {request.description}</p>*/}
                {/*<p>{request.owner.userName}</p>*/}
                {/*<p>{request.client.userName}</p>*/}
                {/*<p>{requestType} Sla</p>*/}
                {/*<p>{formatDate(request.createdAt)}</p>*/}
                {/*<p>{mapPropertyValueToEnumName(RequestStatus, request.requestStatus)}</p>*/}
                {/*<p>{mapPropertyValueToEnumName(SlaStatus, request.slaStatus)}</p>*/}
                {/*<p>{formatDate(request.slaExpiredOn)}</p>*/}
                {/*<p>{formatDate(request.closedAt)}</p>*/}
        </>
    );
};

export default RequestClose;
