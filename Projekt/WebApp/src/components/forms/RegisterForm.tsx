import React, { useState } from "react";
import { Register } from "../../Client";
import { setUser } from "../../User";
import { getPhrase } from "../LanguageSelector";
import './Form.css'

interface RegisterFormProps {
    selfClose: () => void
    setAuthorised: (arg: boolean) => void
}

function RegisterForm(props: RegisterFormProps) {
    const [message, setMassege] = useState('')

    function submitForm(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        const data = new FormData(e.target as HTMLFormElement);
        const payload = Object.fromEntries(data);
        

        if (payload.password !== payload.repeatpassword) {
            alert(getPhrase("invalid-password-massage"));
            return;
        }
        delete payload.repeatpassword;
        
        Register(payload)
        .then((res) => {
            // console.log(res);
            if (res.message === null){
                var user = {
                    id: res.user.id,
                    bio: res.user.bio, 
                    userName: res.user.userName,
                    email: res.user.email,
                    permissions: res.jwt.permissions
                }
                setUser(user);
                props.setAuthorised(true);
                props.selfClose();
                return;
            }
            setMassege(res.message);
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
                    <input className='form-input' type='text' name='userName' placeholder={getPhrase("your-username")}></input>
                    <input className='form-input' type="password" name='password' placeholder={getPhrase("password")}></input>
                    <input className='form-input' type="password" name='repeatpassword' placeholder={getPhrase("repeate-password")}></input>
                    <button className="auth-btn" type='submit'>{getPhrase("register")}</button>
                </form>
            </div>
        </>
    );
}

export default RegisterForm;