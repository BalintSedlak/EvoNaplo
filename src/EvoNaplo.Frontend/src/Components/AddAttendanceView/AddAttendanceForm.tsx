import React, { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";
import { StudentInput } from "./StudentInput";

const DUMMY_DATA = [
  {
    projectId: 1,
    students: ["Kis Bélus", "Nagy Bélus", "Közepes Béla"],
  },
  {
    projectId: 2,
    students: ["Kis Béla", "Nagy Béla"],
  },
];

const WEEK = ["1. Hét", "2. Hét", "3. Hét"];

export const AddAttendanceForm = (props) => {
  const [selectedProject, setSelectedProject] = useState("");
  const [selectedWeek, setSelectedWeek] = useState("");
  const [projectDetails, setProjectDetails] = useState([]);

  useEffect(() => {
    setProjectDetails(
      DUMMY_DATA.filter((x) => x.projectId.toString() === selectedProject)
    );
  }, [selectedProject]);

  const handleProjectChange = (e) => {
    console.log(e.target.value);
    setSelectedProject(e.target.value);
  };

  const handleWeekChange = (e) => {
    console.log(e.target.value);
    setSelectedWeek(e.target.value);
  }

  return (
    <>
      <div className="m-5">
        <Form.Select
          aria-label="Default select example"
          onChange={(e) => handleProjectChange(e)}
        >
          <option>Open this select menu</option>
          {props.ActualProjects.map((data) => (
            <option key={data.id} value={data.id}>
              {data.project}
            </option>
          ))}
        </Form.Select>

        <Form.Select className="mt-2" onChange={(e) => handleWeekChange(e)}>
        <option>Open to select the week</option>
            {WEEK.map(x => <option>{x}</option>)}
        </Form.Select>
      </div>

      <div>
        {projectDetails.length > 0 && (
          <div>
            {projectDetails.map((x) =>
              x.students.map((x) => <StudentInput studentName={x} project={selectedProject} week={selectedWeek}/>)
            )}
            <div
              style={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                margin: "1rem",
              }}
            >
            </div>
          </div>
        )}
      </div>
    </>
  );
};
