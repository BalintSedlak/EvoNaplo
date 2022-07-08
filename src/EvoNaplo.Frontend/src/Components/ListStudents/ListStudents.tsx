import { useTable, Column, useSortBy, useGlobalFilter, useFilters } from "react-table";
import { NameFilter } from './Filters/NameFilter'
import { SemesterFilter } from './Filters/SemesterFilter';
import { ProjectFilter } from './Filters/ProjectFilter';
import { ScholarshipFilter } from './Filters/ScholarshipFilter';
import classes from './ListStudent.module.css'
import ISession from "../../ISession";
import { UnauthorizedModal } from "../UI/UnauthorizedModal";


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
    mentors: "Sedlák Bálint",
    date: "Péntek 14:00",
    facebook: "Igen",
    scholarship: "Kap",
    internship: "Nem",
    participation_rate: "50%",
    semester: "2022/1"
  },
  {
    name: "Kis Csaba",
    email: "kisbela@email.com",
    telephone: "0630666666",
    project: "EvoNaplo",
    mentors: "András Péter Halász",
    date: "Péntek 14:00",
    facebook: "Igen",
    scholarship: "Jelenetkezett",
    internship: "Igen",
    participation_rate: "80%",
    semester: "2021/1"
  },
  {
    name: "Nagy Anna",
    email: "nagybela@email.com",
    telephone: "0650666666",
    project: "EvoRPG",
    mentors: "Magyari Márk",
    date: "Szerda 10:00",
    facebook: "Nem",
    scholarship: "Jelenetkezett",
    internship: "Igen",
    participation_rate: "93%",
    semester: "2021/2"
  },
  {
    name: "Közepes István",
    email: "kozepesbela@email.com",
    telephone: "0650666666",
    project: "EvoFlix",
    mentors: "Sedlák Bálint, Magyari Márk",
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


const ListStudents = ({ session }: { session: ISession }) => {

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
            <SemesterFilter filter={globalFilter} setFilter={setGlobalFilter} />
          </div>


          <table {...getTableProps()} className={classes.studentTable}>
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

        </div>
      </>
    )
  }

  else {
    return <UnauthorizedModal/>
  }
}

export default ListStudents