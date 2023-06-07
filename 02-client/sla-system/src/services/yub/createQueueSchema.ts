import { number, object, string} from "yup";

let createQueueRequestSchema = object({
    RequestType: number()
        .required("Request Type is Required"),
    QueueName: string().required("Queue Name is Required"),
});

export default createQueueRequestSchema;
