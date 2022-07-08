import React, { useEffect, useState } from "react";
import { Card } from "react-bootstrap";
import classes from "./EditStudentInformation.module.css";
import IStudent from "../../IStudent";

interface IEditStudentInformationProps {
  studentData: IStudent;
  onEditStudentHandler: (student: IStudent) => void;
}

export const EditStudentInformation = (props: IEditStudentInformationProps) => {
  const [dataChange, setDataChange] = useState(false);
  const [id, setId] = useState(0);
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [technologies, setTechnologies] = useState("");
  const [fbGroup, setFbGroup] = useState(true);
  const [scholarship, setScholarship] = useState(true);
  const [internship, setInternship] = useState(true);

  /*
  const [hasError, setHasError] = useState(false);
  const [fullNameError, setFullNameError] = useState(false);
  const [emailError, setEmailError] = useState(false);
  const [phoneNumberError, setPhoneNumberError] = useState(false);
  const [technologiesError, setTechnologiesError] = useState(false);
  const [fbGroupError, setFbGroupError] = useState(false);
  const [scholarshipError, setScholarshipError] = useState(false);
  const [internshipError, setInternshipError] = useState(false);
*/

  const onSubmit = (event: React.SyntheticEvent) => {
    event.preventDefault();
    if (dataChange) {
      const userData: IStudent = {
        id: id,
        fullName: fullName,
        email: email,
        phoneNumber: phoneNumber,
        technologies: technologies,
        studies: "",
        fbGroup: fbGroup,
        scholarship: scholarship,
        internship: internship,
      };
      props.onEditStudentHandler(userData);
      setDataChange(false);
    }
  };

  useEffect(() => {
    setId(props.studentData.id);
    setFullName(props.studentData.fullName);
    setEmail(props.studentData.email);
    setPhoneNumber(props.studentData.phoneNumber);
    setTechnologies(props.studentData.technologies);
    setFbGroup(props.studentData.fbGroup);
    setScholarship(props.studentData.scholarship);
    setInternship(props.studentData.internship);
  }, [props.studentData]);

  const fullNameChangeHandler = (event) => {
    setFullName(event.target.value);
    if (event.target.value !== props.studentData.fullName) {
      setDataChange(true);
      return;
    }
    setDataChange(false);
  };

  const emailChangeHandler = (event) => {
    setEmail(event.target.value);
    if (event.target.value !== props.studentData.email) {
      setDataChange(true);
      return;
    }
    setDataChange(false);
  };

  const phoneNumberChangeHandler = (event) => {
    setPhoneNumber(event.target.value);
    if (event.target.value !== props.studentData.phoneNumber) {
      setDataChange(true);
      return;
    }
    setDataChange(false);
  };

  const technologiesChangeHandler = (event) => {
    setTechnologies(event.target.value);
    if (event.target.value !== props.studentData.technologies) {
      setDataChange(true);
      return;
    }
    setDataChange(false);
  };

  const fbGroupChangeHandler = (event) => {
    if (event.target.value === "true") {
      setFbGroup(true);
    } else {
      setFbGroup(false);
    }

    if (event.target.value !== props.studentData.fbGroup) {
      setDataChange(true);
      return;
    }
    setDataChange(false);
  };

  const scholarshipChangeHandler = (event) => {
    if (event.target.value === "true") {
      setScholarship(true);
    } else {
      setScholarship(false);
    }

    if (event.target.value !== props.studentData.scholarship) {
      setDataChange(true);
      return;
    }
    setDataChange(false);
  };

  const internshipChangeHandler = (event) => {
    if (event.target.value === "true") {
      setInternship(true);
    } else {
      setInternship(false);
    }

    if (event.target.value !== props.studentData.internship) {
      setDataChange(true);
      return;
    }
    setDataChange(false);
  };

  return (
    <>
      {/**
       * TODO: validation
       */}
      <Card className={classes.card}>
        <Card.Header>Profile Data:</Card.Header>
        <Card.Body>
          <form onSubmit={onSubmit}>
            <div className={classes.formElements}>
              <div className={classes.formElement}>
                <input
                  type="text"
                  placeholder="Név"
                  value={fullName}
                  minLength={3}
                  required
                  onChange={fullNameChangeHandler}
                />
              </div>
              <div className={classes.formElement}>
                <input
                  type="email"
                  placeholder="Email"
                  value={email}
                  onChange={emailChangeHandler}
                />
              </div>
              <div className={classes.formElement}>
                <input
                  type="text"
                  placeholder="Telefonszám"
                  minLength={3}
                  required
                  value={phoneNumber}
                  onChange={phoneNumberChangeHandler}
                />
              </div>
              <div className={classes.formElement}>
                <input
                  type="text"
                  placeholder="Technológiák"
                  value={technologies}
                  minLength={3}
                  required
                  onChange={technologiesChangeHandler}
                />
              </div>
              <div className={classes.formElement}>
                <div>
                  <label>Facebook csoport</label>
                </div>

                <select onChange={fbGroupChangeHandler}>
                  <option selected={fbGroup} value="true">
                    Bent van
                  </option>
                  <option selected={!fbGroup} value="false">
                    Nincs benne
                  </option>
                </select>
              </div>
              <div className={classes.formElement}>
                <div className="">
                  <label>Ösztöndíj</label>
                </div>
                <select onChange={scholarshipChangeHandler}>
                  <option selected={scholarship} value="true">
                    Kap
                  </option>
                  <option selected={!scholarship} value="false">
                    Nem kap
                  </option>
                </select>
              </div>
              <div className={classes.formElement}>
                <div className="">
                  <label>Szakami Gyakorlat</label>
                </div>
                <select onChange={internshipChangeHandler}>
                  <option selected={internship} value="true">
                    Részt vesz
                  </option>
                  <option selected={!internship} value="false">
                    Nem vesz részt
                  </option>
                </select>
              </div>

              <input
                className={dataChange && classes.dataChanged}
                type="submit"
              />
            </div>
          </form>
        </Card.Body>
      </Card>
    </>
  );
};
