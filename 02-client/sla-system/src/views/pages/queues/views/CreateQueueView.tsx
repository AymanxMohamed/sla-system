import React from "react";
import { Formik, Form } from "formik";
import Button from "../../../common/sharedComponents/UI/Button";
import { Link, useNavigate } from "react-router-dom";
import useAuthApi from "../../../../services/hooks/useAuthApi";
import { toast } from "react-toastify";
import RegisterSchema from "../../../../services/yub/RegisterSchema";
import Input from "../../authentication/components/Input";

const CreateQueueView: React.FC = (): JSX.Element => {
    const { register } = useAuthApi();
    const navigate = useNavigate();

    const submitHandler = async (values: any, { setSubmitting }: any) => {
        try {
            // await register(values);
            toast.promise(register(values), {
                pending: "Creating Account in prosess",
                success: "Account Created Successfully",
                error: "Error ocuured",
            });
            navigate("/auth/login");
        } catch (err: any) {
            for (let key in err) {
                toast.error(err[key][0]);
            }
        }
        setSubmitting(false);
    };
    return (
        <div className="flex flex-col min-h-screen overflow-hidden">
            <main className="flex-grow">
                <section className="bg-gradient-to-b from-gray-100 to-white">
                    <div className="max-w-6xl mx-auto px-4 sm:px-6">
                        <div className="pt-32 pb-12 md:pt-40 md:pb-20">
                            {/* Page header */}
                            <div className="max-w-3xl mx-auto text-center pb-12 md:pb-20">
                                <h1 className="h1">Sign Up!.</h1>
                            </div>

                            {/* Form */}
                            <div className="max-w-sm mx-auto">
                                <Formik
                                    initialValues={{
                                        username: "",
                                        password: "",
                                        confirmPassword: "",
                                        zone: "",
                                    }}
                                    validationSchema={RegisterSchema}
                                    onSubmit={submitHandler}
                                >
                                    {(formik) => (
                                        <>
                                            <Form>
                                                <Input
                                                    type={"text"}
                                                    id={"username"}
                                                    placeholder={"Enter Your first name"}
                                                    name={"username"}
                                                    label={"User Name"}
                                                />
                                                <Input
                                                    id={"pas"}
                                                    type={"password"}
                                                    placeholder={"Enter Your Password"}
                                                    name={"password"}
                                                    label={"Password"}
                                                />
                                                <Input
                                                    id={"pas_conf"}
                                                    type={"password"}
                                                    placeholder={"Enter Your Password Confirmation"}
                                                    name={"confirmPassword"}
                                                    label={"Confirm Password"}
                                                />
                                                <Input
                                                    id={"zone"}
                                                    type={"text"}
                                                    name={"zone"}
                                                    placeholder={"Enter Your Zone"}
                                                    label={"Zone"}
                                                />
                                                <Button
                                                    text={"Sign up"}
                                                    color={"blue"}
                                                    type={"submit"}
                                                />
                                            </Form>
                                        </>
                                    )}
                                </Formik>
                                <div className="text-sm text-gray-500 text-center mt-3">
                                    By creating an account, you agree to the{" "}
                                    <a className="underline" href="#0">
                                        terms & conditions
                                    </a>
                                    , and our{" "}
                                    <a className="underline" href="#0">
                                        privacy policy
                                    </a>
                                    .
                                </div>
                                <div className="text-gray-600 text-center mt-6">
                                    Already a Member?
                                    <Link
                                        to="/auth/login"
                                        className="text-blue-600 hover:underline transition duration-150 ease-in-out"
                                    >
                                        Sign in
                                    </Link>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </main>
        </div>
    );
};

export default CreateQueueView;
