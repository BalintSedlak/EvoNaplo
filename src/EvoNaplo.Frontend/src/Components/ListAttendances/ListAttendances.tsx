import React from 'react'
import styled from 'styled-components';
import { Dropdown } from 'react-bootstrap';




interface AttendanceType {
  Semester: string;
  Project: string;
  Name: string;
  Status: string;
}

interface Data {
  Week: string;
  Details: AttendanceType[];
}


const data: Data[] = [{
  Week: "Hét 1 2022.01.03. - 2022.01.09.",
  Details: [
    {
      Semester: "2022/1",
      Project: "EvoNaplo",
      Name: "Kis Béla",
      Status: "Online"
    },
    {
      Semester: "2022/1",
      Project: "EvoNaplo",
      Name: "Nagy Béla",
      Status: "Online"
    }
  ]
},

{
  Week: "Hét 2 2022.01.10. - 2022.01.17.",
  Details: [
    {
      Semester: "2022/1",
      Project: "EvoNaplo",
      Name: "Kis2 Béla",
      Status: "Online"
    },
    {
      Semester: "2022/1",
      Project: "EvoNaplo",
      Name: "Nagy2 Béla",
      Status: "Online"
    }
  ]
},

];




const Styles = styled.div`
td, th {
  border: 1px solid #ddd;
  padding: 8px;
}
`

const ListAttendances = () => {

  return (
    <>


      <Styles>
        <table>
          <thead>
          <tr>
            <th>Name</th>
            {data.map((items, i) => (
              <th key={i}>{items.Week}</th>
          ))}
          </tr>
          </thead>
          <tbody>
            
            {data.map((items, i) => (
              items.Details.map((el, e) => (
                <tr key={e}>
                  <td>{items.Details[e].Name}</td>
                </tr>
              ))
            ))}
            
          </tbody>
         

        </table>

      </Styles>
    </>
  )
}
/*{data.map((items, i) => (
            <th key={i}>
              {console.log(i)}
              {items.Attendances.Students.map((items, index => {
                 <tr>{item[index].Name}</tr>
              }))}
            </th>
          ))}*/
export default ListAttendances