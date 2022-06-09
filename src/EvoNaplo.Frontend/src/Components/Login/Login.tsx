import { ILogin } from './Form/ILogin';
import { LoginForm } from './Form/LoginForm';
import { useNavigate } from 'react-router-dom';
import classes from './Login.module.css'

const Login = () => {
   
    const navigate = useNavigate();

    const onSubmit = (user: ILogin) => {
        
        console.log(user);

        fetch('http://localhost:7043/api/Session/Login', {
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
                    navigate('/', {replace: true});
                }
                else {

                }
            })
            .catch(function (error) {
                //setLoginFailed(true);
            });


    }


    return (
        <>
            <div className={classes.LoginFormCard}>
                <LoginForm onLogin={onSubmit} />
            </div>
        </>
    );
}

export default Login;