import React, { useDebugValue, useEffect, useState } from "react";
import { ButtonGroup, Dropdown, ToggleButton } from "react-bootstrap";
import ISession from "../../ISession";
import { UnauthorizedModal } from "../UI/UnauthorizedModal";
import { EditStudentProfile } from "./EditStudentProfile/EditStudentProfile";
import { ViewStudentProfile } from "./ViewStudentProfile/ViewStudentProfile";
import classes from "./StudentProfile.module.css";
import IStudent from "./IStudent";

//https://localhost:3000/Components/StudentProfile/StudentProfile
//props: student id

interface IStudentProfile {
  studentId: number;
}

export const StudentProfile = (
  { session }: { session: ISession },
  props: IStudentProfile
) => {
  const [editStudentProfile, setEditStudentProfile] = useState("1");
  //Itt lesz a useeffect ami az id alapján lekérdezi az adatott a backend-ről
  const [student, setStudent] = useState<IStudent>({
    id: 0,
    fullName: "Teszt Benő",
    studies: "2020.09.03. - 2023.06.10.",
    technologies: "java, javascript",
    scholarship: true,
    email: "teveklub@freemail.hu",
    phoneNumber: "+36363636363",
    fbGroup: true,
    internship: false,
  });
  //const [students, setStudents] = useState<Array<IStudent>>([]);

  useEffect(() => {
    fetch("http://localhost:7043/api/Student/Students", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Connection: "keep-alive",
      },
      credentials: "include",
    })
      .then(function (data) {
        if (data.status === 200) {
          console.log(data[0]);
        } else {
        }
      })
      .catch(function (error) {
        console.log(error);
      });
  });

  if (session.id > 0) {
    const buttonElements = [
      { name: "View", value: "1" },
      { name: "Edit", value: "2" },
    ];

    //TODO: fetch the student data from backend with the given id

    return (
      <>
        <div>
          <ButtonGroup className={classes.toggleButtonPosition}>
            {buttonElements.map((radio, idx) => (
              <ToggleButton
                key={idx}
                id={`radio-${idx}`}
                type="radio"
                variant={idx % 2 ? "outline-success" : "outline-danger"}
                name="radio"
                value={radio.value}
                checked={editStudentProfile === radio.value}
                onChange={(e) => setEditStudentProfile(e.currentTarget.value)}
              >
                {radio.name}
              </ToggleButton>
            ))}
          </ButtonGroup>

          <select className={classes.dropDown}>
            <option value="">Válasz egy profilt</option>
          </select>
        </div>

        {student.id > 0 && (
          <div>
            {editStudentProfile === "1" ? (
              <ViewStudentProfile studentData={student} />
            ) : (
              <div>
                <EditStudentProfile studentData={student} />
              </div>
            )}
          </div>
        )}
      </>
    );
  } else {
    return <UnauthorizedModal />;
  }
};
