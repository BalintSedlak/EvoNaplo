import React, { Component, useEffect, useState} from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import StudentsPage from './AppPages/StudentListPage/StudentsPage'
import MentorsPage from './AppPages/MentorListPage/MentorsPage'
import ProjectsPage from './AppPages/ProjectListPage/ProjectsPage'
import RegisterPage from './AppPages/RegisterPage/RegisterPage';
import AdminsPage from './AppPages/AdminListPage/AdminsPage';
import SemesterPage from './AppPages/SemesterListPage/SemesterPage';
import UserPageView from './AppPages/UserPageView/UserPageView';
import EditUserPage from './AppPages/EditUserPage/EditUserPage';
import SemesterPageView from './AppPages/SemesterPageView/SemesterPageView';
import EditSemesterPage from './AppPages/EditSemesterPage/EditSemesterPage';
import AddSemesterPage from './AppPages/SemesterAddPage/AddSemesterPage';
import ProjectPageView from './AppPages/ProjectPageView/ProjectPageView';
import AddProjectPage from './AppPages/ProjectAddPage/AddProjectPage';
import EditProjectsPage from './AppPages/EditProjectsPage/EditProjectsPage';
import ProjectsStudents from './AppPages/ProjectsStudentsPage/ProjectsStudents';
import LoginPage from './AppPages/LoginPage/LoginPage';
import JoinProjectPage from './AppPages/JoinProjectPage/JoinProjectPage';
import MyAccountPage from './AppPages/MyAccount/MyAccountPage';
import EditMyAccountPage from './AppPages/MyAccount/EditMyAccountPage';

import './custom.css'
import './components/Accordion.css'
import JoinProject from './AppPages/JoinProjectPage/JoinProjectPage';

export default function App() {
    const displayName = App.name;
    const [session, setSession] = useState({});

    useEffect(() => {
        (
            async () => {
                const response = await fetch('api/Auth/User', { method: 'GET' });
                const content = await response.json();

                await setSession(content);
            }
        )();
    }, []);

    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/Students' component={StudentsPage} />
            <Route path='/Mentors' component={MentorsPage} />
            <Route path='/Admins' component={AdminsPage} />
            <Route path='/Projects' component={ProjectsPage} />
            <Route path='/Semesters' component={SemesterPage} />
            <Route path='/Registration' component={RegisterPage} />
            <Route path='/UserPageView/:id' component={UserPageView} />
            <Route path='/EditUserPage/:id' component={EditUserPage} />
            <Route path='/SemesterPageView/:id' component={SemesterPageView} />
            <Route path='/EditSemesterPage/:id' component={EditSemesterPage} />
            <Route path='/AddSemesterPage' component={AddSemesterPage} />
            <Route path='/AddProjectPage' component={AddProjectPage} />
            <Route path='/ProjectPageView/:id' component={ProjectPageView} />
            <Route path='/EditProjectsPage/:id' component={EditProjectsPage} />
            <Route path='/ProjectsStudents' component={ProjectsStudents} />
            <Route path='/LoginPage' component={LoginPage} />
            <Route path='/JoinProject' component={JoinProjectPage} />
            <Route path='/MyAccount' component={MyAccountPage} />
            <Route path='/EditMyAccountPage' component={EditMyAccountPage} />

        </Layout>
    );
}