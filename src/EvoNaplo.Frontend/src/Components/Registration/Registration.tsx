import { useState } from "react";
import { Navigate } from 'react-router-dom';
import ISession from "../../ISession";
import { IRegistration } from "./Form/IRegistration";
import { RegistrationForm } from './Form/RegistrationForm'
import classes from './Registration.module.css'


export default function Registration({ session }: { session: ISession }) {

  const [success, setSuccess] = useState(false);
  if (session.id > 0) {
    const onSubmit = async (user: IRegistration) => {
      console.log(user);


      fetch('http://localhost:7043/api/Session/Registration', { mode: "cors", method: 'POST', body: JSON.stringify(user), headers: { "Content-Type": "application/json" } })
        .then(res => {
          if (res.status === 200) {
            setSuccess(true);
          }
          else {
            alert("Nem sikerült, sorry");

          }
        })
        .catch(function (error) {
          setSuccess(false);
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
