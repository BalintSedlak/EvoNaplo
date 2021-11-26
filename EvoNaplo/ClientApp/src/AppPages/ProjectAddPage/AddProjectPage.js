import React, { useEffect, useState, useRef } from "react";
import '../Forms.css';
import EditProjectValidate from '../EditProjectsPage/EditProjectsValidate'
import UnauthorizedPage from '../../components/Unauthorized';


const AddProjectPage = () => {

    const [project, setProject] = useState({
        projectName: '',
        description: '',
        sourceLink: '',
        technologies: ''
    });

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


    const [errors, setErrors] = useState({});

    const [success, setSuccess] = useState(false);

    const handleChange = e => {
        setProject({
            ...project,
            [e.target.name]: e.target.value
        });
        console.log(project);
    }
    
    const onSubmit = e => {
        e.preventDefault()

        const returnedErrors = EditProjectValidate(project);
        setErrors(returnedErrors);

        if (Object.keys(returnedErrors).length == 0) {

            console.log(project);
            fetch('api/Project/AddProject', { method: 'POST', body: JSON.stringify(project), headers: { "Content-Type": "application/json" } })
                .then(function (data) {
                    setSuccess(true);
                    setProject({
                        projectName: '',
                        description: '',
                        sourceLink: '',
                        technologies: ''
                    });
                })
                .catch(function (error) {
                    setSuccess(false);
                });
            document.getElementById("registrationForm").reset();
        }
        else {
            setSuccess(false);
        }

    }

    if (session !== undefined) {
        if (session.title !== "Unauthorized") {
            if (session.role === "Admin") {
                return (                                
                    <div class="DivCard">
                        <h1>Project Registration</h1>
                        <form onSubmit={onSubmit} id="registrationForm">
                            {/* register your input into the hook by invoking the "register" function */}
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" name="projectName" value={project.projectName} placeholder="ProjectName" onChange={handleChange} />
                                        {errors.projectName && <p class="ErrorParagraph">{errors.projectName}</p>}
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="text" name="description" value={project.description} placeholder="Description" onChange={handleChange} />
                                        {errors.description && <p class="ErrorParagraph">{errors.description}</p>}
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="text" name="sourceLink" value={project.sourceLink} placeholder="SourceLink" onChange={handleChange} />
                                        {errors.sourceLink && <p class="ErrorParagraph">{errors.sourceLink}</p>}
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="text" name="technologies" value={project.technologies} placeholder="Technologies" onChange={handleChange} />
                                        {errors.technologies && <p class="ErrorParagraph">{errors.technologies}</p>}
                                    </td>
                                </tr>
                            </table>
                            <input type="submit" />
                        </form>
                        {success && <p class="SuccessParagraph">Project {project.projectName} successfully added.</p>}
                        <a href="/Projects" class="joffan">
                            Back
             </a>

                    </div>
                );
            }
        }
    }
    return (
        <UnauthorizedPage />
    );
}
export default AddProjectPage;