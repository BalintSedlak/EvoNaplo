import { type } from 'os';
import React, { useEffect,useState } from 'react';
import { fileURLToPath } from 'url';
import IStudentEntry from './IStudentEntry';
import StudentEntry from './StudentEntry';

const ListStudents = () => {
    const students = [
        {
            fullname: "Név1",
            email: "nev1@email.com",
            phoneNumber: "+3621423423",
            semester: "5",
            project: "Project1",
            mentors: "ASD, QWE",
            dateOfClass: "Péntek 14:00",
            typeOfClass: "Online",
            technology: "ASP.Net Core, React",
            isInFacebookGroup: true,
            isAppliedForScholarship: true,
            isAppliedForSummerJob: true,
            participationPercent: 80
        },
        {
            fullname: "Név2",
            email: "nev2@email.com",
            phoneNumber: "+3621424454",
            semester: "4",
            project: "Project2",
            mentors: "ASD, Rtz",
            dateOfClass: "Péntek 10:00",
            typeOfClass: "Offline",
            technology: "Java Spring, Angular",
            isInFacebookGroup: false,
            isAppliedForScholarship: false,
            isAppliedForSummerJob: false,
            participationPercent: 86
        },
        {
            fullname: "Név3",
            email: "nev3@email.com",
            phoneNumber: "+36214245656",
            semester: "5",
            project: "Project3",
            mentors: "HJK",
            dateOfClass: "Szerda 14:00",
            typeOfClass: "Online",
            technology: "ASP.Net Core, Angular",
            isInFacebookGroup: false,
            isAppliedForScholarship: true,
            isAppliedForSummerJob: false,
            participationPercent: 60
        }
    ];
    
    const [filteredStudentList, setStudentListFilter] = useState(students);
    const [studentNameFilter, setStudentNameFilter] = useState("");
    const [studentSemesterFilter, setStudentSemesterFilter] = useState("");
    const [studentScholarshipFilter, setStudentScholarshipFilter] = useState(false);

    function ifBranching(name: string, semester: string, scholarship: boolean) {
        if(scholarship === true && semester === "0")
            filterStudents(name,"",true);
        else if(scholarship === true && !(semester === "0"))
            filterStudents(name,semester,true);
        else if(semester === "0")
            filterStudents(name,"")
        else
            filterStudents(name,semester); 
    }

    const filterStudentsByName = (filterString: string) => {
        setStudentNameFilter(filterString);
        ifBranching(filterString,studentSemesterFilter,studentScholarshipFilter);
    }

    const filterStudentsBySemester = (filterString: string) => {
        setStudentSemesterFilter(filterString);
        ifBranching(studentNameFilter,filterString,studentScholarshipFilter);
    }
    const filterStudentsByScholarship = (filterBoolean: boolean) => {
        setStudentScholarshipFilter(filterBoolean);
        ifBranching(studentNameFilter,studentSemesterFilter,filterBoolean);
    }
    
    function filterStudents(nameFilter: string, semesterFilter: string, scholarshipFilter?: boolean) {
        let filteredStudents;
        if(scholarshipFilter === true)
            filteredStudents = students.filter(student => student.fullname.toLowerCase().includes(nameFilter.toLowerCase())
            && student.semester.toLowerCase().includes(semesterFilter.toLowerCase())
            && student.isAppliedForScholarship === scholarshipFilter);
        else
            filteredStudents = students.filter(student => student.fullname.toLowerCase().includes(nameFilter.toLowerCase())
            && student.semester.toLowerCase().includes(semesterFilter.toLowerCase()));

        setStudentListFilter(filteredStudents);
    }
    
    return (
        <div>

            <label>
                Név:
                <input type="text" name="fullname" onChange={e => filterStudentsByName(e.target.value)}/>
            </label>
             
            <label>
                
                Semester:
                <select onChange={e => filterStudentsBySemester(e.target.value)}>
                    <option value={0}>Összes</option>
                    <option value={1}>1</option>
                    <option value={2}>2</option>
                    <option value={3}>3</option>
                    <option value={4}>4</option>
                    <option value={5}>5</option>
                    <option value={6}>6</option>
                </select>
                
            </label>

            <label>
                Ösztöndíjra jelentkezett?
                <input type="checkbox" name='isAppliedForScholarship' onChange={e => filterStudentsByScholarship(e.target.checked)} />
            </label>

            <table>
                <tr>
                    <th>Név</th>
                    <th>Email</th>
                    <th>Telefonszám</th>
                    <th>Szemeszter</th>
                    <th>Project</th>
                    <th>Mentorok</th>
                    <th>Időpont</th>
                    <th>Online/offline</th>
                    <th>Technologia</th>
                    <th>Facebook csoportban van?</th>
                    <th>Ösztöndíjra jelentkezett?</th>
                    <th>Nyári gyakra jelentkezett?</th>
                    <th>Részvétel</th>
                    <th>Profil</th>
                </tr>
                {filteredStudentList.map((student) => <StudentEntry
                    fullname={student.fullname}
                    email={student.email}
                    phoneNumber={student.phoneNumber}
                    semester={student.semester}
                    project={student.project}
                    mentors={student.mentors}
                    dateOfClass={student.dateOfClass}
                    typeOfClass={student.typeOfClass}
                    technology={student.technology}
                    isInFacebookGroup={student.isInFacebookGroup}
                    isAppliedForScholarship={student.isAppliedForScholarship}
                    isAppliedForSummerJob={student.isAppliedForSummerJob}
                    participationPercent={student.participationPercent} />)}
            </table>
        </div>
    )
}
export default ListStudents;
