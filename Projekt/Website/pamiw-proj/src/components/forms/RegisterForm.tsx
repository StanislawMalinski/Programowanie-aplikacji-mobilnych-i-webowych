import React, { useState } from "react";
import { Register } from "../../Client";
import { setUser } from "../../User";
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
            alert("Passwords do not match");
            return;
        }
        delete payload.repeatpassword;
        
        Register(payload)
        .then((res) => {
            console.log(res);
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
            setMassege(res.message);
        }).catch((err) => {
            console.error(err);
        });
    }

    return (
        <>
            <div className="form-container">
                <div className="message loud">{message}</div>
                <form onSubmit={submitForm} className="form">
                    <input className='form-input' type='email' name='email' placeholder='Your Mail'></input>
                    <input className='form-input' type='text' name='userName' placeholder='Your UserName'></input>
                    <input className='form-input' type="password" name='password' placeholder='Password'></input>
                    <input className='form-input' type="password" name='repeatpassword' placeholder='Password 2'></input>
                    <button className="auth-btn" type='submit'>Register</button>
                </form>
            </div>
        </>
    );
}

export default RegisterForm;