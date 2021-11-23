import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import UserImg from "../../components/Pictures/user.png";
import './UserPageView.css'


export default function UserPageView(props) {
    const [user, setUser] = useState({ Id: 0, Name: "", IsActive: "", Email: "", Phone: "" });
    const [comments, setComments] = useState([]);
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
            fetch('api/User/GetUserById/?id=' + props.match.params.id)
                .then(response => response.json())
                .then(json => setUser({ Id: json.id, Name: json.name, IsActive: json.isActive, Email: json.email, Phone: json.phoneNumber }))
        }
        if (props.match.params.id !== undefined) {
            fetch('api/Comment/StudentComments/?id=' + props.match.params.id)
                .then(response => response.json())
                .then(json => setComments(json))
        }
    }, []);

    function PostComment() {
        if ('id' in session) {
            const commentBody = {
                comment: commentText,
                userId: user.Id,
                commenterId: session.id,
                commenterName: session.name
            }
            let c = {
                id: 0,
                comment: commentText,
                ownerId: user.Id,
                commenterId: session.id,
                commenterName: session.name
            }
            fetch('api/Comment/StudentComment', { method: 'POST', body: JSON.stringify(commentBody), headers: { "Content-Type": "application/json" } })
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
        return (
            <div>
                <h3 class="h3Label">Comments to {user.Name}</h3>
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
        );
    }

    function renderUserData() {
        return (
            <table class="userDataTable">
                {Object.entries(user).map(([key, value]) => {
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

    if (Object.keys(user).length == 0) {
        return (
            <p>User not found</p>
        );
    }
    else if (user.id == -1) {
        return (
            <p>User not found</p>
        );
    }
    else {
        let commentsToRender = comments.length > 0
            ? renderComments(comments)
            : <p><em>There are no comments to this student.</em></p>;

        return (
            <div class="DivCard">
                <table class="MainDisplayTable">
                    <tr>
                        <td>
                            <img id="UserImage" src={UserImg} />
                        </td>
                        <td>
                            <h2>
                                {user.Name}
                            </h2>
                            {renderUserData()}
                        </td>
                    </tr>
                </table>
                {commentsToRender}
                <div class="comment-creation">
                    <h3 class="h3Label">Create a comment</h3>
                    <textarea placeholder="Comment" rows="4" name="commentText" value={commentText} onChange={handleChange} />
                    <input type="button" onClick={() => PostComment()} value="Create comment" />
                </div>
            </div>
        );
    }
}