import React from 'react'
import IStudent from '../IStudent';
import { EditStudentInformation } from './EditStudentProfileItems/EditStudentInformation'

interface IEditStudentProfile{
  studentData: IStudent;
}

export const EditStudentProfile = (props:IEditStudentProfile) => {
  return (
      <EditStudentInformation studentData={props.studentData}/>
  )
}
