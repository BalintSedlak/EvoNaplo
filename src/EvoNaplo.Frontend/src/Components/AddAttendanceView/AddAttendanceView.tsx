import React from 'react'
import ISession from '../../ISession'
import { UnauthorizedModal } from '../UI/UnauthorizedModal'
import { AddAttendanceForm } from './AddAttendanceForm'


const DUMMY_DATA = [
    {
        project: "EvoNaplo",
        students: ["Kis Béla", "Nagy Béla"]
    },
    {
        project: "EvoRPG",
        students: ["Kis Béla", "Nagy Béla", "Közepes Béla"]
    }
]


export const AddAttendanceView = ({ session }: { session: ISession }) => {

    if (session.id > 0) {
        return (
            <AddAttendanceForm  SemesterData = {DUMMY_DATA}/>
        )
    }
    return (
        <UnauthorizedModal />
    );
}
