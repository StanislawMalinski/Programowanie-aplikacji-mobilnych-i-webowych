import React, { useEffect, useState } from 'react';
import './Form.css';
import { setUser } from '../../User';
import { PutPost, GetPost } from '../../Client';
import { getPhrase } from '../LanguageSelector';

//import { GoogleLogin } from '@react-oauth/google';



interface EditFormProps {
    selfClose: () => void
    postId: number
}

function EditForm (props: EditFormProps) {
    const [message, setMessage] = useState('');
    const [title, setTitle] = useState('');
    const [content, setContent] = useState('');
    const [post, setPost] = useState('');

    useEffect(() => {
        GetPost(props.postId)
        .then((res) => {
            setTitle(res.title);
            setContent(res.content);
            setPost(res as string);
            console.log(res);
        })
    }, []);

    function submitEditPost (e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const data = new FormData(e.target as HTMLFormElement);
        const payload = Object.fromEntries(data);

        console.log(payload);
        console.log(post);
        var newPost = JSON.parse(JSON.stringify(post));
        newPost.title = title;
        newPost.content = content;

        console.log(newPost);
        PutPost(newPost).then((res) => {
            console.log(res);
        });
        props.selfClose();
        window.location.reload();
    }

    return (
        <div className="new-post">
            <form onSubmit={submitEditPost} className="form main-content-form">
                <input 
                        className="form-input" 
                        type="text" 
                        name="title" 
                        id="title" 
                        placeholder={getPhrase("title")} 
                        value={title}
                        onChange={event => setTitle(event.target.value)}/>
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
                        value={content}
                        onChange={event => setContent(event.target.value)} 
                        />
                <input className="auth-btn" type="submit" value={getPhrase("publish")} />
            </form>
        </div>
    );

}

export default EditForm;
