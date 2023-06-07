import {date, mixed, object } from "yup";
import {RequestType} from "../types/Api/enums/RequestType";
import { Severity } from "../types/Api/enums/Severity";

let createSlaRequestSchema = object({
    RequestType: mixed<RequestType>()
        .oneOf(Object.values(RequestType) as RequestType[])
        .required("Request Type is Required"),
    Severity: mixed<Severity>()
        .oneOf(Object.values(Severity) as Severity[])
        .required("Severity is Required"),
    DurationInHours: date().required("Duration is required"),
});

export default createSlaRequestSchema;
