import { object, string } from "yup";

let loginSchema = object({
    username: string()
        .min(3, `User Name must be at least 3 chars`)
        .max(15, `User Name Must be 15 chars or less`)
        .required("User Name is Required"),
    password: string().required("password is Required"),
});

export default loginSchema;
