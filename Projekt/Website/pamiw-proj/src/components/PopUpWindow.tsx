import React from 'react';
import Popup from 'reactjs-popup';
import { IoMdCloseCircleOutline } from "react-icons/io";
import 'reactjs-popup/dist/index.css';
import './PopUpWindow.css'

interface PopUpWindowProps {
    state: string
    setState: (arg: string) => void
}


function PopUpWindow(props: PopUpWindowProps) {

    const LoginContent = (
        <h1>Login you fat fuck</h1>
    )
    
    const RegisterContent = (
        <h1>Register you fuckin asshole</h1>
    )
    
    const LogoutContent = (
        <h1>Logout you stupid piece of shit</h1>
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