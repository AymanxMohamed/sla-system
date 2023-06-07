import React, {useEffect, useState} from "react";
import { Formik, Form } from "formik";
import Button from "../../../common/sharedComponents/UI/Button";
import { Link, useNavigate } from "react-router-dom";
import useAuthApi from "../../../../services/hooks/useAuthApi";
import { toast } from "react-toastify";
import Input from "../../authentication/components/Input";
import CreateUserSchema from "../../../../services/yub/createUserSchema";
import Queue from "../../../../services/types/Api/Entities/Queue";
import useQueuesApi from "../../../../services/hooks/useQueuesApi";
import SelectOptions from "../../../common/sharedComponents/UI/SelectOptions";
import useUserApi from "../../../../services/hooks/useUserApi";
import CreateUserRequest from "../../../../services/types/Api/ApiRequests/Users/CreateUserRequest";

const CreateUserView: React.FC = (): JSX.Element => {
    const { createUser } = useUserApi();
    const navigate = useNavigate();

    const [queues, setQueues] = useState<Queue[]>([]);
    const queuesApi = useQueuesApi();

    useEffect(() => {
        queuesApi.getQueues().then(queuesArr => {
            setQueues(queuesArr);
        })
    }, []);

    const handleChange = (formik: any, field: any, value: any) => {
        console.log(formik);
        console.log(field);
        console.log(value);

        formik.setFieldValue(field, value);
    };

    const submitHandler = async (values: any, { setSubmitting }: any) => {
        console.log(values);
        let user: CreateUserRequest = {
            UserName: values.username,
            Password: values.password,
            Zone: values.zone,
            QueueId: values.queueId
        };
        try {
            // await register(values);
            createUser(user).then(user => {
            });
            navigate("/auth/users");
        } catch (err: any) {

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
                                <h1 className="h1">Create New User.</h1>
                            </div>

                            {/* Form */}
                            <div className="max-w-sm mx-auto">
                                <Formik
                                    initialValues={{
                                        username: "",
                                        password: "",
                                        confirmPassword: "",
                                        zone: "",
                                        queueId: ""
                                    }}
                                    validationSchema={CreateUserSchema}
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

                                                <SelectOptions idName={"queueId"}
                                                               elements={queues}
                                                               nameProperty={"queueName"}
                                                               title={"Select User Queue"}
                                                changeHandler={handleChange.bind(null, formik)}/>
                                                <Button
                                                    text={"Create"}
                                                    color={"blue"}
                                                    type={"submit"}
                                                />

                                            </Form>
                                        </>
                                    )}
                                </Formik>
                            </div>
                        </div>
                    </div>
                </section>
            </main>
        </div>
    );
};

export default CreateUserView;
