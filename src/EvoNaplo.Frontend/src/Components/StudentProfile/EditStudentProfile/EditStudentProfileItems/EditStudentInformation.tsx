import React from "react";
import { Button, Card, Form } from "react-bootstrap";
import classes from "./EditStudentInformation.module.css";
import IStudent from "../../IStudent";
import { useForm } from "react-hook-form";

interface EditStudentInformationProps {
  givenStudentData: IStudent;
}

export const EditStudentInformation = () => {


  const onSubmit = (event: React.SyntheticEvent) => {
    event.preventDefault();
  };

  return (
    <>
      {/*
          <blockquote className="blockquote mb-0">
            <div className="">
              <p> Full Name: Kis Béla</p>
            </div>

            <p> Email</p>
            <p> Phone Number</p>
            <p> Studies: Egyetem</p>
            <p> Technologies: C#</p>
            <p> Fb Group</p>
            <p> Scholarship: No</p>
            <p> Internship </p>
          </blockquote>
  */}

{/**
 * TODO: design befejezés
 * TODO: adatokkal való feltöltés
 */}
      <Card className="m-5">
        <Card.Header>Profile Data:</Card.Header>
        <Card.Body>
          <form onSubmit={onSubmit}>
            <div className={classes.formElements}>
              <div className={classes.formElement}>
                <label>Név</label>
                <input type="text" placeholder="Joseph" />
              </div>
              <div className={classes.formElement}>
                <label>Email</label>
                <input type="email" placeholder="Joseph" />
              </div>
              <div className={classes.formElement}>
                <label>Telefonszám</label>
                <input type="text" placeholder="Joseph" />
              </div>
              <div className={classes.formElement}>
                <label>Technológiák</label>
                <input type="text" placeholder="Joseph" />
              </div>
              <div className={classes.formElement}>
                <label>Facebook csoport</label>
                <select>
                  <option value="true">Bent van</option>
                  <option value="false">Nincs benne</option>
                </select>
              </div>
              <div className={classes.formElement}>
                <label>Ösztöndíj</label>
                <select>
                  <option value="true">Kap</option>
                  <option value="false">Nem kap</option>
                  <option value="on">Pályázott</option>
                </select>
              </div>
              <div className={classes.formElement}>
                <label>Szakami Gyakorlat</label>
                <select>
                <option value="true">Részt vesz</option>
                  <option value="false">Nem vesz részt</option>
                  <option value="on">Pályázott</option>
                </select>
              </div>

              <input type="submit" />
            </div>
          </form>
        </Card.Body>
      </Card>
    </>
  );
};
