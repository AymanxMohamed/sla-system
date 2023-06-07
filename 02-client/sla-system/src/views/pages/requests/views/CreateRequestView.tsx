import React from "react";
import { Formik, Form } from "formik";
import Button from "../../../common/sharedComponents/UI/Button";
import { useNavigate } from "react-router-dom";
import Input from "../../authentication/components/Input";
import SelectOptions from "../../../common/sharedComponents/UI/SelectOptions";
import {RequestType} from "../../../../services/types/Api/enums/RequestType";
import {enumToArray} from "../../../../services/utils/appUtils";
import useRequestApi from "../../../../services/hooks/useRequestApi";
import CreateRequestPayload from "../../../../services/types/Api/ApiRequests/Requests/CreateRequestPayload";
import useAuthSlice from "../../../../services/hooks/useAuthSlice";
import createRequestSchema from "../../../../services/yub/createRequestSchema";

const CreateRequestView: React.FC = (): JSX.Element => {
    const { createRequest } = useRequestApi();
    const { user } = useAuthSlice();
    const navigate = useNavigate();

    const handleChange = (formik: any, field: any, value: number) => {
        console.log(enumToArray(RequestType))
        console.log(value);
        formik.setFieldValue(field, value);
    };

    const submitHandler = async (values: any, { setSubmitting }: any) => {
        console.log(values);
        let request: CreateRequestPayload = {
            Description: values.Description,
            ClientId: user?.id || "",
            RequestType: +values.RequestType
        };
        try {
            // await register(values);
            createRequest(request).then(user => {
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
                                        Description: "",
                                    }}
                                    validationSchema={createRequestSchema}
                                    onSubmit={submitHandler}
                                >
                                    {(formik) => (

                                        <>
                                            <Form>
                                                <Input
                                                    type={"text"}
                                                    id={"Description"}
                                                    placeholder={"Enter Description"}
                                                    name={"Description"}
                                                    label={"Description"}
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

export default CreateRequestView;
