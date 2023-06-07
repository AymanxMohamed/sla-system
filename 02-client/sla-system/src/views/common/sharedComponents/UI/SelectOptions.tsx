import React from "react";
import {ErrorMessage, Field} from "formik";

const SelectOptions: React.FC<{  idName: string, elements: any[], nameProperty: string, changeHandler?: any, title: string,
    keyProperty?: string }> =
    ({ idName, elements, nameProperty, changeHandler, title, keyProperty = "id"}) => {
    function handleChange(event: React.ChangeEvent<HTMLSelectElement>) {
        const selectedValue = event.target.value;
        if (changeHandler) {
            changeHandler(idName, selectedValue);
        }
    }
    return (
        <div>
            <label htmlFor={idName}>{title}</label>
            <Field as="select" name={idName} onChange={handleChange}>
                <option value="">{title}</option>
                {elements.map((element) => (
                    <option key={element[keyProperty]} value={element[keyProperty]}>
                        {element[nameProperty]}
                    </option>
                ))}
            </Field>
            <ErrorMessage name={idName} component="div" />
        </div>
    );
};

export default SelectOptions;
