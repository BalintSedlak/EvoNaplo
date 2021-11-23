export default function validateInfo(values) {
    let errors = {};

    if (!values.firstname) {
        errors.firstname = "Firstname required";
    }
    if (!values.lastname) {
        errors.lastname = "Lastname required";
    }
    if (!values.email) {
        errors.email = "Email required";
    }
    if (!values.password) {
        errors.password = "Password required";
    }
    if (!values.password2) {
        errors.password2 = "Password required";
    }

    return errors;
}