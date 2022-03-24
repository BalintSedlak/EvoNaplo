import React, { useState } from 'react';
import AddAttendanceEntry from './AddAttendanceEntry';

const AddAttendance = () => {
    const students = [
        {
            fullname: "Név1",
            attendance: false
        },
        {
            fullname: "Név2",
            attendance: false
        },
        {
            fullname: "Név3",
            attendance: false
        }
    ]
    
    return (
        <div>
            Jelenléti ív leadása <br/>
            <label>
                Project:
                <select>
                    <option value={0}>Project1</option>
                    <option value={1}>Project2</option>
                </select>
            </label>

            <label>
                Dátum:
                <input type="date"/>
            </label>

            <label>
                Időpont:
                <input type="time"/>
            </label>

            <form>
                {students.map((student) => <AddAttendanceEntry fullname={student.fullname} attendance={student.attendance}/> )}
                <label>
                    <input type="button" value="Submit"/>
                </label>
            </form>
        </div>
    )
}    

export default AddAttendance;