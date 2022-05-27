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
        errors.firstname = "Email required";
    }
    if (IsNullOrWhitespace(values.lastname)) {
        errors.lastname = "Email required";
    }
    if (IsNullOrWhitespace(values.email)) {
        errors.email = "Email required";
    }
    if (IsNullOrWhitespace(values.password)) {
        errors.password = "Password required";
    }
    if (IsNullOrWhitespace(values.password2)) {
        errors.password2 = "Email required";
    }
    return errors;
}