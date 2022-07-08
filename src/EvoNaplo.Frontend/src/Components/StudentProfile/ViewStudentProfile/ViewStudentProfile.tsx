import React, { useEffect, useState } from "react";
import { Card } from "react-bootstrap";
import IStudent from "../IStudent";
import ProfileComment from "./ProfileComment";
import ProgressBySemester from "./ProgressBySemester";
import Scholarship from "./Scholarship";
import classes from "./ViewStudentProfile.module.css";
import "./UserPageView.css";

interface IViewStudentProfile {
  studentData: IStudent;
}

export const ViewStudentProfile = (props: IViewStudentProfile) => {
  const [id, setId] = useState(0);
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [technologies, setTechnologies] = useState("");
  const [fbGroup, setFbGroup] = useState(true);
  const [scholarship, setScholarship] = useState(true);
  const [internship, setInternship] = useState(true);

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

  return (
    <>
      <Card className={classes.card}>
        <Card.Header>Profile Data:</Card.Header>
        <Card.Body>
          <div className={classes.formElements}>
            <div className={classes.formElement}>
              <input disabled type="text" placeholder="Név" value={fullName} />
            </div>
            <div className={classes.formElement}>
              <input disabled type="email" placeholder="Email" value={email} />
            </div>
            <div className={classes.formElement}>
              <input
                disabled
                type="text"
                placeholder="Telefonszám"
                value={phoneNumber}
              />
            </div>
            <div className={classes.formElement}>
              <input
                disabled
                type="text"
                placeholder="Technológiák"
                value={technologies}
              />
            </div>
            <div className={classes.formElement}>
              <div>
                <label>Facebook csoport</label>
              </div>

              <select disabled>
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
              <select disabled>
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
              <select disabled>
                <option selected={internship} value="true">
                  Részt vesz
                </option>
                <option selected={!internship} value="false">
                  Nem vesz részt
                </option>
              </select>
            </div>
          </div>
        </Card.Body>
      </Card>
    </>
  );
};

/*
        <div className="DivCard">
            <tr><th>Név</th></tr>
            <tr>{student?.fullName}</tr>
            <tr><th>Tanulmányok</th></tr>
            <tr>{student?.studies}</tr>
            <tr><th>Technológiák</th></tr>
            <tr>{student?.technologies}</tr>
            {/* 
            <tr><th>Jelenlét</th></tr>
            <tr><ul><ProgressBySemester data={student?.attendance}/></ul></tr>
            <tr><th>Mentorok</th></tr>
            <tr><ul>{student?.mentors.map((i) => { return (<li>{i}</li>) })}</ul></tr>
            <tr><th>Csapatok</th></tr>
            <tr><ul>{student?.teams.map((i) => { return (<li>{i}</li>) })}</ul></tr>
            
            <tr><th>Email</th></tr>
            <tr>{student?.email}</tr>
            <tr><th>Telefonszám</th></tr>
            <tr>{student?.phoneNumber}</tr>
            <tr><th>Ösztöndíj</th></tr>
            {<Scholarship data={student.scholarship} />}
            <tr><th>Facebook csoport</th></tr>
            <tr>{<input type="checkbox" checked={student?.fbGroup} readOnly={true}></input>}</tr>
            <tr><th>Szakmai Gyakorlat</th></tr>
            <tr>{<input type="checkbox" checked={student?.internship} readOnly={true}></input>}</tr>
            <tr><th>Komment</th></tr>
            <ProfileComment data={student?.comment}/>
            
        </div>
        */
