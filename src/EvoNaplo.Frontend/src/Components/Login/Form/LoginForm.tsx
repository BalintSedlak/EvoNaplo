import { useForm } from "react-hook-form";
import { ILogin } from "./ILogin";
import classes from './LoginForm.module.css'


export const LoginForm = (props) => {

  const {
    register,
    handleSubmit,
    formState: { errors }
  } = useForm<ILogin>();

  const onSubmit = (data: ILogin) => {
    props.onLogin(data);
  };


  return (
    <>
      <h1 className={classes.headerText}>Login</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        

        <label>Email</label>
        <input
          type="text"
          {...register("email", {
            required: true,
            maxLength: 50,
            minLength: 3,
            pattern: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i
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
          placeholder="••••••••"
        />
        {errors?.password?.type === "required" && <p className={classes.ErrorParagraph}>This field is required</p>}
        {errors?.password?.type === "minLength" && (
          <p className={classes.ErrorParagraph}>Password cannot be less than 3 characters</p>
        )}
        {errors?.password?.type === "maxLength" && (
          <p className={classes.ErrorParagraph}>Password cannot exceed 20 characters</p>
        )} 

        <input type="submit" />
      </form>
    </>
  );
}


