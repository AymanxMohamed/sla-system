import React from "react";
import {mapPropertyValueToEnumName} from "../../../../services/utils/appUtils";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import Sla from "../../../../services/types/Api/Entities/Sla";

const QueueRow: React.FC<{ sla: Sla }> = ({ sla }): JSX.Element => {
    return (
       <tr>
           <td>{mapPropertyValueToEnumName(RequestType, sla.requestType)}</td>
           <td>{mapPropertyValueToEnumName(RequestType, sla.severity)}</td>
           <td>{sla.durationInHours}</td>
       </tr>
    );
};

export default QueueRow;
