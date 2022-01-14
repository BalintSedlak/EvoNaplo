export default function validateInfo(values) {
    let errors = {};

    if (!values.projectName) {
        errors.projectName = "projectName required";
    }
    if (!values.description) {
        errors.description = "description required";
    }
    return errors;
}