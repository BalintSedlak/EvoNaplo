import React, { useState } from 'react'
import { IsNullOrWhitespace } from './Helpers';
import { IRegistration } from './IRegistration';
import validate from "./RegistrationValidation";
import classes from './RegistrationForm.module.css'

export const RegistrationForm = (props) => {

  const [formIsValid, setFormIsValid] = useState(false);
  const [success, setSuccess] = useState(false);
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


  

  const HandleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUser({
      ...user,
      [e.target.name]: e.target.value
    });

    const returnedErrors = validate(user);
    let errorsReceived = CheckIfErrorsReceived(returnedErrors);

    if(errorsReceived === false){
      setFormIsValid(false);
    }else{
      setFormIsValid(true);
    }
    
    console.log(user);
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

  const submitHandler = (event) => {
    event.preventDefault();
    

  }

  const ErrorMessage = (param: string) => {
    if (success === false) {
      if (param === "email" && !IsNullOrWhitespace(errors.email)) {
        return <p className={classes.ErrorParagraph}>{errors.email}</p>;
      }
      else if (param === "firstname" && !IsNullOrWhitespace(errors.firstname)) {
        return <p className={classes.ErrorParagraph}>{errors.firstname}</p>;
      }
      else if (param === "lastname" && !IsNullOrWhitespace(errors.lastname)) {
        return <p className={classes.ErrorParagraph}>{errors.lastname}</p>;
      }
      else if (param === "password" && !IsNullOrWhitespace(errors.password)) {
        return <p className={classes.ErrorParagraph}>{errors.password}</p>;
      }
      else if (param === "password2" && !IsNullOrWhitespace(errors.password2)) {
        return <p className={classes.ErrorParagraph}>{errors.password2}</p>;
      }
    }
  }

  return (
    <>
      <h1 className={classes.headerText}>Registration</h1>
      <form id="registrationForm" onSubmit={submitHandler}>
        {/* register your input into the hook by invoking the "register" function */}
        <div className='p-2'>
          Firstname:
          <input type="text" name="firstname" value={user.firstname} placeholder="Joseph" onChange={HandleChange} />
          {ErrorMessage("firstname")}
        </div>

        <div className='p-2'>
          Lastname:
          <input type="text" name="lastname" value={user.lastname} placeholder="Smith" onChange={HandleChange} />
          {ErrorMessage("lastname")}
        </div>


        <div className='p-2'>
          Email:
          <input type="text" name="email" value={user.email} placeholder="example@mail.com" onChange={HandleChange} />
          {ErrorMessage("email")}
          {/*<p className={classes.ErrorParagraph}>Email already exist</p>*/}
        </div>


        <div className='p-2'>
          Password:
          <input type="password" name="password" value={user.password} placeholder="••••••••" onChange={HandleChange} />
          {ErrorMessage("password")}
        </div>


        <div className='p-2'>
          Confirm password:
          <input type="password" name="password2" value={user.password2} placeholder="••••••••" onChange={HandleChange} />
          {ErrorMessage("password2")}
        </div>


        <input type="submit" />
      </form>
    </>
  )
}
