export default function validateInfo(values) {
    let errors = {};

    if (!values.startDate) {
        errors.startDate = "startDate required";
    }
    if (!values.endDate) {
        errors.endDate = "endDate required";
    }
    //if (!values.isAppliable) {
    //    errors.isAppliable = "isAppliable required";
    //}

    return errors;
}