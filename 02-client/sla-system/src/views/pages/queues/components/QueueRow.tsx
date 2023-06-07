import Queue from "../../../../services/types/Api/Entities/Queue";
import React from "react";
import {mapPropertyValueToEnumName} from "../../../../services/utils/appUtils";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";

const QueueRow: React.FC<{ queue: Queue }> = ({ queue }): JSX.Element => {
    return (
       <tr>
           <td>{queue.queueName}</td>
           <td>{mapPropertyValueToEnumName(RequestType, queue.requestType)}</td>
       </tr>
    );
};

export default QueueRow;
