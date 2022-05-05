import React from 'react'
import styled from 'styled-components';
import { useTable, Column, useSortBy } from "react-table";
import { Dropdown } from 'react-bootstrap';

/*
Kérdések:
- Mi történik akkor ha a semester időpontja nem akkor volt ami a táblán van
*/

const columns: Column<Data>[] = [
  {
    Header: "Name",
    accessor: "name"
  },
  {
    Header: "Hét 1- 2022.05.06.", accessor: 'attendance',
  },
  {
    Header: "Hét 1- 2022.05.06.", accessor: 'attendance2',
  },



];

interface Data {
  name: string;
  attendance: string;
  attendance2: string;
}

const data: Data[] = [
  {
    name: "Béla",
    attendance: "Online",
    attendance2: "Offline"
  }


];

const Styles = styled.div`
  padding: 1rem;

  table {
    border-spacing: 0;
    border: 1px solid black;

    tr {
      :last-child {
        td {
          border-bottom: 0;
        }
      }
    }

    th,
    td {
      margin: 0;
      padding: 0.5rem;
      border-bottom: 1px solid black;
      border-right: 1px solid black;

      :last-child {
        border-right: 0;
      }
    }
  }
`


const ListAttendances = () => {
  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow
  } = useTable<Data>({ columns, data }, useSortBy)


  return (
    <>
      <Dropdown className='mx-auto my-2'>
        <Dropdown.Toggle variant="success" id="dropdown-basic">
          Semester
        </Dropdown.Toggle>

        <Dropdown.Menu>
          <Dropdown.Item >2020</Dropdown.Item>
          <Dropdown.Item >2021</Dropdown.Item>
          <Dropdown.Item >2022</Dropdown.Item>
        </Dropdown.Menu>
      </Dropdown>

      <Dropdown className='mx-auto my-2'>
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
                          ? " 🔽"
                          : " 🔼"
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