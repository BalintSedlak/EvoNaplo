import { useNavigate, Navigate } from 'react-router-dom';
import ISession from "../../ISession";
import { UnauthorizedModal } from '../UI/UnauthorizedModal';
import { IRegistration } from "./Form/IRegistration";
import { RegistrationForm } from './Form/RegistrationForm'
import classes from './Registration.module.css'


export default function Registration({ session }: { session: ISession }) {
  const navigate = useNavigate();
  //console.log(session);
  if (session.id < 0) {
    const onSubmit = async (user: IRegistration) => {
      console.log(user);

      fetch('http://localhost:7043/api/Session/Registration', { mode: "cors", method: 'POST', body: JSON.stringify(user), headers: { "Content-Type": "application/json" } })
        .then(res => {
          if (res.status === 200) {
            navigate('/Components/Login/Login', {replace: true});
          }
          else {
            alert("Something went wrong");

          }
        })
        .catch(function (error) {
          console.log(error);
        });
    }
    return (
      <>
        <div className={classes.RegistrationFormCard}>
          <RegistrationForm onRegistration={onSubmit} />
        </div>
      </>
    );
  }
  else {
    return <Navigate to="/" />
  }
}
