import React from 'react'
import styled from 'styled-components';
import { useTable, Column, useSortBy, useGlobalFilter, useFilters } from "react-table";
import { GlobalFilter } from './Filters/GlobalFilter';
import { ProjectFilter } from './Filters/ProjectFilter';
import { SemesterFilter } from './Filters/SemesterFilter';

const columns: Column<Data>[] = [
  {
    Header: "Name",
    accessor: "name",
    Filter: ""
  },
  {
    Header: "Semester",
    accessor: "semester",
    Filter: SemesterFilter
  },
  {
    Header: "Project",
    accessor: "project",
    Filter: ProjectFilter
  },
  {
    Header: "Date",
    accessor: "date",
    Filter: ""
  },
  {
    Header: "Status",
    accessor: "status",
    Filter: ""
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
  padding: 2rem;
  width: 800px;
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
  } = useTable<Data>({ columns, data }, useFilters, useGlobalFilter, useSortBy);

  const { globalFilter } = state;

  return (
    <>
      <div className='mt-3' style={{ display: 'flex', justifyContent: 'center' }}>
        <Styles>
          <div className='m-3' style={{ display: 'flex', justifyContent: 'center'}}>
            <GlobalFilter filter={globalFilter} setFilter={setGlobalFilter} />
          </div>
          <table {...getTableProps()}>
            <thead>
              {headerGroups.map(headerGroup => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                  {headerGroup.headers.map(column => (
                    <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                      {console.log(column.getSortByToggleProps())}
                      {column.render("Header")}
                      <div className='m-2'>{column.canFilter ? column.render('Filter') : null}</div>
                      <span>
                        {" "}
                        {column.isSorted
                          ? column.isSortedDesc
                            ? ""
                            : ""
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
      </div>
    </>
  )
}

export default ListAttendances