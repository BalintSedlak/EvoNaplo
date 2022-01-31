import React, { useState } from 'react';
import AddAttendanceEntry from './AddAttendanceEntry';

const AddAttendance = () => {
    const students = [
        {
            fullname: "Név1",
            semester: '1',
            project: '2',
        },
        {
            fullname: "Név2",
            semester: '2',
            project: '1',
        },
        {
            fullname: "Név3",
            semester: '1',
            project: '2',
        }
    ]

    const [filteredStudentList, setStudentListFilter] = useState(students);
    const [studentSemesterFilter, setStudentSemesterFilter] = useState("1");
    const [studentProjectFilter, setStudentProjectFilter] = useState("1");

    function filterStudents(semesterFilter: string, projectFilter: string){
        let filteredStudents = students.filter(student => student.semester === semesterFilter && student.project === projectFilter)
        setStudentListFilter(filteredStudents);
    }

    return (
        <div>
            Jelenléti ív leadása (Mentor) <br/>
            <table>
                <tr>
                    <th></th>
                    <th>1. hét<br/> 2021.02.02-<br/>2021.02.08</th>
                    <th>2. hét<br/> 2021.02.02-<br/>2021.02.08</th>
                    <th>3. hét<br/> 2021.02.02-<br/>2021.02.08</th>
                    <th>4. hét<br/> 2021.02.02-<br/>2021.02.08</th>
                    <th>5. hét<br/> 2021.02.02-<br/>2021.02.08</th>
                    <th>6. hét<br/> 2021.02.02-<br/>2021.02.08</th>
                </tr>
                {filteredStudentList.map((student) => <AddAttendanceEntry fullname={student.fullname}/>)}
            </table>
            <label>
                <input type="button" value="Submit"/>
            </label>
            <br/>
        </div>
        
    )
}    

export default AddAttendance;