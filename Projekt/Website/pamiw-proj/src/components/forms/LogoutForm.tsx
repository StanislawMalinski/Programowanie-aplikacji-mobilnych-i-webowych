import React, { useState } from "react";
import { removeUser } from "../../User";
import './Form.css'

interface LogoutFormProps {
    selfClose: () => void
    setAuthorised: (arg: boolean) => void
}

function LogoutForm(props: LogoutFormProps) {
    const [message, setMassege] = useState('')

    function submitForm(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        removeUser();
        props.setAuthorised(false);
        props.selfClose();
    }

    return (
        <>
            <div className="form-container">
                <div className="message loud">{message}</div>
                <form onSubmit={submitForm} className="form">
                    <div className="message">Are you sure you want to log out?</div>
                    <button className="auth-btn" type='submit'>Logout</button>
                </form>
            </div>
        </>
    );
}

export default LogoutForm;