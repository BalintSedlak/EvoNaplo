import { useState } from "react";
import { ButtonGroup, ToggleButton } from "react-bootstrap";
import { useTable, Column, useSortBy, useGlobalFilter, useFilters } from "react-table";
import ISession from "../../ISession";
import classes from './ListAuthorized.module.css'

interface Data {
  fullname: string;
  email: string;
  telephone: string;
}

let mentors: Data[] = [
  {
    fullname: "Kis Béla",
    email: "kisbela@email.com",
    telephone: "363636363",
  },
  {
    fullname: "Kun Géza",
    email: "sdasd@email.com",
    telephone: "363636363",
  },
  {
    fullname: "Lo Nyál",
    email: "sxdax@email.com",
    telephone: "363636363",
  },
  {
    fullname: "Tron Béla",
    email: "grgrw@email.com",
    telephone: "363636363",
  },
  {
    fullname: "Mun Gnu",
    email: "triv@gmail.com",
    telephone: "363636363",
  },
];

const admins: Data[] = [
  {
    fullname: "Uku Lele",
    email: "g31232w@email.com",
    telephone: "31242412",
  },
  {
    fullname: "Kéla Taylor",
    email: "wdww@email.com",
    telephone: "3312321312",
  }
];

const columns: Column<Data>[] = [

  {
    Header: "Név",
    accessor: "fullname",
    Filter: ""
  },
  {
    Header: "Email",
    accessor: "email",
    Filter: ""
  },
  {
    Header: "Telefonszám",
    accessor: "telephone",
    Filter: ""
  },
];

const ChooseAuthorized = (igen: Data[]) => {
  const data = igen;
  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    prepareRow,
    state,
  } = useTable<Data>({ columns, data }, useFilters, useGlobalFilter, useSortBy);
  return(
  <div className={classes.base}>
  <table className={classes.roleTable} >
    <thead>
      {headerGroups.map(headerGroup => (
        <tr {...headerGroup.getHeaderGroupProps()}>
          {headerGroup.headers.map(column => (
            <th {...column.getHeaderProps(column.getSortByToggleProps())}>
              {/*console.log(column.getSortByToggleProps())*/}
              {column.render("Header")}
              <div>{column.canFilter ? column.render('Filter') : null}</div>
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
</div>);
}

const ListAuthorized = ({ session }: { session: ISession }) => {
  
  const [currentPage, setCurrentPage] = useState('1');

  const buttonElements = [
    { name: 'Mentorok', value: '1' },
    { name: 'Adminok', value: '2' }
  ]

  return (
    <>
    <div>
    <ButtonGroup className={classes.toggleButtonPosition}>
      {buttonElements.map((radio, idx) => (
        <ToggleButton
          key={idx}
          id={`radio-${idx}`}
          type="radio"
          variant={idx % 2 ? 'outline-success' : 'outline-danger'}
          name="radio"
          value={radio.value}
          checked={currentPage === radio.value}
          onChange={(e) => setCurrentPage(e.currentTarget.value)}
        >
          {radio.name}
        </ToggleButton>
      ))}
    </ButtonGroup>
  </div>
  <div>
    {currentPage === '1' ? ChooseAuthorized(mentors): ChooseAuthorized(admins)}
  </div></>
  );
}
export default ListAuthorized;