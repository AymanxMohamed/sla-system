import React from "react";
import {mapPropertyValueToEnumName} from "../../../../services/utils/appUtils";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import Sla from "../../../../services/types/Api/Entities/Sla";
import {Severity} from "../../../../services/types/Api/enums/Severity";

const QueueRow: React.FC<{ sla: Sla }> = ({ sla }): JSX.Element => {
    return (
       <tr>
           <td>{mapPropertyValueToEnumName(RequestType, sla.requestType)}</td>
           <td>{mapPropertyValueToEnumName(Severity, sla.severity)}</td>
           <td>{sla.durationInHours}</td>
       </tr>
    );
};

export default QueueRow;
