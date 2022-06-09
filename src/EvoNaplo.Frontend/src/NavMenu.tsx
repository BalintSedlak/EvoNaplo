import { Container, Nav, Navbar, NavDropdown } from 'react-bootstrap';
import {useNavigate} from 'react-router-dom';
import ISession from './ISession';

const LoginLink = (id: number) => {

    if (id < 1) {
        return <Nav.Link href="/Components/Login/Login">Login</Nav.Link>
    }
    
}
const RegistrationLink = (id: number) => {
    if (id < 1) {
        return <Nav.Link href="/Components/Registration/Registration">Registration</Nav.Link>
    }

}
const SemesterOpeningLink = (id: number) => {
    if (id > 0) {
        return <NavDropdown.Item href="/Prototypes/SemesterOpeningView">SemesterOpeningView</NavDropdown.Item>
    }
}

const ListAttendancesLink = (id: number) => {
    if (id > 0) {
        return <Nav.Link href="/Components/ListAttendances/ListAttendances">ListAttendances</Nav.Link>
    }
}

const ListStudentsLink = (id: number) => {
    if (id > 0) {
        return <Nav.Link href="/Components/ListStudents/ListStudents">ListStudents</Nav.Link>
    }
}


const AddAttendanceViewLink = (id: number) => {
    if (id > 0) {
        return <NavDropdown.Item href="/Prototypes/AddAttendanceView">AddAttendanceView</NavDropdown.Item>
    }
}


export default function NavMenu({ session }: { session: ISession }) {
    const navigate = useNavigate();

    const navigateToLogin = () => {
        navigate('/Components/Login/Login', {replace: true});
    }
    console.log(session)

    const handleLogout = () => {
        fetch('http://localhost:7043/api/Session/Logout', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json",
                "Connection": "keep-alive"
            },
            credentials: 'include'
        })
            .then(function (data) {
                if (data.status === 200) {
                    //alert("Cookie deleted");
                    console.log("Before navigation")
                    window.location.reload();
                    navigateToLogin();
                }
                else {

                }
            })
            .catch(function (error) {
                console.log(error);
            });
    }


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
                        {ListAttendancesLink(session.id)}
                        {ListStudentsLink(session.id)}
                        {session.id > 0 && <NavDropdown title="Prototypes" id="basic-nav-dropdown">
                            {SemesterOpeningLink(session.id)}
                            <NavDropdown.Divider />
                            {AddAttendanceViewLink(session.id)}
                        </NavDropdown>}
                        {session.id > 0 && <Nav.Link className="justify-content-end" onClick={handleLogout}>Logout</Nav.Link>}
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}