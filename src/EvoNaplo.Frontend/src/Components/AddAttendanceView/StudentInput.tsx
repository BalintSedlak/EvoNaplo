import React, { useEffect, useState } from "react";
import { Button, Form, ListGroup } from "react-bootstrap";

const ATTENDANCE_TYPE = ["Online", "Offline", "Not Attended"];

export const StudentInput = (props) => {
  //Olyan controller kellesz majd ami a project, és név alapján menti el az adatott

  const [selectAttendance, setSelectAttendance] = useState("");

  useEffect(() => {
    if (selectAttendance !== "Open to select the week") {
      console.log(
        `${props.studentName} on project id: ${props.project} in ${props.week} is ${selectAttendance}`
      );
    }
  }, [selectAttendance]);

  const handleAttendanceChange = (e) => {
    //console.log(e.target.value);
    setSelectAttendance(e.target.value);
  };

  return (
    <>
      <div
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
          margin: "1rem",
        }}
      >
        <ListGroup horizontal style={{ maxWidth: "800px" }}>
          <ListGroup.Item style={{ width: "140px", textAlign: "center" }}>
            {props.studentName}
          </ListGroup.Item>
          <ListGroup.Item style={{ width: "300px" }}></ListGroup.Item>
          <ListGroup.Item style={{ minWidth: "120px" }}>
            <Form.Select
              className="mt-2"
              onChange={(e) => handleAttendanceChange(e)}
            >
              <option>Open to select the week</option>
              {ATTENDANCE_TYPE.map((x) => (
                <option>{x}</option>
              ))}
            </Form.Select>
          </ListGroup.Item>
        </ListGroup>
      </div>
    </>
  );
};
