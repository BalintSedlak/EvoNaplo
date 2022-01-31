import React, { useState } from 'react';
import ListAttendancesEntry from './ListAttendancesEntry';

const ListAttendances = () => {
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

    const filterStudentsBySemester = (filterString: string) => {
        setStudentSemesterFilter(filterString);
        filterStudents(filterString, studentProjectFilter);
    }

    const filterStudentsByProject = (filterString: string) => {
        setStudentProjectFilter(filterString);
        filterStudents(studentSemesterFilter,filterString);
    }


    function filterStudents(semesterFilter: string, projectFilter: string){
        let filteredStudents = students.filter(student => student.semester === semesterFilter && student.project === projectFilter)
        setStudentListFilter(filteredStudents);
    }

    return (
        <div>
            Jelenléti ív (Admin)<br/>
            <label>
                Semester:
                <select onChange={e => filterStudentsBySemester(e.target.value)}>
                    <option value={1}>1</option>
                    <option value={2}>2</option>
                    <option value={3}>3</option>
                </select>
            </label>

            <label>
                Project:
                <select onChange={e => filterStudentsByProject(e.target.value)}>
                    <option value={1}>1</option>
                    <option value={2}>2</option>
                </select>
            </label>

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
                {filteredStudentList.map((student) => <ListAttendancesEntry fullname={student.fullname}/>)}
            </table>
            <br/>
        </div>
        
    )
}    

export default ListAttendances;