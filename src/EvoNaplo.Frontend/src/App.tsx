import React, { useEffect, useState } from 'react';
import './App.css';
import Home from './Home';
import Login from './Login';
import Registration from './Registration';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import NavMenu from './NavMenu';
import ISession from './ISession';
import { DoesImplementISession } from './Helpers';
import { Container } from 'react-bootstrap';
import './Forms.css';

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
      <Container>
        <Routes>
          <Route path='/' element={<Home session={session} />} />
          <Route path='/Login' element={<Login />} />
          <Route path='/Registration' element={<Registration />} />
        </Routes>
      </Container>
    </BrowserRouter>
  );
}

export default App;
