import validate from "../EditProjectsPage/EditProjectsValidate";
import React, { useEffect, useState } from "react";
import UnauthorizedPage from '../../components/Unauthorized';

export default function EditUserPage(props) {
    const [project, setProject] = useState({
        id: '',
        projectName: '',
        description: '',
        sourceLink: '',
        technologies: '',
        semesterid: ''

    });

    const [errors, setErrors] = useState({});
    const [success, setSuccess] = useState(false);

    useEffect(() => {
        if (props.match.params.id !== undefined) {
            fetch('api/Project/GetProjectToEditById/?id=' + props.match.params.id)
                .then(response => response.json())
                .then(json => setProject({ id: json.id, projectName: json.projectName, description: json.description, sourceLink: json.sourceLink, technologies: json.technologies }))
        }
    }, []);

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

    const handleChange = e => {
        setProject({
            ...project,
            [e.target.name]: e.target.value
        });
    }

    const onSubmit = e => {
        e.preventDefault()
        console.log(JSON.stringify(project));
        const returnedErrors = validate(project);
        setErrors(returnedErrors);

        if (Object.keys(returnedErrors).length == 0) {
            fetch('api/Project/EditProject', { method: 'PUT', body: JSON.stringify(project), headers: { "Content-Type": "application/json" } })
                .then(function (data) {
                    setSuccess(true);
                })
                .catch(function (error) {
                    setSuccess(false);
                });
            document.getElementById("editForm").reset();
        }
        else {
            setSuccess(false);
        }
    }

    if (session !== undefined) {
        if (session.title !== "Unauthorized") {
            if (session.role !== "Student") {
                return (
                    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */

                    <div class="DivCard">
                        <h1>Edit</h1>
                        <form onSubmit={onSubmit} id="editForm">
                            {/* register your input into the hook by invoking the "register" function */}
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" name="projectName" value={project.projectName} placeholder="projectName" onChange={handleChange} />
                                        {errors.projectName && <p class="ErrorParagraph">{errors.projectName}</p>}
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="text" name="description" value={project.description} placeholder="description" onChange={handleChange} />
                                        {errors.description && <p class="ErrorParagraph">{errors.description}</p>}
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="text" name="sourceLink" value={project.sourceLink} placeholder="sourceLink" onChange={handleChange} />
                                        {errors.sourceLink && <p class="ErrorParagraph">{errors.sourceLink}</p>}
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="text" name="technologies" value={project.technologies} placeholder="technologies" onChange={handleChange} />
                                        {errors.technologies && <p class="ErrorParagraph">{errors.technologies}</p>}
                                    </td>
                                </tr>
                            </table>
                            <input type="submit" />
                        </form>
                        {success && <p class="SuccessParagraph">User {project.projectName} successfully edited.</p>}
                    </div>
                );
            }
        }
    }
    return (
        <UnauthorizedPage />
    );
}