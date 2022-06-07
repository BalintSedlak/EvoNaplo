import { LoginForm } from './Form/LoginForm';
import classes from './Login.module.css'

const Login = () => {


    const onSubmit = (e: any) => {
        e.preventDefault();
        /*
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
        */
    }


    return (
        <>
            <div className={classes.LoginFormCard}>
                <LoginForm onRegistration={onSubmit} />
            </div>
        </>
    );
}

export default Login;