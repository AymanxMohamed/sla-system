import React from "react";
import { Formik, Form } from "formik";
import Input from "../components/Input";
import Button from "../../../common/sharedComponents/UI/Button";
import useAuthApi from "../../../../services/hooks/useAuthApi";
import { useNavigate } from "react-router-dom";
import Checkbox from "../components/CheckBox";
import {toast} from "react-toastify";
import AuthWrapper from "../../../common/sharedComponents/UI/AuthWrapper";
import LoginRequest from "../../../../services/types/Api/ApiRequests/Auth/LoginRequest";
import loginSchema from "../../../../services/yub/loginSchema";

const LoginView: React.FC = (): JSX.Element => {
    const navigate = useNavigate();
    console.log("inside login")
    const { login } = useAuthApi();

    const submitHandler = (values: any, { setSubmitting }: any) => {
        let loginRequest: LoginRequest = {
            UserName: values.username,
            Password: values.password
        }
        login(loginRequest, values.checked)
            .then((r) => {
                navigate("/");
            })
            .catch((err) =>
                toast.error(err.message));
        setSubmitting(false);
    };
    return (
        <AuthWrapper>
            <div className="max-w-3xl mx-auto text-center pb-12 md:pb-20">
                <h1 className="h1">Sign In.</h1>
            </div>
            <div className="max-w-sm mx-auto">
                <Formik
                    initialValues={{
                        username: "",
                        password: "",
                        checked: [],
                    }}
                    validationSchema={loginSchema}
                    onSubmit={submitHandler}
                >
                    {(formik) => (
                        <>
                            <Form>
                                <Input
                                    type={"text"}
                                    name={"username"}
                                    label={"User Name"}
                                    placeholder={"Enter your User Name"}
                                />
                                <Input
                                    type={"password"}
                                    name={"password"}
                                    label={"Password"}
                                    placeholder={"Enter your password"}
                                />
                                <Checkbox
                                    label="Keep me signed in"
                                    name={"checked"}
                                    value={"Keep me signed in"}
                                />
                                <Button text={"Login"} color={"blue"} type={"submit"} />
                            </Form>
                        </>
                    )}
                </Formik>
            </div>
        </AuthWrapper>
    );
};

export default LoginView;
