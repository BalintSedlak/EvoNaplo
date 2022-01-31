import React, { useState } from 'react';
import { ButtonGroup, Dropdown, DropdownButton } from 'react-bootstrap';

const ListAttendancesEntry = (props: any) => {
    const [studentDropDownTitle, setDropDownTitle] = useState(["Jelenlét","Jelenlét","Jelenlét","Jelenlét","Jelenlét","Jelenlét"])

    const changeTitle = (changestring: string, i: number) => {
        setDropDownTitle((datas=>({
            ...datas,
            [i]: changestring
         })));
    }

    return (
        <tr>
            <td>{props.fullname}</td>
            <td><DropdownButton as={ButtonGroup} title={studentDropDownTitle[0]} id="bg-nested-dropdown0">
                    <Dropdown.Item eventKey="1" onClick={e => changeTitle("Megjelent",0)}>Megjelent</Dropdown.Item>
                    <Dropdown.Item eventKey="2" onClick={e => changeTitle("Nem jelent meg",0)}>Nem jelent meg</Dropdown.Item>
                    <Dropdown.Item eventKey="3" onClick={e => changeTitle("Elmaradt",0)}>Elmaradt</Dropdown.Item>
                </DropdownButton></td>
            <td><DropdownButton as={ButtonGroup} title={studentDropDownTitle[1]} id="bg-nested-dropdown1">
                    <Dropdown.Item eventKey="1" onClick={e => changeTitle("Megjelent",1)}>Megjelent</Dropdown.Item>
                    <Dropdown.Item eventKey="2" onClick={e => changeTitle("Nem jelent meg",1)}>Nem jelent meg</Dropdown.Item>
                    <Dropdown.Item eventKey="3" onClick={e => changeTitle("Elmaradt",1)}>Elmaradt</Dropdown.Item>
                </DropdownButton></td>
            <td><DropdownButton as={ButtonGroup} title={studentDropDownTitle[2]} id="bg-nested-dropdown2">
                    <Dropdown.Item eventKey="1" onClick={e => changeTitle("Megjelent",2)}>Megjelent</Dropdown.Item>
                    <Dropdown.Item eventKey="2" onClick={e => changeTitle("Nem jelent meg",2)}>Nem jelent meg</Dropdown.Item>
                    <Dropdown.Item eventKey="3" onClick={e => changeTitle("Elmaradt",2)}>Elmaradt</Dropdown.Item>
                </DropdownButton></td>
            <td><DropdownButton as={ButtonGroup} title={studentDropDownTitle[3]} id="bg-nested-dropdown3">
                    <Dropdown.Item eventKey="1" onClick={e => changeTitle("Megjelent",3)}>Megjelent</Dropdown.Item>
                    <Dropdown.Item eventKey="2" onClick={e => changeTitle("Nem jelent meg",3)}>Nem jelent meg</Dropdown.Item>
                    <Dropdown.Item eventKey="3" onClick={e => changeTitle("Elmaradt",3)}>Elmaradt</Dropdown.Item>
                </DropdownButton></td>
            <td><DropdownButton as={ButtonGroup} title={studentDropDownTitle[4]} id="bg-nested-dropdown4">
                    <Dropdown.Item eventKey="1" onClick={e => changeTitle("Megjelent",4)}>Megjelent</Dropdown.Item>
                    <Dropdown.Item eventKey="2" onClick={e => changeTitle("Nem jelent meg",4)}>Nem jelent meg</Dropdown.Item>
                    <Dropdown.Item eventKey="3" onClick={e => changeTitle("Elmaradt",4)}>Elmaradt</Dropdown.Item>
                </DropdownButton></td>
            <td><DropdownButton as={ButtonGroup} title={studentDropDownTitle[5]} id="bg-nested-dropdown5">
                    <Dropdown.Item eventKey="1" onClick={e => changeTitle("Megjelent",5)}>Megjelent</Dropdown.Item>
                    <Dropdown.Item eventKey="2" onClick={e => changeTitle("Nem jelent meg",5)}>Nem jelent meg</Dropdown.Item>
                    <Dropdown.Item eventKey="3" onClick={e => changeTitle("Elmaradt",5)}>Elmaradt</Dropdown.Item>
                </DropdownButton></td>
            <td>{props.semester}</td>
            <td>{props.project}</td>
        </tr>
    )
}

export default ListAttendancesEntry;