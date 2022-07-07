import React from 'react'
import IStudent from '../IStudent';
import { EditStudentInformation } from './EditStudentProfileItems/EditStudentInformation'

interface IEditStudentProfile{
  studentData: IStudent;
}

export const EditStudentProfile = (props:IEditStudentProfile) => {

  const handleEdit = (student: IStudent) => {
    fetch("http://localhost:7043/api/Student/EditStudent", {
      mode: "cors",
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(student),
    })
      .then((res) => {
        if (res.status === 200) {
        } else {
          alert("Something went wrong");
        }
      })
      .catch(function (error) {
        console.log(error);
      });
  }

  return (
      <EditStudentInformation studentData={props.studentData} onEditStudentHandler={handleEdit}/>
  )
}
