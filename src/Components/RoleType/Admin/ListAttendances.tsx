// import React from 'react';
// import ReactDOM from 'react-dom';
  
//   const tdStyle = {
//     border: "1px solid black",
//   };
  
//   const Table({ id, columns, data }) {
//     return (
//         <table>
//             <tbody>
//                 <tr>
//                     {columns.map(({ path, name }) => (
//                         <th style={tdStyle} key={path}>{name}</th>
//                     ))}
//                 </tr>
//                 {data.map((rowData) => (
//                     <tr key={rowData[id]}>
//                         {columns.map(({ path }) => (
//                             <td style={tdStyle} key={path}>
//                                 {rowData[path]}
//                             </td>
//                         ))}
//                     </tr>
//                 ))}
//             </tbody>
//         </table>
//     );
// }
  
//   // Example use --------------------
  
  const ListAttendances = () => {
    const columns = [
      { path: "id",   name: "ID" },
      { path: "name", name: "Name" },
      { path: "age",  name: "Age" },
    ];
  
    const data = [
      { id: 1, name: 'Kate',  age: 25, favFruit: '🍏' },
      { id: 2, name: 'Tom',   age: 23, favFruit: '🍌' },
      { id: 3, name: 'Ann',   age: 26, favFruit: '🍊' },
      { id: 4, name: 'Jack',  age: 21, favFruit: '🍒' }
    ];
  
    return (
      <div>
        {/* <Table id="id" columns={columns} data={data} /> */}
      </div>
    );
  };

   export default ListAttendances;