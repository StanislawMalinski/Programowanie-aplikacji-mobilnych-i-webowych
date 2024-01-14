import React, { useEffect, useState } from 'react';
import './Form.css';
import { GetPost, DeletePost } from '../../Client';
import { getPhrase } from '../LanguageSelector';

//import { GoogleLogin } from '@react-oauth/google';



interface EditFormProps {
    selfClose: () => void
    postId: number
}

function DelteForm (props: EditFormProps) {
    const [message, setMessage] = useState('');
    const [post, setPost] = useState('');

    useEffect(() => {
        GetPost(props.postId)
        .then((res) => {
            console.log(res);
        })
    }, []);

    function submitDeletePost (e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const data = new FormData(e.target as HTMLFormElement);
        const payload = Object.fromEntries(data);

        DeletePost(props.postId);
        props.selfClose();
        window.location.reload();
    }

    return (
        <div className="new-post">
            <form onSubmit={submitDeletePost} className="form main-content-form">
                <div className="message loud">{getPhrase(message)}</div>
                <input className="auth-btn" type="submit" value={getPhrase("delete")} />
            </form>
        </div>
    );

}

export default DelteForm;
