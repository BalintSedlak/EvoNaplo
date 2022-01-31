import React, { useCallback } from 'react';
import './App.css';
import RegisterStudent from './Components/RoleType/Unauthenticated/RegisterStudent';
import RegisterUser from './Components/RoleType/Admin/RegisterUser';
import ListStudents from './Components/RoleType/Admin/ListStudents';
import AddAttendance from './Components/RoleType/Mentor/AddAttendance';
import SemesterOpening from './Components/RoleType/Admin/SemesterOpening/SemesterOpeningView';
import ListAttendances from './Components/RoleType/Admin/ListAttendances';
// import ListAttendance from './Components/RoleType/Admin/ListAttendances';

function App() {
  return (
      <div className="App">
        <RegisterStudent/>
        <RegisterUser/>

        <br/><br/><br/><br/><br/><br/><br/>

        <ListStudents/>

        <br/><br/><br/><br/><br/><br/><br/>

        <AddAttendance/>

        <br/><br/><br/><br/><br/><br/><br/>

        <ListAttendances/>

        <br/><br/><br/><br/><br/><br/><br/>

        <SemesterOpening/>

      </div>    
  );
}

export default App;
