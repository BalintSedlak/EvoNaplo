import { useState } from "react";
import { IRegistration } from "./Form/IRegistration";
import { RegistrationForm } from './Form/RegistrationForm'
import classes from './Registration.module.css'

/*
- The registration logic
- Render the registration form
*/

const Registration = () => {

  const [success, setSuccess] = useState(false);
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

export default Registration;