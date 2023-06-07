import React from "react";
import Sla from "../../../../services/types/Api/Entities/Sla";
import SlaRow from "./SlaRow";

const QueueTable: React.FC<{ slas: Sla[] }> = ({ slas }) => {
    return (
        <table>
            <thead>
                <tr>
                    <th>Request Type</th>
                    <th>Severity</th>
                    <th>Duration In Hours</th>
                </tr>
            </thead>
            <tbody>
            {slas.length > 0 && slas.map((sla) => (
                <SlaRow
                    key={sla.id}
                    sla={sla}
                />
            ))}
            </tbody>
        </table>
    );
};

export default QueueTable;
