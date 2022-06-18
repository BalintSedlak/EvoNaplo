import React from 'react'
import { useTable, Column, useSortBy, useGlobalFilter, useFilters } from "react-table";
import ISession from '../../ISession';
import { UnauthorizedModal } from '../UI/UnauthorizedModal';
import { ListAttendancesGlobalFilter } from './Filters/ListAttendancesGlobalFilter';
import { ListAttendancesProjectFilter } from './Filters/ListAttendancesProjectFilter';
import { ListAttendancesSemesterFilter } from './Filters/ListAttendancesSemesterFilter';
import classes from './ListAttendances.module.css'

const columns: Column<Data>[] = [
  {
    Header: "Name",
    accessor: "name",
    Filter: ""
  },
  {
    Header: "Semester",
    accessor: "semester",
    Filter: ListAttendancesSemesterFilter
  },
  {
    Header: "Project",
    accessor: "project",
    Filter: ListAttendancesProjectFilter
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
  id: string;
}

const data: Data[] = [
  {
    name: "Kis Béla",
    semester: "2022/1",
    project: "EvoNaplo",
    date: "1. Hét - 2022.05.01.- 2022.05.08.",
    status: "online",
    id: '1'
  },
  {
    name: "Kis Béla",
    semester: "2022/1",
    project: "EvoNaplo",
    date: "1. Hét - 2022.05.01.- 2022.05.08.",
    status: "online",
    id: '1'
  },
  {
    name: "Nagy Béla",
    semester: "2022/1",
    project: "EvoNaplo",
    date: "2. Hét - 2022.05.01.- 2022.05.08.",
    status: "online",
    id: '1'
  },
  {
    name: "Kis Béla",
    semester: "2021/1",
    project: "EvoNaplo",
    date: "3. Hét - 2022.05.01.- 2022.05.08.",
    status: "online",
    id: '1'
  },
  {
    name: "Kis Béla",
    semester: "2021/1",
    project: "EvoRPG",
    date: "3. Hét - 2022.05.01.- 2022.05.08.",
    status: "online",
    id: '1'
  },
];


const ListAttendances = ({ session }: { session: ISession }) => {

    const {
      getTableProps,
      getTableBodyProps,
      headerGroups,
      rows,
      prepareRow,
      state,
      setGlobalFilter
    } = useTable<Data>({ columns, data }, useFilters, useGlobalFilter, useSortBy);

    if (session.id > 0) {
    const { globalFilter } = state;

    return (
      <>
        <div className={classes.base}>

          <div className={classes.globalFilter}>
            <ListAttendancesGlobalFilter filter={globalFilter} setFilter={setGlobalFilter} />
          </div>
          <table {...getTableProps()} className={classes.listAttendanceTable}>
            <thead>
              {headerGroups.map(headerGroup => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                  {headerGroup.headers.map(column => (
                    <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                      {console.log(column.getSortByToggleProps())}
                      {<strong>{column.render("Header")}</strong>}
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
        </div>
      </>
    )
  }
  else {
    return <UnauthorizedModal/>
  }
}

export default ListAttendances