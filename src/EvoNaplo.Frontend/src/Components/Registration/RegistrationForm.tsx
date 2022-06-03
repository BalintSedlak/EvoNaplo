import React, { useState } from 'react'
import { IsNullOrWhitespace } from './Helpers';
import { IRegistration } from './IRegistration';

export const RegistrationForm = (props) => {

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

  const [success, setSuccess] = useState(false);

  const HandleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setUser({
      ...user,
      [e.target.name]: e.target.value
    });
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


  const ErrorMessage = (param: string) => {
    if (success === false) {
      if (param === "email" && !IsNullOrWhitespace(errors.email)) {
        return <p className="ErrorParagraph">{errors.email}</p>;
      }
      else if (param === "firstname" && !IsNullOrWhitespace(errors.firstname)) {
        return <p className="ErrorParagraph">{errors.firstname}</p>;
      }
      else if (param === "lastname" && !IsNullOrWhitespace(errors.lastname)) {
        return <p className="ErrorParagraph">{errors.lastname}</p>;
      }
      else if (param === "password" && !IsNullOrWhitespace(errors.password)) {
        return <p className="ErrorParagraph">{errors.password}</p>;
      }
      else if (param === "password2" && !IsNullOrWhitespace(errors.password2)) {
        return <p className="ErrorParagraph">{errors.password2}</p>;
      }
    }
  }

  return (
    <div className="DivCard centerCard">
      <h1 style={{ textAlign: "center", paddingBottom: "15px" }}>Registration</h1>
      <form id="registrationForm">
        {/* register your input into the hook by invoking the "register" function */}
        Firstname:
        <input type="text" name="firstname" value={user.firstname} placeholder="Joseph" onChange={HandleChange} />
        {ErrorMessage("firstname")}

        Lastname:
        <input type="text" name="lastname" value={user.lastname} placeholder="Smith" onChange={HandleChange} />
        {ErrorMessage("lastname")}

        Email:
        <input type="text" name="email" value={user.email} placeholder="example@mail.com" onChange={HandleChange} />
        {ErrorMessage("email")}
        {/*<p className="ErrorParagraph">Email already exist</p>*/}

        Password:
        <input type="password" name="password" value={user.password} placeholder="••••••••" onChange={HandleChange} />
        {ErrorMessage("password")}

        Confirm password:
        <input type="password" name="password2" value={user.password2} placeholder="••••••••" onChange={HandleChange} />
        {ErrorMessage("password2")}

        <input type="submit" />
      </form>
      {success && <p className="SuccessParagraph">Student {user.firstname} successfully added.</p>}
    </div>
  )
}
