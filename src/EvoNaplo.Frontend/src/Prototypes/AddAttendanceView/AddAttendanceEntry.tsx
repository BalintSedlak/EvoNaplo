import React, { useState } from 'react';

const AddAttendanceEntry = (props: any) => {
    return (
        <tr>
            <td>{props.fullname}</td>
            <td><input type="checkbox" checked={props.attendance} /></td>
        </tr>
    )
}

export default AddAttendanceEntry;