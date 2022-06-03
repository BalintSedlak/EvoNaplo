import { IRegistration } from "./Form/IRegistration";
import { RegistrationForm } from './Form/RegistrationForm'
import classes from './Registration.module.css'

/*
- The registration logic
- Render the registration form
*/

const Registration = () => {

  const onSubmit = async (user: IRegistration) => {
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
    <>
      <div className={classes.RegistrationFormCard}>
        <RegistrationForm onRegistration={onSubmit} />
      </div>
    </>
  );
}

export default Registration;