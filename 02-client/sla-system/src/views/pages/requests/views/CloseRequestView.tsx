import React, {useEffect, useState} from "react";
import {formatDate, mapPropertyValueToEnumName} from "../../../../services/utils/appUtils";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import Request from "../../../../services/types/Api/Entities/Request";
import {SlaStatus} from "../../../../services/types/Api/enums/SlaStatus";
import {RequestStatus} from "../../../../services/types/Api/enums/RequestStatus";
import useRequestApi from "../../../../services/hooks/useRequestApi";
import {useNavigate, useParams} from "react-router-dom";
import CountdownTimer from "../components/CountDownTimer";

const CloseRequestView: React.FC = () => {
    const { id } = useParams();
    const [request, setRequest] = useState<Request>();
    const [requestType, setRequestType] =
        useState<"Invoice" | "Payment">();
    const requestsApi = useRequestApi();
    const navigate = useNavigate();

    useEffect(() => {
        requestsApi.getRequest(id).then(req => {
            setRequest(req);
            setRequestType(mapPropertyValueToEnumName(RequestType, req.requestType));
        })
    }, []);

    const handleClose = () =>  {
        requestsApi.closeRequest(request?.id).then(() => {
            navigate('/user/requests')
        });
    }


    return request ? (
        <>
            <div>
                <p>Request Type: {requestType}</p>
                <p>Request Description: {request.description}</p>
                <p>Client: {request.client.userName}</p>
                <p>Sla: {requestType} Sla</p>
                <p>Created At: {formatDate(request.createdAt)}</p>
                <p>Request Status: {mapPropertyValueToEnumName(RequestStatus, request.requestStatus)}</p>
                <p>Sla Status: {mapPropertyValueToEnumName(SlaStatus, request.slaStatus)}</p>
                <p>Sla Expired On: {formatDate(request.slaExpiredOn)}</p>
            </div>
            <CountdownTimer slaExpiredOn={request.slaExpiredOn} />
            <button onClick={handleClose}>Close</button>

        </>
    ) : (
        <></>
    );
};

export default CloseRequestView;
