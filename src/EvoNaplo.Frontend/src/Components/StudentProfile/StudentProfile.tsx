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
  const [students, setStudents] = useState<Array<IStudent>>([]);
  const [activeDropdownElementId, setActiveDropdownElementId] = useState("");

  useEffect(() => {
    fetch("http://localhost:7043/api/Student/Students")
      .then((response) => response.json())
      .then((json) => setStudents(json));
  }, []);

  useEffect(() => {

    fetch(`http://localhost:7043/api/Student/GetStudentById?id=${activeDropdownElementId}`)
      .then((response) => response.json())
      .then((json) => setStudent(json));

  }, [activeDropdownElementId])


  if (session.id > 0) {
    const buttonElements = [
      { name: "View", value: "1" },
      { name: "Edit", value: "2" },
    ];

    const studentChangeHandler = (event) => {
      setActiveDropdownElementId(event.target.value);
    }

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

          <select className={classes.dropDown} onChange={studentChangeHandler}>
            <option value="0">Válasz egy profilt</option>
            {students.map(e =>
              <option key={e.id} value={e.id}>{e.id} - {e.fullName}</option>
            )
            }
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
