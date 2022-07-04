import React, { useState } from 'react';
import IStudent from '../IStudent';
import ProfileComment from './ProfileComment';
import ProgressBySemester from './ProgressBySemester';
import Scholarship from './Scholarship';
import './UserPageView.css'


//export default function UserPageView(props) {
export const ViewStudentProfile = () => {
    const [student, setStudent] = useState<IStudent>(
        {
            id: 1,
            fullName: "Teszt Benő",
            studies: "2020.09.03. - 2023.06.10.",
            technologies: "java, javascript",
            //attendance: [80, 60, 75],
            //mentors: ["Helló Pál, ", "Végre Sikerült, ", "Pénztáros Géza"],
            //teams: ["Első csopi", "G2", "Ausztria csopi"],
            scholarship: "Nem jelentkezett",
            email: "teveklub@freemail.hu",
            phoneNumber: "+36363636363",
            fbGroup: true,
            internship: false,
            //comment: ["Név Pál", "Nagyon tudja, hogy tudja a dolgát.", "2022.06.17."]

        });

    return (
        <div className="DivCard">
            <tr><th>Név</th></tr>
            <tr>{student?.fullName}</tr>
            <tr><th>Tanulmányok</th></tr>
            <tr>{student?.studies}</tr>
            <tr><th>Technológiák</th></tr>
            <tr>{student?.technologies}</tr>
            {/* 
            <tr><th>Jelenlét</th></tr>
            <tr><ul><ProgressBySemester data={student?.attendance}/></ul></tr>
            <tr><th>Mentorok</th></tr>
            <tr><ul>{student?.mentors.map((i) => { return (<li>{i}</li>) })}</ul></tr>
            <tr><th>Csapatok</th></tr>
            <tr><ul>{student?.teams.map((i) => { return (<li>{i}</li>) })}</ul></tr>
            */}
            <tr><th>Email</th></tr>
            <tr>{student?.email}</tr>
            <tr><th>Telefonszám</th></tr>
            <tr>{student?.phoneNumber}</tr>
            {/*Ez itt nem lesz szerkezhető*/}
            <tr><th>Ösztöndíj</th></tr>
            {<Scholarship data={student?.scholarship} />}
            <tr><th>Facebook csoport</th></tr>
            <tr>{<input type="checkbox" checked={student?.fbGroup} readOnly={true}></input>}</tr>
            <tr><th>Szakmai Gyakorlat</th></tr>
            <tr>{<input type="checkbox" checked={student?.internship} readOnly={true}></input>}</tr>
            <tr><th>Komment</th></tr>
            {/* <ProfileComment data={student?.comment}/>*/}
            
        </div>
    );
}
