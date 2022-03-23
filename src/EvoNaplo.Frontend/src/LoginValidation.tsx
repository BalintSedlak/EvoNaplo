import { ILogin } from "./ILogin";
import { IsNullOrWhitespace } from "./Helpers";

export default function ValidateInfo(values: ILogin) {
    let errors = {
        email: "",
        password: ""
    };

    if (IsNullOrWhitespace(values.email)) {
        errors.email = "Email required";
    }
    if (IsNullOrWhitespace(values.password)) {
        errors.password = "Password required";
    }
    return errors;
}