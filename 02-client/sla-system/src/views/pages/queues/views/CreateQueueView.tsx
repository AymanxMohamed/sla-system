import React, {useEffect, useState} from "react";
import { Formik, Form } from "formik";
import Button from "../../../common/sharedComponents/UI/Button";
import { useNavigate } from "react-router-dom";
import Input from "../../authentication/components/Input";
import CreateUserSchema from "../../../../services/yub/createUserSchema";
import Queue from "../../../../services/types/Api/Entities/Queue";
import useQueuesApi from "../../../../services/hooks/useQueuesApi";
import SelectOptions from "../../../common/sharedComponents/UI/SelectOptions";
import useUserApi from "../../../../services/hooks/useUserApi";
import CreateUserRequest from "../../../../services/types/Api/ApiRequests/Users/CreateUserRequest";
import createQueueRequestSchema from "../../../../services/yub/createQueueSchema";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import CreateQueueRequest from "../../../../services/types/Api/ApiRequests/Queues/CreateQueueRequest";
import {enumToArray} from "../../../../services/utils/appUtils";

const CreateQueueView: React.FC = (): JSX.Element => {
    const { createQueue } = useQueuesApi();
    const navigate = useNavigate();

    const handleChange = (formik: any, field: any, value: number) => {
        console.log(enumToArray(RequestType))
        console.log(value);
        formik.setFieldValue(field, value);
    };

    const submitHandler = async (values: any, { setSubmitting }: any) => {
        console.log(values);
        let queue: CreateQueueRequest = {
            QueueName: values.QueueName,
            RequestType: +values.RequestType
        };
        try {
            // await register(values);
            createQueue(queue).then(user => {
            });
            navigate("/auth/queues");
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
                                        RequestType: "",
                                        QueueName: "",
                                    }}
                                    validationSchema={createQueueRequestSchema}
                                    onSubmit={submitHandler}
                                >
                                    {(formik) => (

                                        <>
                                            <Form>
                                                <Input
                                                    type={"text"}
                                                    id={"QueueName"}
                                                    placeholder={"Enter Queue Name"}
                                                    name={"QueueName"}
                                                    label={"Queue Name"}
                                                />

                                                <SelectOptions idName={"RequestType"}
                                                               elements={enumToArray(RequestType)}
                                                               nameProperty={"name"}
                                                               keyProperty={"id"}
                                                               title={"Select Request Type"}
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

export default CreateQueueView;
