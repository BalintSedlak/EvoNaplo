import validate from "../EditSemesterPage/EditSemesterValidate";
import React, { useEffect, useState } from "react";
import UnauthorizedPage from '../../components/Unauthorized';

export default function EditUserPage(props) {
    const [semester, setSemester] = useState({
        id: '',
        startDate: '',
        endDate: '',
        isAppliable: ''
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

    useEffect(() => {
        if (props.match.params.id !== undefined) {
            fetch('api/Semester/GetSemesterToEditById/?id=' + props.match.params.id)
                .then(response => response.json())
                .then(json => setSemester({ id: json.id, startDate: json.startDate, endDate: json.endDate, isAppliable: json.isAppliable }))
        }
    }, []);

    const handleChange = e => {
        setSemester({
            ...semester,
            [e.target.name]: e.target.value
        });
        if (e.target.name === "isAppliable") {
            setSemester({
                ...semester,
                [e.target.name]: e.currentTarget.value === 'true' ? true : false
            })
        }
        console.log(semester);
    }

    const onSubmit = e => {
        e.preventDefault()
        console.log(JSON.stringify(semester));
        const returnedErrors = validate(semester);
        setErrors(returnedErrors);

        if (Object.keys(returnedErrors).length == 0) {
            fetch('api/Semester/EditSemester', { method: 'PUT', body: JSON.stringify(semester), headers: { "Content-Type": "application/json" } })
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
            if (session.role === "Admin") {
                return (
                    /* "handleSubmit" will validate your inputs before invoking "onSubmit" */
                    <div class="DivCard">
                        <h1>Edit</h1>
                        <form onSubmit={onSubmit} id="editForm">
                            {/* register your input into the hook by invoking the "register" function */}
                            <table>
                                <tr>
                                    <td>
                                        <input type="text" name="startDate" value={semester.startDate} placeholder="startDate" onChange={handleChange} />
                                        {errors.startDate && <p class="ErrorParagraph">{errors.startDate}</p>}
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input type="text" name="endDate" value={semester.endDate} placeholder="endDate" onChange={handleChange} />
                                        {errors.endDate && <p class="ErrorParagraph">{errors.endDate}</p>}
                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                        <label >isAppliable</label><br />
                                        <input type="radio" id="isAppliableTrue" name="isAppliable" value={true} onChange={handleChange} checked={semester.isAppliable === true} />
                                        <label for="isAppliableTrue">True</label><br />
                                        <input type="radio" id="isAppliableFalse" name="isAppliable" value={false} onChange={handleChange} checked={semester.isAppliable === false} />
                                        <label for="isAppliableFalse">False</label><br />
                                    </td>
                                </tr>
                            </table>
                            <input type="submit" />
                        </form>
                        {success && <p class="SuccessParagraph">User {semester.startDate} successfully edited.</p>}
                        <a href="/Semesters" class="joffan">
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