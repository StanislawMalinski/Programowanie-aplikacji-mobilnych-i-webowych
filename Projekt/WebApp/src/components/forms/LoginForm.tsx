import React, { useState } from 'react';
import './Form.css';
import { setUser } from '../../User';
import { Login } from '../../Client';
import { getPhrase } from '../LanguageSelector';

//import { GoogleLogin } from '@react-oauth/google';



interface LoginFormProps {
    selfClose: () => void
    setAuthorised: (arg: boolean) => void
}

function LoginForm (props: LoginFormProps) {
    const [message, setMessage] = useState('');

    function submitForm (e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const data = new FormData(e.target as HTMLFormElement);
        const payload = Object.fromEntries(data);

        Login(payload)
        .then((res) => {
            // console.log(res);
            if (res.message === null){
                var user = {
                    id: res.id,
                    
                    userName: res.user.userName,
                    email: res.user.email,
                    permissions: res.permissions
                }
                setUser(user);
                props.setAuthorised(true);
                props.selfClose();
                return;
            }
            setMessage(res.message);
        }).catch((err) => {
            console.error(err);
        });
    }

    return (
        <>
            <div className="form-container">
                <div className="message loud">{getPhrase(message)}</div>
                <form onSubmit={submitForm} className="form">
                    <input className='form-input' type='email' name='email' placeholder={getPhrase("your-mail")}></input>
                    <input className='form-input' type="password" name='password' placeholder={getPhrase("password")}></input>
                    <button className="auth-btn" type='submit'>{getPhrase("login")}</button>
                </form>
            </div>
        </>
    );

}

export default LoginForm;

/*

                <GoogleLogin
                    onSuccess={credentialResponse => {
                        // console.log(credentialResponse);
                    }}
                    onError={() => {
                        // console.log('Login Failed');
                    }}
/>;

*/