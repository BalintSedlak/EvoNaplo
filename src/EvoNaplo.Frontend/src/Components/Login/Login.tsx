import React, { useState } from 'react';
import validate from "./LoginValidation";
import { ILogin } from './ILogin';
import { IsNullOrWhitespace } from "../../Helpers";

const Login = () => {
    const [user, setUser] = useState<ILogin>(
        {
            email: "",
            password: ""
        }
    );

    const [loginFailed, setLoginFailed] = useState(false);
    const [errors, setErrors] = useState({
        email: "",
        password: ""
    });

    const HandleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setUser({
            ...user,
            [e.target.name]: e.target.value
        });
    }

    function CheckIfErrorsReceived(param: ILogin) {
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

    const HandleSubmit = (e: any) => {
        e.preventDefault();
        const returnedErrors = validate(user);
        setErrors(returnedErrors);
        if (CheckIfErrorsReceived(returnedErrors) === false) {
            fetch('https://localhost:7043/api/Auth/Login', {
                method: 'POST',
                body: JSON.stringify(user),
                headers: {
                    "Content-Type": "application/json",
                    "Connection": "keep-alive"
                },
                credentials: 'include'
            })
                .then(function (data) {
                    if (data.status === 200) {
                        alert("Bent vagy more!");
                    }
                    else {

                    }
                })
                .catch(function (error) {
                    setLoginFailed(true);
                });
        }
        else {
            setLoginFailed(true);
        }
    }

    const ErrorMessage = (param: string) => {
        if (loginFailed === true) {
            if (param === "email" && !IsNullOrWhitespace(errors.email)) {
                return <p className="ErrorParagraph">{errors.email}</p>;
            }
            else if (param === "password" && !IsNullOrWhitespace(errors.password)) {
                return <p className="ErrorParagraph">{errors.password}</p>;
            }
        }
    }


    return (
        <div className="DivCard centerCard">
            <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Login</h1>
            <form onSubmit={HandleSubmit} >
                Email:
                <input type="text" name="email" placeholder="example@mail.com" onChange={HandleChange} />
                {ErrorMessage("email")}

                Password:
                <input type="password" name="password" placeholder="••••••••" onChange={HandleChange} />
                {ErrorMessage("password")}

                <input type="submit" className="btn btn-success" value="Login" />
            </form>
            {loginFailed === true && <p className="ErrorParagraph">{loginFailed}</p>}
        </div>
    );
}

export default Login;