import { IsNullOrWhitespace } from "./Helpers";
import { IRegistration } from "./IRegistration";

export default function ValidateInfo(values: IRegistration) {
    let errors = {
        firstname: "",
        lastname: "",
        email: "",
        password: "",
        password2: ""
    };

    if (IsNullOrWhitespace(values.firstname)) {
        errors.firstname = "Firstname is required";
    }
    if (IsNullOrWhitespace(values.lastname)) {
        errors.lastname = "Lastname is required";
    }
    if (IsNullOrWhitespace(values.email)) {
        errors.email = "Email required";
    }
    if (IsNullOrWhitespace(values.password)) {
        errors.password = "Password required";
    }
    if (IsNullOrWhitespace(values.password2) || values.password !== values.password2) {
        errors.password2 = "Password is not matched";
    }
    return errors;
}