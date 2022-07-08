import { useState } from "react";
import { useForm } from "react-hook-form";
import { IStudent } from "./IStudent";
import classes from "./AddStudent.module.css";
import ISession from "../../../ISession";

const AddStudent = ({ session }: { session: ISession }) => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<IStudent>();
  const [data, setData] = useState("");
  //optgroup: team kiválasztásnál akár mentorok nevét le lehetne írni
  return (
    <div className={classes.AddStudentCard}>
      <h1 className={classes.headerText}>Diák hozzáadás</h1>
      <form onSubmit={handleSubmit((data) => setData(JSON.stringify(data)))}>
        <label>
          <tr>
            <th>Név</th>
          </tr>
          <input
            type="text"
            {...register("fullname", {
              required: true,
              pattern: /^[A-Za-záéúőóüö ]+$/i,
            })}
          />
          {errors?.fullname?.type === "required" && (
            <p className={classes.ErrorParagraph}>This field is required</p>
          )}
          <tr>
            <th>Tanulmányok</th>
          </tr>
          <input
            type="text"
            {...register("studies", {
              required: true,
              pattern: /^[A-Za-záéúőóüö ]+$/i,
            })}
          />
          {errors?.studies?.type === "required" && (
            <p className={classes.ErrorParagraph}>This field is required</p>
          )}
          <tr>
            <th>Technológiák</th>
          </tr>
          <input
            type="text"
            {...register("technology", { required: true })}
            placeholder="pl. Java, C#"
          />
          {errors?.technology?.type === "required" && (
            <p className={classes.ErrorParagraph}>This field is required</p>
          )}
          <tr>
            <th>Csapat</th>
          </tr>
          <select
            className={classes.SelectTeam}
            {...register("team", { required: true })}
            placeholder="Select..."
          >
            <option disabled selected value="">
              Válassz egyet
            </option>
            <option value="evoNaplo">evoNaplo</option>
            <option value="evoFlix">evoFlix</option>
            <option value="evoRPG">evoRPG</option>
          </select>
          {errors?.team?.type === "required" && (
            <p className={classes.ErrorParagraph}>This field is required</p>
          )}
          <tr>
            <th>Email</th>
          </tr>
          <input
            type="text"
            {...register("email", {
              required: true,
              pattern: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/i,
            })}
            placeholder="example@mail.com"
          />
          {errors?.email?.type === "required" && (
            <p className={classes.ErrorParagraph}>This field is required</p>
          )}
          {errors?.email?.type === "pattern" && (
            <p className={classes.ErrorParagraph}>Nem megfelelő e-mail cím.</p>
          )}
          <tr>
            <th>Telefonszám</th>
          </tr>
          <input
            type="text"
            {...register("phone", {
              required: true,
              pattern: /^[+][0-9]{11}|[+][0-9\s]{14}|[0-9]{11}|[0-9\s]{14}$/i,
            })}
            placeholder="+36303334444"
          />
          {errors?.phone?.type === "required" && (
            <p className={classes.ErrorParagraph}>This field is required</p>
          )}
          {errors?.phone?.type === "pattern" && (
            <p className={classes.ErrorParagraph}>
              A telefonszámnak az alábbi mintának kell megfelelnie: +36 30 333
              4444, +36303334444, 06 30 333 4444, 06303334444
            </p>
          )}
          {data}
        </label>
        <div>
            <th>Hozzáadás a mostani szemeszterhez <input className="m-0" type="checkbox" value="true" /></th> 
          </div>
        <input type="submit" value="Submit" />
      </form>
    </div>
  );
};
export default AddStudent;
