import React from 'react'
import styled from 'styled-components';
import { Dropdown } from 'react-bootstrap';
import { useTable, Column, useSortBy, useGlobalFilter } from "react-table";
import { GlobalFilter } from './GlobalFilter';



const columns: Column<Data>[] = [
  {
    Header: "Name",
    accessor: "name"
  },
  {
    Header: "Semester",
    accessor: "semester"
  },
  {
    Header: "Project",
    accessor: "project"
  },
  {
    Header: "Date",
    accessor: "date"
  },
  {
    Header: "Status",
    accessor: "status"
  }
];

interface Data {
  name: string;
  semester: string;
  project: string;
  date: string;
  status: string;
}

const data: Data[] = [
  {
    name: "Kis Béla",
    semester: "2022/1",
    project: "EvoNaplo",
    date: "1. Hét - 2022.05.01.- 2022.05.08.",
    status: "online"
  },
  {
    name: "Nagy Béla",
    semester: "2022/1",
    project: "EvoNaplo",
    date: "2. Hét - 2022.05.01.- 2022.05.08.",
    status: "online"
  },
  {
    name: "Kis Béla",
    semester: "2021/1",
    project: "EvoNaplo",
    date: "3. Hét - 2022.05.01.- 2022.05.08.",
    status: "online"
  },
  {
    name: "Kis Béla",
    semester: "2021/1",
    project: "EvoRPG",
    date: "3. Hét - 2022.05.01.- 2022.05.08.",
    status: "online"
  },
];



const Styles = styled.div`
td, th {
  border: 1px solid #ddd;
  padding: 8px;
}
`

const ListAttendances = () => {

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow,
    state,
    setGlobalFilter
  } = useTable<Data>({ columns, data }, useGlobalFilter, useSortBy);
  
  const {globalFilter} = state;

  return (
    <>
      
      
      <Dropdown className=' m-2 inline-block' style={{display : 'inline-block'}}>
        <Dropdown.Toggle variant="success" id="dropdown-basic">
          Semester
        </Dropdown.Toggle>

        <Dropdown.Menu>
          <Dropdown.Item >2020</Dropdown.Item>
          <Dropdown.Item >2021</Dropdown.Item>
          <Dropdown.Item >2022</Dropdown.Item>
        </Dropdown.Menu>
      </Dropdown>

      <Dropdown className=' m-5' style={{display : 'inline-block'}}>
        <Dropdown.Toggle variant='info' id="dropdown-basic">
          Project
        </Dropdown.Toggle>

        <Dropdown.Menu>
          <Dropdown.Item>EvoNaplo</Dropdown.Item>
          <Dropdown.Item>EvoProject</Dropdown.Item>
          <Dropdown.Item>EvoRPG</Dropdown.Item>
        </Dropdown.Menu>
      </Dropdown>

      <Styles>
      <GlobalFilter filter={globalFilter} setFilter={setGlobalFilter}/>
        <table {...getTableProps()}>
          <thead>
            {headerGroups.map(headerGroup => (
              <tr {...headerGroup.getHeaderGroupProps()}>
                {headerGroup.headers.map(column => (
                  <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                    {console.log(column.getSortByToggleProps())}
                    {column.render("Header")}
                    <span>
                      {" "}
                      {column.isSorted
                        ? column.isSortedDesc
                          ? "🔽"
                          : "🔼"
                        : ""}{" "}
                    </span>
                  </th>
                ))}
              </tr>
            ))}
          </thead>
          <tbody {...getTableBodyProps()}>
            {rows.map((row, i) => {
              prepareRow(row);
              return (
                <tr {...row.getRowProps()} onClick={() => console.log(row.original)}>
                  {row.cells.map(cell => {
                    return <td {...cell.getCellProps()}>{cell.render("Cell")}</td>;
                  })}
                </tr>
              );
            })}
          </tbody>
        </table>

      </Styles>
    </>
  )
}

export default ListAttendances