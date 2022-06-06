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
    formState: { errors }
  } = useForm<IFormInput>();

  const onSubmit = (data: IFormInput) => {
    alert(JSON.stringify(data));
  }; // your form submit function which will invoke after successful validation


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
            pattern: /^[A-Za-z]+$/i
          })}
        />
        {errors?.firstName?.type === "required" && <p>This field is required</p>}
        {errors?.firstName?.type === "maxLength" && (
          <p>First name cannot exceed 20 characters</p>
        )}
        {errors?.firstName?.type === "pattern" && (
          <p>Alphabetical characters only</p>
        )}
        <label>Laste Name</label>
        <input {...register("lastName", { pattern: /^[A-Za-z]+$/i })} />
        {errors?.lastName?.type === "pattern" && (
          <p>Alphabetical characters only</p>
        )}

        <input type="submit" />
      </form>
    </>
  );
}


