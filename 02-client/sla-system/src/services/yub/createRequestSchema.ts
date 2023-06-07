import { mixed, object, string } from "yup";
import {RequestType} from "../types/Api/enums/RequestType";

let CreateRequestSchema = object({
    RequestType: mixed<RequestType>()
        .oneOf(Object.values(RequestType) as RequestType[])
        .required("Request Type is Required"),
    Description: string()
        .required("Description is Required"),
    ClientId: string().required("Duration is required"),
});

export default CreateRequestSchema;
