import { getUser } from "../../User";
import { getPhrase } from "../LanguageSelector";
import { PostPost } from "../../Client";

import './Page.css'


function NewPostPage() {
    function submitNewPost(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const data = new FormData(e.target as HTMLFormElement);
        const payload = Object.fromEntries(data);
        var newPostRequest = JSON.parse(JSON.stringify(payload));
        
        newPostRequest.id = 0;
        const user = getUser();
        newPostRequest.user = user !== null ? JSON.parse(user) : '';
        newPostRequest.createdAt = new Date().toISOString();
        newPostRequest.comments = [];
        
        console.log(newPostRequest);
        PostPost(newPostRequest).then((res) => {
            console.log(res);
        }).catch((err) => {
            console.error(err);
        });
    }


    return (
        <div className="new-post">
            <form onSubmit={submitNewPost} className="form main-content-form">
                <input className="form-input" type="text" name="title" id="title" placeholder={getPhrase("title")} />
                <textarea
                        className="form-input"
                        name="content" 
                        id="content" 
                        placeholder={getPhrase("content")} 
                        rows={8}
                        cols={30}
                        maxLength={200}
                        wrap = "soft"
                        data-limit-row-len = {true}
                        />
                <input className="auth-btn" type="submit" value={getPhrase("publish")} />
            </form>
        </div>
    );
}

export default NewPostPage;