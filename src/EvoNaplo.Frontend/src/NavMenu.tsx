import React, { Component, useEffect, useState } from 'react';
import { Container, Nav, Navbar, NavDropdown } from 'react-bootstrap';
import ISession from './ISession';

const LoginLink = (id: number) => {
    if(id < 1)
    {
        return <Nav.Link href="/Login">Login</Nav.Link>
    }
}
const RegistrationLink = (id: number) => {
    if(id < 1)
    {
        return <Nav.Link href="/Registration">Registration</Nav.Link>
    }
}
const SemesterOpeningLink = (id: number) => {
    // if(id > 0)
    // {
        return <NavDropdown.Item href="/Prototypes/SemesterOpeningView">SemesterOpeningView</NavDropdown.Item>
    // }
}

const SemesterOpeningLink2 = (id: number) => {
    // if(id > 0)
    // {
        return <NavDropdown.Item href="/Components/SemesterOpeningView/SemesterOpening">SemesterOpeningView v2</NavDropdown.Item>
    // }
}

const ListStudentsViewLink = (id: number) => {
    // if(id > 0)
    // {
        return <NavDropdown.Item href="/Prototypes/ListStudentsView">ListStudentsView</NavDropdown.Item>
    // }
}

const AddAttendanceViewLink = (id: number) => {
    // if(id > 0)
    // {
        return <NavDropdown.Item href="/Prototypes/AddAttendanceView">AddAttendanceView</NavDropdown.Item>
    // }
}

export default function NavMenu({session}: {session: ISession}) {
    return (
        <Navbar bg="dark" variant="dark" expand="lg">
            <Container>
                <Navbar.Brand href="#home">EvoNaplo</Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <Nav.Link href="/">Home</Nav.Link>
                        {LoginLink(session.id)}
                        {RegistrationLink(session.id)}
                        <NavDropdown title="Prototypes" id="basic-nav-dropdown">
                            {SemesterOpeningLink(session.id)}
                            <NavDropdown.Divider />
                            {SemesterOpeningLink2(session.id)}
                            <NavDropdown.Divider />
                            {ListStudentsViewLink(session.id)}
                            <NavDropdown.Divider />
                            {AddAttendanceViewLink(session.id)}                            
                            <NavDropdown.Divider />                            
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}