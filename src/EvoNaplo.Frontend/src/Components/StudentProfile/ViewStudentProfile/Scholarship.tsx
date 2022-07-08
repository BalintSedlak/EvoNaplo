import { useState } from "react";
import { DropdownButton, ButtonGroup, Dropdown } from "react-bootstrap";

export default function DropDownScholarship(props: {data: boolean}){
const [studentDropDownTitle, setDropDownTitle] = useState(props.data);

return(
<DropdownButton as={ButtonGroup} id={"Buttongroup"} title={studentDropDownTitle}>
    <Dropdown.Item eventKey="1" onClick={e => setDropDownTitle(false)}>Nem jelentkezett</Dropdown.Item>
    <Dropdown.Item eventKey="2" onClick={e => setDropDownTitle(true)}>Jelentkezett</Dropdown.Item>
</DropdownButton>);
}