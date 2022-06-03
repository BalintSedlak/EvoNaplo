import React, { useRef, useState } from 'react'
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

  const firstnameRef = useRef<HTMLInputElement | null>();
  const lastnameRef = useRef<HTMLInputElement | null>();
  const emailRef = useRef<HTMLInputElement | null>();
  const passwordRef = useRef<HTMLInputElement | null>();
  const password2Ref = useRef<HTMLInputElement | null>();




  function handleInputChange(e: React.ChangeEvent<HTMLInputElement>) {
    setUser({
      ...user,
      [e.target.name]: e.target.value
    });

    const returnedErrors = validate(user);
    let errorsReceived = CheckIfErrorsReceived(returnedErrors);

    const enteredFirstname = firstnameRef.current.value;
    const enteredLastname = lastnameRef.current.value;
    const enteredEmail = emailRef.current.value;
    const enteredPassword = passwordRef.current.value;
    const enteredPassword2 = password2Ref.current.value;

    if (IsNullOrWhitespace(enteredFirstname) || enteredFirstname.length < 3) {
      errors.firstname = "Firstname is required";
    }
    else {
      errors.firstname = "";
    }

    if (IsNullOrWhitespace(enteredLastname) || enteredLastname.length < 3 ) {
      errors.lastname = "Lastname is required";
    } else {
      errors.lastname = "";
    }

    if (IsNullOrWhitespace(enteredEmail) || enteredEmail.length < 3 ) {
      errors.email = "Email required";
    } else {
      errors.email = "";
    }

    if (IsNullOrWhitespace(enteredPassword) || enteredPassword.length < 3 ) {
      errors.password = "Password required";
    } else {
      errors.password = "";
    }

    if (enteredPassword !== enteredPassword2) {
      errors.password2 = "The 2 password is not matched";
    }
    if (enteredPassword === enteredPassword2) {
      errors.password2 = "";
    }

    if (errorsReceived === false) {
      setFormIsValid(true);
    } else {
      setFormIsValid(false);
      console.log(errorsReceived)
    }

    /*
    const returnedErrors = validate(user);
    setErrors(returnedErrors);
    let errorsReceived = CheckIfErrorsReceived(returnedErrors);

    if (errorsReceived === false) {
      setFormIsValid(false);
    } else {
      setFormIsValid(true);
    }

    console.log(user);
    */
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
    console.log(user);
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
          <input ref={firstnameRef} type="text" name="firstname" value={user.firstname} placeholder="Joseph" onChange={handleInputChange} />
          {ErrorMessage("firstname")}
        </div>

        <div className='p-2'>
          Lastname:
          <input ref={lastnameRef} type="text" name="lastname" value={user.lastname} placeholder="Smith" onChange={handleInputChange} />
          {ErrorMessage("lastname")}
        </div>


        <div className='p-2'>
          Email:
          <input ref={emailRef} type="text" name="email" value={user.email} placeholder="example@mail.com" onChange={handleInputChange} />
          {ErrorMessage("email")}
          {/*<p className={classes.ErrorParagraph}>Email already exist</p>*/}
        </div>


        <div className='p-2'>
          Password:
          <input ref={passwordRef} type="password" name="password" value={user.password} placeholder="••••••••" onChange={handleInputChange} />
          {ErrorMessage("password")}
        </div>


        <div className='p-2'>
          Confirm password:
          <input ref={password2Ref} type="password" name="password2" value={user.password2} placeholder="••••••••" onChange={handleInputChange} />
          {ErrorMessage("password2")}
        </div>


        <input type="submit" disabled={!formIsValid}/>
      </form>
    </>
  )
}
