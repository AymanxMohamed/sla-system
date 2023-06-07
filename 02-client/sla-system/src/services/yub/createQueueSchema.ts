import {mixed, object, string } from "yup";
import {RequestType} from "../types/Api/enums/RequestType";

let createQueueRequestSchema = object({
    RequestType: mixed<RequestType>()
        .oneOf(Object.values(RequestType) as RequestType[])
        .required("Request Type is Required"),
    QueueName: string().required("Queue Name is Required"),
});

export default createQueueRequestSchema;
