import React, { Component, useEffect, useState } from 'react';
import { useHistory } from 'react-router';
import validate from "../LoginPage/LoginValidate";

const Login = () => {
    const [user, setUser] = useState({});

    const [loginFailed, setLoginFailed] = useState();
    const [errors, setErrors] = useState({});

    const handleChange = e => {
        setUser({
            ...user,
            [e.target.name]: e.target.value
        });
    }

    const handleSubmit = e => {
        e.preventDefault();
        const returnedErrors = validate(user);
        setErrors(returnedErrors);
        if (Object.keys(returnedErrors).length == 0) {
            fetch('api/Auth/Login', { method: 'POST', body: JSON.stringify(user), headers: { "Content-Type": "application/json" } })
                .then(function (data) {
                    if (data.status === 200) {
                        window.location = "/";
                    }
                    else {
                        setLoginFailed("Bad password or username.");
                    }
                })
                .catch(function (error) {
                    setLoginFailed(error);
                });
        }
    }

    return (
        <div class="DivCard centerCard">
            <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Login</h1>
            <form onSubmit={handleSubmit} >
                Email:
                <input type="text" name="email" placeholder="example@mail.com" onChange={handleChange} />
                {errors.email && <p class="ErrorParagraph">{errors.email}</p>}
                Password:
                <input type="password" name="password" placeholder="••••••••" onChange={handleChange} />
                {errors.password && <p class="ErrorParagraph">{errors.password}</p>}
                <input type="submit" class="btn btn-success" value="Login" />
            </form>
            {loginFailed && <p class="ErrorParagraph">{loginFailed}</p>}
        </div>
    );
}

export default Login;