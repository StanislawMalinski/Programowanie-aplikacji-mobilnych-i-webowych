import { VscAccount } from "react-icons/vsc";
import './PostList.css';

interface PostListProps {
    posts: any[]
    navigateToUser: (id: number) => void
}

function PostList(props: PostListProps) {
    
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

        </div>
    );

    return (
        <div className="post-list-container">
            <div className="post-list">
                {content}
            </div>
        </div>
    );
}

export default PostList;