import React, { useEffect } from "react";
import { RegistrationForm } from './RegistrationForm'

/*
- The registration logic
- Render the registration form
*/

const Registration = () => {


  useEffect(() => { }, []);

  const onSubmit = async (e: any) => {
    /*
      e.preventDefault()

      const returnedErrors = validate(user);
      setErrors(returnedErrors);
      let errorsReceived = CheckIfErrorsReceived(returnedErrors);


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
      */
  }



  return (
    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */

    <>
      <RegistrationForm />
    </>
  );
}

export default Registration;