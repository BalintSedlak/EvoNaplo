import { useEffect, useRef, useState } from "react";
import { useForm } from "react-hook-form";
import { IRegistration } from "./IRegistration";
import classes from './RegistrationForm.module.css'


export const RegistrationForm = (props) => {

  const {
    register,
    handleSubmit,
    watch,
    getValues,
    formState: { errors }
  } = useForm<IRegistration>();


  const [emailExists, setEmailExists] = useState(false);


  useEffect(() => {
    fetch('http://localhost:7043/api/Session/EmailIsValid?email=' + watch("email"))
      .then(response => response.json())
      .then(json => setEmailExists(json))
  }, [watch('email')])


  const onSubmit = (data: IRegistration) => {
    props.onRegistration(data);
  };


  return (
    <>
      <h1 className={classes.headerText}>Registration</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <label>First Name</label>
        <input
          type="text"
          {...register("firstname", {
            required: true,
            maxLength: 20,
            minLength: 3,
            pattern: /^[A-Za-záéúőóüö]+$/i
          })}
          placeholder="Joseph"
        />
        {errors?.firstname?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.firstname?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>First name cannot be less than 3 characters</p>
        )}
        {errors?.firstname?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>First name cannot exceed 20 characters</p>
        )}
        {errors?.firstname?.type === "pattern" && (
          <p className={classes.ErrorParagraph}>Alphabetical characters only</p>
        )}


        <label>Last Name</label>
        <input
          type="text"
          {...register("lastname", {
            required: true,
            maxLength: 20,
            minLength: 3,
            pattern: /^[A-Za-záéúőóüö]+$/i
          })}
          placeholder="Smith"
        />
        {errors?.lastname?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.lastname?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>Last name cannot be less than 3 characters</p>
        )}
        {errors?.lastname?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>Last name cannot exceed 20 characters</p>
        )}
        {errors?.lastname?.type === "pattern" && (
          <p className={classes.ErrorParagraph}>Alphabetical characters only</p>
        )}

        <label>Email</label>
        <input
          type="text"
          {...register("email", {
            required: true,
            maxLength: 50,
            minLength: 3,
            pattern: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i,
            validate: value => emailExists === true
          })}
          placeholder="example@mail.com"
        />
        {errors?.email?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.email?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>Email cannot be less than 3 characters</p>
        )}
        {errors?.email?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>Email cannot exceed 50 characters</p>
        )}
        {errors?.email?.type === "pattern" && (
          <p className={classes.ErrorParagraph}>Not good email format</p>
        )}
        {/*errors?.email?.type === "validate" &&  <p className={classes.ErrorParagraph}>Email is already in the database</p>*/}
        {!emailExists &&  <p className={classes.ErrorParagraph}>Email is already in the database</p>}

        <label>Password</label>
        <input
          type="password"
          {...register("password", {
            required: true,
            maxLength: 20,
            minLength: 3
          })}
          placeholder="••••••••"
        />
        {errors?.password?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.password?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>Password cannot be less than 3 characters</p>
        )}
        {errors?.password?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>Password cannot exceed 20 characters</p>
        )}

        <label>Re-Password</label>
        <input
          type="password"
          {...register("password2", {
            required: true,
            maxLength: 20,
            minLength: 3,
          })}
          placeholder="••••••••"
        />
        {errors?.password2?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.password2?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>Password cannot be less than 3 characters</p>
        )}
        {errors?.password?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>Password cannot exceed 20 characters</p>
        )}
        {watch("password2") !== watch("password") &&
          getValues("password2") ? (
          <p className={classes.ErrorParagraph}>Passwords not match</p>
        ) : null}


        <input type="submit" />
      </form>
    </>
  );
}


