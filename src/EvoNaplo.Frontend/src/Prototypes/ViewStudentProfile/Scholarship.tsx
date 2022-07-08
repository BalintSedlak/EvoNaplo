import { useState } from "react";
import { DropdownButton, ButtonGroup, Dropdown } from "react-bootstrap";

export default function DropDownScholarship(props: {data: string}){
const [studentDropDownTitle, setDropDownTitle] = useState(props.data);

return(
<DropdownButton as={ButtonGroup} id={"Buttongroup"} title={studentDropDownTitle}>
    <Dropdown.Item eventKey="1" onClick={e => setDropDownTitle("Nem jelentkezett")}>Nem jelentkezett</Dropdown.Item>
    <Dropdown.Item eventKey="2" onClick={e => setDropDownTitle("Jelentkezett")}>Jelentkezett</Dropdown.Item>
    <Dropdown.Item eventKey="3" onClick={e => setDropDownTitle("Ösztöndíjas")}>Ösztöndíjas</Dropdown.Item>
</DropdownButton>);
}