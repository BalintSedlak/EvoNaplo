import React, { useState, useEffect } from 'react';
import UnauthorizedPage from '../../components/Unauthorized';
import '../../AppPages/GridLayout.css';

export default function JoinProjectPage() {
    const [projects, setProjects] = useState([]);
    const [user, setUser] = useState({
        projectId: undefined
    });

    const [session, setSession] = useState({});
    useEffect(() => {
        (
            async () => {
                const response = await fetch('api/Session', { method: 'GET' });
                const content = await response.json();

                await setSession(content);
            }
        )();
    }, []);


    useEffect(() => {
        fetch('api/Project/ProjectsOfCurrentSemester')
            .then(response => response.json())
            .then(json => setProjects(json))
    }, []);

    useEffect(() => {
        if ('id' in session) {
            fetch('api/Project/MyProjectThisSemester/?userId=' + session.id)
                .then(response => response.json())
                .then(json => setUser({ ...user, projectId: json.id }))
        }
    }, [session]);

    function LeaveProject(id) {
        fetch('api/Project/LeaveProject/?userId=' + session.id + '&projectId=' + id, { method: 'DELETE' })
            .then(function (data) {
                setUser({ ...user, projectId: undefined });
            })
            .catch(function (error) {

            });
    }

    function JoinProject(id) {
        fetch('api/Project/JoinProject/?userId=' + session.id + '&projectId=' + id, { method: 'POST' })
            .then(function (data) {
                setUser({ ...user, projectId: id });
            })
            .catch(function (error) {

            });
    }

    if (session !== undefined) {
        if (session.title !== "Unauthorized") {
            console.log(user);
            if (user.projectId !== undefined && user.projectId !== -1) {
                return (
                    <div class="grid-table">
                        {projects.map(project => {
                            let button;
                            if (project.id === user.projectId) {
                                button = <input type="button" class="btn btn-danger" id="button-center" onClick={() => LeaveProject(project.id)} value="Leave project" />;
                            }
                            else {
                                button = <input type="button" class="btn btn-secondary centerDiv" id="button-center" disabled value="Already on project" />;
                            }
                            return (
                                <div class="grid-card">
                                    <h2>{project.projectName}</h2>
                                    <hr />
                                    <p>Description</p>
                                    <p>{project.description}</p>
                                    <hr />
                                    <p>Technologies</p>
                                    <p>{project.technologies}</p>
                                    <br/>
                                    {button}
                                </div>
                            );
                        })}
                    </div>
                );
            }
            else {
                return (
                    <div class="grid-table">
                        {projects.map(project => {
                            return (
                                <div class="grid-card">
                                    <h2>{project.projectName}</h2>
                                    <hr />
                                    <p>Description</p>
                                    <p>{project.description}</p>
                                    <hr />
                                    <p>Technologies</p>
                                    <p>{project.technologies}</p>
                                    <input type="button" class="btn btn-success" onClick={() => JoinProject(project.id)} value="Join" />
                                </div>
                            );
                        })}
                    </div>
                );
            }
        }
    }
    return (
        <UnauthorizedPage />
    );
}