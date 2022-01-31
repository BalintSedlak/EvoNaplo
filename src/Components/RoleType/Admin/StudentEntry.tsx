import React, { useState } from 'react';
import IStudentEntry from './IStudentEntry';

const StudentEntry = (studentEntry: IStudentEntry) => {
    return (
    <tr>
        <td>{studentEntry.fullname}</td>
        <td>{studentEntry.email}</td>
        <td>{studentEntry.phoneNumber}</td>
        <td>{studentEntry.semester}</td>
        <td>{studentEntry.project}</td>
        <td>{studentEntry.mentors}</td>
        <td>{studentEntry.dateOfClass}</td>
        <td>{studentEntry.typeOfClass}</td>
        <td>{studentEntry.technology}</td>
        <td><input type="checkbox" checked={studentEntry.isInFacebookGroup} readOnly={true}/></td>
        <td><input type="checkbox" checked={studentEntry.isAppliedForScholarship} readOnly={true}/></td>
        <td><input type="checkbox" checked={studentEntry.isAppliedForSummerJob} readOnly={true}/></td>
        <td>{studentEntry.participationPercent}%</td>
    </tr>
    )
  }

export default StudentEntry;