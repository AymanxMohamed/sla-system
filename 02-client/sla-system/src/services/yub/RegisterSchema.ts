import { object, ref, string } from "yup";

let RegisterSchema = object({
    username: string()
        .min(3, `User Name must be at least 3 chars`)
        .max(15, `User Name Must be 15 chars or less`)
        .required("UserName is Required"),

    password: string()
        .matches(
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/,
            "Must Contain 8 Characters, One Uppercase, One Lowercase, One Number and One Special Case Character"
        )
        .required("Password is Required"),
    confirmPassword: string()
        .oneOf([ref("password"), undefined], `Password doesn't match`)
        .required("Confirm Password is Required"),
    zone: string()
        .required("Zone is Required"),
});

export default RegisterSchema;
