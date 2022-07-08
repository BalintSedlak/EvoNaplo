import React, { useEffect, useState } from 'react';
import { BrowserRouter, Route, Routes, Navigate } from 'react-router-dom';
import { DoesImplementISession } from './Helpers';
import { Container } from 'react-bootstrap';

import './App.css';
import Home from './Components/Home/Home';
import Login from './Components/Login/Login';
import Registration from './Components/Registration/Registration';
import NavMenu from './Components/UI/NavMenu';
import ISession from './ISession';
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
 
    fetch('http://localhost:7043/api/Session', {
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
          setSession(session => ({...session, id:json.id  }))
        }
      })
  }, [session]);


  return (
    <BrowserRouter>
      <NavMenu session={session} />
      <Container style={{ padding: "60px" }}>
        <Routes>
          <Route path='/' element={<Home session={session} />} />
          <Route path='/Components/Login/Login' element={session.id < 1 ? <Login/> : <Navigate to="/" />} />
          <Route path='/Components/Registration/Registration' element={session.id < 1 ? <Registration session={session}/> : <Navigate to="/" />} />
          <Route path='/Prototypes/SemesterOpeningView' element={<SemesterOpeningView />} />
          <Route path='/Prototypes/ListStudentsView' element={<ListStudentsView />} />
          <Route path='/Prototypes/AddAttendanceView' element={<AddAttendanceView /> } />
          <Route path='/Components/ListAttendances/ListAttendances' element={ <ListAttendances session={session}/> } />
          <Route path='/Components/ListStudents/ListStudents' element={<ListStudents session={session}/>} />
        </Routes>
      </Container>
    </BrowserRouter>
  );
}

export default App;
