import React, { useEffect, useState } from 'react';
import { Card, ProgressBar } from 'react-bootstrap';
import Scholarship from './Scholarship';
import './UserPageView.css'


export const ViewStudentProfile = () => {
    const student =
    {
        fullname: "Teszt Benő",
        studies: "2020.09.03. - 2023.06.10.",
        technologies: "java, javascript",
        attendance: 80,
        mentors: ["Helló Pál, ", "Végre Sikerült, ", "Pénztáros Géza"],
        teams: ["Első csopi", "G2", "Ausztria csopi"],
        scholarship: "Nem jelentkezett",
        email: "teveklub@freemail.hu",
        phonenumber: "+36363636363",
        fbgroup: true,
        internship: false,
        comment: ["Név Pál", "Nagyon tudja, hogy tudja a dolgát."]

    }

    return (
        <div className="DivCard">
            <tr><th>Név</th></tr>
            <tr>{student?.fullname}</tr>
            <tr><th>Tanulmányok</th></tr>
            <tr>{student?.studies}</tr>
            <tr><th>Technológiák</th></tr>
            <tr>{student?.technologies}</tr>
            <tr><th>Jelenlét</th></tr>
            <tr>{<ProgressBar now={student?.attendance} label={`${student?.attendance}%`} />}</tr>
            <tr><th>Mentorok</th></tr>
            <tr>{student?.mentors.map((i) => { return (<li>{i}</li>) })}</tr>
            <tr><th>Csapatok</th></tr>
            <tr>{student?.teams.map((i) => { return (<li>{i}</li>) })}</tr>
            <tr><th>Ösztöndíj</th></tr>
            {<Scholarship data={student?.scholarship}></Scholarship>}
            <tr><th>Email</th></tr>
            <tr>{student?.email}</tr>
            <tr><th>Telefonszám</th></tr>
            <tr>{student?.phonenumber}</tr>
            <tr><th>Facebook csoport</th></tr>
            <tr>{<input type="checkbox" checked={student?.fbgroup} readOnly={true}></input>}</tr>
            <tr><th>Szakmai Gyakorlat</th></tr>
            <tr>{<input type="checkbox" checked={student?.internship} readOnly={true}></input>}</tr>
            <tr><th>Komment</th></tr>
            <tr><Card border="success" style={{ width: '18rem' }}>
                <Card.Header>{student?.comment[0]}</Card.Header>
                <Card.Body>
                    <Card.Title>Success Card Title</Card.Title>
                    <Card.Text>
                        {student?.comment[1]}
                    </Card.Text>
                </Card.Body>
            </Card>
                <br /></tr>
        </div>
    );
}
