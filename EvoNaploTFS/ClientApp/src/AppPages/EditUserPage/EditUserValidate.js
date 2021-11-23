export default function validateInfo(values) {
    let errors = {};

    if (!values.firstName) {
        errors.firstName = "Firstname required";
    }
    if (!values.lastName) {
        errors.lastName = "Lastname required";
    }
    if (!values.email) {
        errors.email = "Email required";
    }
    if (!values.phoneNumber) {
        errors.phoneNumber = "phoneNumber required";
    }
    if (!values.password) {
        errors.password = "Password required";
    }
    if (!values.password2) {
        errors.password2 = "Password required";
    }

    return errors;
}