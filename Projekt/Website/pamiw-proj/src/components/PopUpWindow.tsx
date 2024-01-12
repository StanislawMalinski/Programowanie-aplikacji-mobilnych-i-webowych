import React from 'react';
import Popup from 'reactjs-popup';
import { IoMdCloseCircleOutline } from "react-icons/io";

import RegisterForm from './forms/RegisterForm';
import LoginForm from './forms/LoginForm';


import 'reactjs-popup/dist/index.css';
import './PopUpWindow.css'
import LogoutForm from './forms/LogoutForm';

interface PopUpWindowProps {
    state: string
    setState: (arg: string) => void
    setAuthorisationStatus: (arg: boolean) => void
}


function PopUpWindow(props: PopUpWindowProps) {

    const LoginContent = (<>
            <h1>Login you fat fuck</h1>
            <div className='auth-btns'>
                <LoginForm selfClose={() => props.setState("hidden")} setAuthorised={props.setAuthorisationStatus} />
                <button className='auth-btn'>
                    Login with Google
                </button>
                <button className='auth-btn' onClick={() => props.setState("hidden")}>
                    Cancle
                </button>
            </div>
        </>
    )
    

    const RegisterContent = (
        <>
            <h1>Register you fuckin asshole</h1>
            <div className='auth-btns'>
                <RegisterForm selfClose={() => props.setState("hidden")} setAuthorised={props.setAuthorisationStatus}/>
                <button className='auth-btn'>
                    Register with Google
                </button>
                <button className='auth-btn' onClick={() => props.setState("hidden")}>
                    Cancle
                </button>
            </div>
        </>
    )
    
    const LogoutContent = (
        <>
            <h1>Logout you stupid piece of shit</h1>
            <div className='auth-btns'>
                <LogoutForm selfClose={() => props.setState("hidden")} setAuthorised={props.setAuthorisationStatus}/>
                <button className='auth-btn' onClick={() => props.setState("hidden")}>
                    Cancle
                </button>
            </div>
        </>
    )

    var content;
    switch (props.state) {
        case "hidden":
            content = <div></div>;
            break;
        case "logging-in":
            content = LoginContent;
            break;
        case "logging-out":
            content = LogoutContent;
            break;
        case "registering":
            content = RegisterContent;
            break;
        default:
            content = <h1>Twoja stara to kopara.</h1>
    }
    
    return props.state != "hidden" && (
        <div className='popup'>
            <div className='popup-inner'>
                <div className='close-button-container' onClick={() => props.setState("hidden")}>
                    <IoMdCloseCircleOutline />
                </div>
                <h1>
                    Here is your fuckin popup
                </h1>
                <p> {content} </p>
            </div>
        </div> 
    )
}



export default PopUpWindow;