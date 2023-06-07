import { number, object, string} from "yup";

let CreateRequestSchema = object({
    RequestType: number()
        .required("Request Type is Required"),
    Description: string()
        .required("Description is Required")
});

export default CreateRequestSchema;
