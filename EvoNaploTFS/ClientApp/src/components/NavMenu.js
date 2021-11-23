import React, { Component, useEffect, useState } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import DropdownMenu from './DropdownMenu/DropdownMenu';
import './NavMenu.css';

function GetLists(role) {
    if (role === undefined) {
        return (
            <div />
        );
    }
    if (role === "Admin") {
        return (
            <div>
                <ul>
                    <li>
                        <a href="/Students"><div class="LinkSelector" />Students</a>
                    </li>
                    <li>
                        <a href="/Mentors"><div class="LinkSelector" />Mentors</a>
                    </li>
                    <li>
                        <a href="/Projects"><div class="LinkSelector" />Projects</a>
                    </li>
                    <li>
                        <a href="/Admins"><div class="LinkSelector" />Admins</a>
                    </li>
                    <li>
                        <a href="/Semesters"><div class="LinkSelector" />Semesters</a>
                    </li>
                </ul>
            </div>
        );
    }
    return (
        <div>
            <ul>
                <li>
                    <a href="/Students"><div class="LinkSelector" />Students</a>
                </li>
                <li>
                    <a href="/Mentors"><div class="LinkSelector" />Mentors</a>
                </li>
                <li>
                    <a href="/Projects"><div class="LinkSelector" />Projects</a>
                </li>
            </ul>
        </div>
    );
}

function Logout() {
    fetch("api/Auth/Logout", { method: 'POST' })
        .then(function () {
            window.location = "LoginPage";
        });
}

export default function NavMenu(props) {

    const [collapsed, setCollapsed] = useState(false);

    const [session, setSession] = useState();

    useEffect(() => {
        (
            async () => {
                const response = await fetch('api/Session', { method: 'GET' });
                const content = await response.json();

                await setSession(content);
            }
        )();
    }, []);

    function toggleNavbar() {
        setCollapsed(!collapsed);
    }

    

    function getNavBar() {
        if (session !== undefined) {
            if (session.title !== "Unauthorized") {
                if (session.role === "Admin") {
                    return (
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="NavLinkFonts" to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <DropdownMenu title="Lists" content={GetLists(session.role)} />
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="NavLinkFonts" to="/JoinProject">Join Project</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="NavLinkFonts" to="/ProjectsStudents">Students and projects</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="NavLinkFonts" to="/MyAccount">My Account</NavLink>
                            </NavItem>
                            <NavItem>
                                <a tag={Link} className="NavLinkFonts" onClick={() => Logout()}>Logout</a>
                            </NavItem>
                        </ul>
                    );
                }
                else if (session.role === "Mentor") {
                    return (
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="NavLinkFonts" to="/">Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <DropdownMenu title="Lists" content={GetLists(session.role)} />
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="NavLinkFonts" to="/JoinProject">Join Project</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink tag={Link} className="NavLinkFonts" to="/MyAccount">My Account</NavLink>
                            </NavItem>
                            <NavItem>
                                <a tag={Link} className="NavLinkFonts" onClick={() => Logout()}>Logout</a>
                            </NavItem>
                        </ul>
                    );
                }
                return (
                    <ul className="navbar-nav flex-grow">
                        <NavItem>
                            <NavLink tag={Link} className="NavLinkFonts" to="/">Home</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className="NavLinkFonts" to="/JoinProject">Join Project</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className="NavLinkFonts" to="/MyAccount">My Account</NavLink>
                        </NavItem>
                        <NavItem>
                            <a tag={Link} className="NavLinkFonts" onClick={() => Logout()}>Logout</a>
                        </NavItem>
                    </ul>
                );
            }
        }
        return (
            <ul className="navbar-nav flex-grow">
                <NavItem>
                    <NavLink tag={Link} className="NavLinkFonts" to="/LoginPage">Login</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={Link} className="NavLinkFonts" to="/Registration">Registration</NavLink>
                </NavItem>
            </ul>
        );
    }

    let navBar = getNavBar();
    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3 NavMenuColor" light>
                <Container>
                    <NavbarBrand tag={Link} className="NavLinkFonts" to="/">EvoNaploTFS</NavbarBrand>
                    <NavbarToggler onClick={toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={collapsed} navbar>
                        {navBar}
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    );
}