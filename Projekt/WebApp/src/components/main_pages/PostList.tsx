import { VscAccount } from "react-icons/vsc";
import PopUpWindowForPost from "../forms/PopUpWindowForPost";
import './PostList.css';
import { useState } from "react";

interface PostListProps {
    posts: any[]
    navigateToUser: (id: number) => void
}

function PostList(props: PostListProps) {
    const [state, setState] = useState("hidden");
    const [postId, setPostId] = useState(0);
    let user = localStorage.getItem("user") ? localStorage.getItem("user"): null;
    let id = user ? JSON.parse(user).id : null;

    var content = props.posts.map((post) =>
        <div key={post.id} className="post-container">
            <div className="post-author" 
                 onClick={() => {
                    props.navigateToUser(post.user.id);
                    // console.log(post.user.userName);
                    }}>

                <div className="post-author-icon">
                    <VscAccount />
                </div>

                <div className="post-author-name">
                    {post.user.userName}
                </div>
            </div>

            <div className="post-header">
                <h2>{post.title}</h2>
                <p className="post-date">
                    {post.createdAt}
                </p>
            </div>

            <div className="post-content">
                {post.content}
            </div>
            
            {post.user.id == id ? (
                <div className="post-item-button">
                    <button className="btn btn-primary" onClick={() => {setPostId(post.id); setState('edit')}}>Edit</button>
                    <button className="btn btn-danger" onClick={() => {setPostId(post.id); setState('delete')}}>Delete</button>
                </div>)
                :
                (<></>)
            }
        </div>
    );

    return (
        <div className="post-list-container">
            <div className="post-list">
                {content}
            </div>
            <PopUpWindowForPost 
                state={state} 
                setState={setState} 
                postId={postId}        
            />
        </div>
    );
}

export default PostList;