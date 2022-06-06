import { useForm } from "react-hook-form";
import classes from './RegistrationForm.module.css'

interface IFormInput {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  password2: string;
}

export const RegistrationForm = (props) => {

  const {
    register,
    handleSubmit,
    watch,
    getValues,
    formState: { errors }
  } = useForm<IFormInput>();

  const onSubmit = (data: IFormInput) => {
    alert(JSON.stringify(data));
  }; 


  return (
    <>
      <h1 className={classes.headerText}>Registration</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <label>First Name</label>
        <input
          type="text"
          {...register("firstName", {
            required: true,
            maxLength: 20,
            minLength: 3,
            pattern: /^[A-Za-záéúőóüö]+$/i
          })}
        />
        {errors?.firstName?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.firstName?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>First name cannot be less than 3 characters</p>
        )}
        {errors?.firstName?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>First name cannot exceed 20 characters</p>
        )}
        {errors?.firstName?.type === "pattern" && (
          <p className={classes.ErrorParagraph}>Alphabetical characters only</p>
        )}


        <label>Last Name</label>
        <input
          type="text"
          {...register("lastName", {
            required: true,
            maxLength: 20,
            minLength: 3,
            pattern: /^[A-Za-záéúőóüö]+$/i
          })}
        />
        {errors?.lastName?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.lastName?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>Last name cannot be less than 3 characters</p>
        )}
        {errors?.lastName?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>Last name cannot exceed 20 characters</p>
        )}
        {errors?.lastName?.type === "pattern" && (
          <p className={classes.ErrorParagraph}>Alphabetical characters only</p>
        )}

        <label>Email</label>
        <input
          type="text"
          {...register("email", {
            required: true,
            maxLength: 20,
            minLength: 3,
            pattern: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i
            //email already in database
          })}
        />
        {errors?.email?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.email?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>Email cannot be less than 3 characters</p>
        )}
        {errors?.email?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>Email cannot exceed 20 characters</p>
        )}
        {errors?.email?.type === "pattern" && (
          <p className={classes.ErrorParagraph}>Not good email address</p>
        )}

        <label>Password</label>
        <input
          type="password"
          {...register("password", {
            required: true,
            maxLength: 20,
            minLength: 3
          })}
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


