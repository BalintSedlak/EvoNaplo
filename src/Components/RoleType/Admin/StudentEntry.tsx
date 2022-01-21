import React, { useState } from 'react';
import IStudentEntry from './IStudentEntry';

const StudentEntry = (props: IStudentEntry) => {
    return (
    <tr>
        <td>{props.fullname}</td>
        <td>{props.email}</td>
        <td>{props.phoneNumber}</td>
        <td>{props.semester}</td>
        <td>{props.project}</td>
        <td>{props.mentors}</td>
        <td>{props.dateOfClass}</td>
        <td>{props.typeOfClass}</td>
        <td>{props.technology}</td>
        <td><input type="checkbox" checked={props.isInFacebookGroup} readOnly={true}/></td>
        <td><input type="checkbox" checked={props.isAppliedForScholarship} readOnly={true}/></td>
        <td><input type="checkbox" checked={props.isAppliedForSummerJob} readOnly={true}/></td>
        <td>{props.participationPercent}%</td>
    </tr>
    )
  }

export default StudentEntry;