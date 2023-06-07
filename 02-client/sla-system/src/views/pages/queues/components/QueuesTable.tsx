import Queue from "../../../../services/types/Api/Entities/Queue";
import React from "react";
import QueueRow from "./QueueRow";

const QueueTable: React.FC<{ queues: Queue[] }> = ({ queues }) => {
    return (
        <table>
            <thead>
                <tr>
                    <th>Queue name</th>
                    <th>Request Type</th>
                </tr>
            </thead>
            <tbody>
            {queues.length > 0 && queues.map((queue) => (
                <QueueRow
                    key={queue.id}
                    queue={queue}
                />
            ))}
            </tbody>
        </table>
    );
};

export default QueueTable;
