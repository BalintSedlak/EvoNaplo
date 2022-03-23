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
                        <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                            <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                            <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                            <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
                        </NavDropdown>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}