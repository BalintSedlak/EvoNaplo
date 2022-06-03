import React, { useEffect, useState } from "react";
import { IRegistration } from "./IRegistration";
import validate from "./RegistrationValidation";
import { IsNullOrWhitespace } from "./Helpers";
import { IEmailExists } from "./IEmailExists";


const Registration = () => {

    const [user, setUser] = useState<IRegistration>({
        firstname: '',
        lastname: '',
        email: '',
        password: '',
        password2: ''
    });

    const [errors, setErrors] = useState({
        firstname: '',
        lastname: '',
        email: '',
        password: '',
        password2: ''
    });

    const [success, setSuccess] = useState(false);
    const [emailExists, setEmailExists] = useState<boolean>();

    const HandleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setUser({
            ...user,
            [e.target.name]: e.target.value
        });
    }

    function CheckIfErrorsReceived(param: IRegistration) {
        let Found = false;
        Object.entries(param).map(([key, value]) => {
            if (IsNullOrWhitespace(value) === false) {
                Found = true;
            }
        });

        if (Found) {
            return true;
        }
        else {
            return false;
        }
    }

    useEffect(() => { }, []);

    const onSubmit = async (e: any) => {
        e.preventDefault()

        const returnedErrors = validate(user);
        setErrors(returnedErrors);
        let errorsReceived = CheckIfErrorsReceived(returnedErrors);

        /*
        const returnedEmail: IEmailExists = await fetch('https://localhost:7043/api/Student/EmailExists/?email=' + user.email)
            .then(response => response.json())
            .then(json => { return json })
        */


        /*
        if (errorsReceived === false) {
            if (returnedEmail.exists === false) {
                setEmailExists(false);
                fetch('http://localhost:7043/api/Session/Registration', { method: 'POST', body: JSON.stringify(user), headers: { "Content-Type": "application/json" } })
                    .then(res => {
                        if (res.status === 200) {
                            setSuccess(true);
                            setUser({
                                firstname: '',
                                lastname: '',
                                email: '',
                                password: '',
                                password2: ''
                            });
                        }
                        else {
                            alert("Nem sikerült, sorry");
                            setSuccess(false);
                        }
                    })
                    .catch(function (error) {
                        setSuccess(false);
                    });
            }
            else
            {
                setEmailExists(true);í
            }
        }
        else {
            setSuccess(false);
        }
        */

        if (errorsReceived === false) {
            fetch('http://localhost:7043/api/Session/Registration', { method: 'POST', body: JSON.stringify(user), headers: { "Content-Type": "application/json" } })
                .then(res => {
                    if (res.status === 200) {
                        setSuccess(true);
                        setUser({
                            firstname: '',
                            lastname: '',
                            email: '',
                            password: '',
                            password2: ''
                        });
                    }
                    else {
                        alert("Nem sikerült, sorry");
                        setSuccess(false);
                    }
                })
                .catch(function (error) {
                    setSuccess(false);
                });

        }
        else {
            setSuccess(false);
        }
    }

    const ErrorMessage = (param: string) => {
        if (success === false) {
            if (param === "email" && !IsNullOrWhitespace(errors.email)) {
                return <p className="ErrorParagraph">{errors.email}</p>;
            }
            else if (param === "firstname" && !IsNullOrWhitespace(errors.firstname)) {
                return <p className="ErrorParagraph">{errors.firstname}</p>;
            }
            else if (param === "lastname" && !IsNullOrWhitespace(errors.lastname)) {
                return <p className="ErrorParagraph">{errors.lastname}</p>;
            }
            else if (param === "password" && !IsNullOrWhitespace(errors.password)) {
                return <p className="ErrorParagraph">{errors.password}</p>;
            }
            else if (param === "password2" && !IsNullOrWhitespace(errors.password2)) {
                return <p className="ErrorParagraph">{errors.password2}</p>;
            }
        }
    }

    return (
        /* "handleSubmit" will validate your inputs before invoking "onSubmit" */

        <div className="DivCard centerCard">
            <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Registration</h1>
            <form onSubmit={onSubmit} id="registrationForm">
                {/* register your input into the hook by invoking the "register" function */}
                Firstname:
                <input type="text" name="firstname" value={user.firstname} placeholder="Joseph" onChange={HandleChange} />
                {ErrorMessage("firstname")}

                Lastname:
                <input type="text" name="lastname" value={user.lastname} placeholder="Smith" onChange={HandleChange} />
                {ErrorMessage("lastname")}

                Email:
                <input type="text" name="email" value={user.email} placeholder="example@mail.com" onChange={HandleChange} />
                {ErrorMessage("email")}
                {emailExists && <p className="ErrorParagraph">Email already exist</p>}

                Password:
                <input type="password" name="password" value={user.password} placeholder="••••••••" onChange={HandleChange} />
                {ErrorMessage("password")}

                Confirm password:
                <input type="password" name="password2" value={user.password2} placeholder="••••••••" onChange={HandleChange} />
                {ErrorMessage("password2")}

                <input type="submit" />
            </form>
            {success && <p className="SuccessParagraph">Student {user.firstname} successfully added.</p>}
        </div>
    );
}

export default Registration;