import React from 'react';
import logo from './logo.svg';
import './App.css';
import RegisterStudent from './Components/RoleType/Unauthenticated/RegisterStudent';
import RegisterUser from './Components/RoleType/Admin/RegisterUser';
import ListStudents from './Components/RoleType/Admin/ListStudents';
import AddAttendance from './Components/RoleType/Mentor/AddAttendance';
import ListAttendance from './Components/RoleType/Admin/ListAttendances';

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
      
      <ListAttendance/>

      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
