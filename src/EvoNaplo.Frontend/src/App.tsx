import React, { useEffect, useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { DoesImplementISession } from './Helpers';
import { Container } from 'react-bootstrap';

import './App.css';
import Home from './Home';
import Login from './Login';
import Registration from './Registration';
import NavMenu from './NavMenu';
import ISession from './ISession';
import './Forms.css';
import SemesterOpeningView from './Prototypes/SemesterOpeningView/SemesterOpeningView';
import ListStudentsView from './Prototypes/ListStudentsView/ListStudentsView';
import AddAttendanceView from './Prototypes/AddAttendanceView/AddAttendanceView';
import ListAttendances from './Components/ListAttendances/ListAttendances';
import ListStudents from './Components/ListStudents/ListStudents';

function App() {
  const [session, setSession] = useState<ISession>({
    id: -1,
    name: '',
    role: ''
  });

  useEffect(() => {
    fetch('https://localhost:7043/api/Session', {
      method: 'GET',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
        'Cache': 'no-cache'
      },
      credentials: 'include'
    })
      .then(response => response.json())
      .then(json => {
        if (DoesImplementISession(json)) {
          setSession(json as ISession)
        }
      })
  }, []);

  function ResponseHasSessionStructure(prop: any): prop is ISession {
    return typeof (prop) == 'number';
  }

  return (
    <BrowserRouter>
      <NavMenu session={session} />
      <Container style={{padding:"60px"}}>
        <Routes>
          <Route path='/' element={<Home session={session} />} />
          <Route path='/Login' element={<Login />} />
          <Route path='/Registration' element={<Registration />} />
          <Route path='/Prototypes/SemesterOpeningView' element={<SemesterOpeningView />} />
          <Route path='/Prototypes/ListStudentsView' element={<ListStudentsView />} />
          <Route path='/Prototypes/AddAttendanceView' element={<AddAttendanceView />} />
          <Route path='/Components/ListAttendances/ListAttendances' element={<ListAttendances/>}/>
          <Route path='/Components/ListStudents/ListStudents' element={<ListStudents/>}/>
        </Routes>
      </Container>
    </BrowserRouter>
  );
}

export default App;
