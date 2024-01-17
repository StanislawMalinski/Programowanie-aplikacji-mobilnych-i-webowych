import React, { useState } from "react";
import { removeUser } from "../../User";
import { getPhrase } from "../LanguageSelector";
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
        window.location.reload();
    }

    return (
        <>
            <div className="form-container">
                <div className="message loud">{getPhrase(message)}</div>
                <form onSubmit={submitForm} className="form">
                    <div className="message">{getPhrase("logout-message")}</div>
                    <button className="auth-btn" type='submit'>{getPhrase("logout")}</button>
                </form>
            </div>
        </>
    );
}

export default LogoutForm;