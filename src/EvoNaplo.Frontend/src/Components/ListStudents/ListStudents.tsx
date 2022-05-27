import styled from 'styled-components';
import { useTable, Column, useSortBy, useGlobalFilter, useFilters } from "react-table";
import { NameFilter } from './NameFilter'
import { SemesterFilter } from './SemesterFilter';
import { ProjectFilter } from './ProjectFilter';
import { ScholarshipFilter } from './ScholarshipFilter';


interface Data {
  name: string;
  email: string;
  telephone: string;
  project: string;
  mentors: string;
  date: string;
  facebook: string;
  scholarship: string;
  internship: string;
  participation_rate: string;
  semester: string;
}

const data: Data[] = [
  {
    name: "Kis Béla",
    email: "kisbela@email.com",
    telephone: "0630666666",
    project: "EvoNaplo",
    mentors: "ASD, DAS",
    date: "Péntek 14:00",
    facebook: "Igen",
    scholarship: "Kap",
    internship: "Nem",
    participation_rate: "50%",
    semester: "2022/1"
  },
  {
    name: "Kis Béla",
    email: "kisbela@email.com",
    telephone: "0630666666",
    project: "EvoNaplo",
    mentors: "ASD, DAS",
    date: "Péntek 14:00",
    facebook: "Igen",
    scholarship: "Jelenetkezett",
    internship: "Igen",
    participation_rate: "50%",
    semester: "2021/1"
  },
  {
    name: "Nagy Béla",
    email: "nagybela@email.com",
    telephone: "0650666666",
    project: "EvoRPG",
    mentors: "DAS",
    date: "Szerda 10:00",
    facebook: "Nem",
    scholarship: "Jelenetkezett",
    internship: "Igen",
    participation_rate: "93%",
    semester: "2021/2"
  },
  {
    name: "Közepes Béla",
    email: "kozepesbela@email.com",
    telephone: "0650666666",
    project: "EvoFlix",
    mentors: "DAS",
    date: "Szerda 10:00",
    facebook: "Igen",
    scholarship: "Nincs",
    internship: "Nem",
    participation_rate: "13%",
    semester: "2022/1"
  },
]

const columns: Column<Data>[] = [
  {
    Header: "Név",
    accessor: "name",
    Filter: NameFilter
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
  {
    Header: "Projekt",
    accessor: "project",
    Filter: ProjectFilter
  },
  {
    Header: "Mentorok",
    accessor: "mentors",
    Filter: ""
  },
  {
    Header: "Időpont",
    accessor: "date",
    Filter: ""
  },
  {
    Header: "Facebook csoportban van?",
    accessor: "facebook",
    Filter: ""
  },
  {
    Header: "Ösztöndíjra jelentkezett?",
    accessor: "scholarship",
    Filter: ScholarshipFilter
  },
  {
    Header: "Nyári gyakorlatra jelentkezett?",
    accessor: "internship",
    Filter: ""
  },
  {
    Header: "Részvétel aránya",
    accessor: "participation_rate",
    Filter: ""
  },
  {
    Header: "Semester",
    accessor: "semester",
    Filter: ""
  },

];

const Styles = styled.div`
td, th {
  border: 2px solid #ddd;
  padding: 0.5rem;
  width: 600px;
}
`

const ListStudents = () => {
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

          <div className='m-3' style={{ display: 'flex', justifyContent: 'center' }}>
            <div className='m-2'>
              <SemesterFilter filter={globalFilter} setFilter={setGlobalFilter} />
            </div>
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

export default ListStudents