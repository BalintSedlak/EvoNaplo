import React from 'react'
import IStudent from '../IStudent';
import { StudentProfileData } from './ViewStudentProfileItems/StudentProfileData';

interface IEditStudentProfile{
  studentData: IStudent;
}

export const ViewStudentProfile = (props:IEditStudentProfile) => {

  
  return (
      <StudentProfileData studentData={props.studentData} />
  )
}
