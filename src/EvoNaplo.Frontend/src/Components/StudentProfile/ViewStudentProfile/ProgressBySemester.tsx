import { ProgressBar } from "react-bootstrap";

export default function DropDownScholarship({ data }: { data: any }){
    const printout = data.map((i,index) => {return(<li>Semester{index} <ProgressBar now={i} label={`${i}%`}/></li>)})
    return(printout);
}