import React, { useEffect, useState } from 'react';
import UserImg from "../../components/Pictures/user.png";


export default function ProjectPageView(props) {
    const [project, setProject] = useState({});
    const [comments, setComments] = useState([]);


    useEffect(() => {
        if (props.match.params.id !== undefined) {
            fetch('api/Project/GetProjectById/?id=' + props.match.params.id)
                .then(response => response.json())
                .then(json => setProject(json))
        }
    }, []);
    const [commentText, UpdateCommentText] = useState("");

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

    useEffect(() => {
        if (props.match.params.id !== undefined) {
            fetch('api/Comment/ProjectComments/?id=' + props.match.params.id)
                .then(response => response.json())
                .then(json => setComments(json))
        }
    }, []);

    function PostComment() {
        if ('id' in session) {
            const commentBody = {
                comment: commentText,
                projectId: project.Id,
                commenterId: session.id,
                commenterName: session.name
            }
            let c = {
                id: 0,
                comment: commentText,
                projectId: project.Id,
                commenterId: session.id,
                commenterName: session.name
            }
            fetch('api/Comment/ProjectComment', { method: 'POST', body: JSON.stringify(commentBody), headers: { "Content-Type": "application/json" } })
                .then(function (data) {
                    window.location.reload(false);

                })
                .catch(function (error) {

                });

        }

    }

    const handleChange = e => {
        UpdateCommentText(e.target.value);
    }

    function renderComments(c) {
        if (session.role !== "Student") {
            return (
                <div>
                    <div>
                        <h3 class="h3Label">Comments to {project.projectName}</h3>
                        {c.map((row) =>
                            <div class="CommentCard">
                                <h5>
                                    {row.commenterName}:
                        </h5>
                                <hr />
                                <p>
                                    {row.comment}
                                </p>
                            </div>
                        )}
                    </div>
                    <div class="comment-creation">
                        <h3 class="h3Label">Create a comment</h3>
                        <textarea placeholder="Comment" rows="4" name="commentText" value={commentText} onChange={handleChange} />
                        <input type="button" onClick={() => PostComment()} value="Create comment" />
                    </div>
                </div>
            );

        }
        return (
            <div />);
    }

    function renderUserData() {

        return (
            <table class="userDataTable">
                {Object.entries(project).map(([key, value]) => {
                    if (key != "Name" && key != "Id") {
                        return (
                            <tr>
                                <td>{key}:</td>
                                <td>{value}</td>
                            </tr>
                        )
                    };
                })}
            </table>
        );

    }

    if (Object.keys(project).length == 0) {
        return (
            <p>Project not found</p>
        );
    }
    else if (project.id == -1) {
        return (
            <p>Project not found</p>
        );
    }
    else {
        let commentsToRender = comments.length > 0
            ? renderComments(comments)
            : <p><em>There are no comments on this project.</em></p>;

        return (
            <div class="DivCard">
                <table class="MainDisplayTable">
                    <tr>
                        <td>
                            <img id="UserImage" src={UserImg} />
                        </td>
                        <td>
                            <h2>
                                {project.projectName}
                            </h2>
                            {renderUserData()}
                        </td>
                    </tr>
                </table>
                {commentsToRender}
            </div>
        );
    }
}