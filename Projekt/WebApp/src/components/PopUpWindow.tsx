import React, { useEffect } from 'react';
import Popup from 'reactjs-popup';
import { IoMdCloseCircleOutline } from "react-icons/io";
import { getPhrase } from './LanguageSelector';

import RegisterForm from './forms/RegisterForm';
import LoginForm from './forms/LoginForm';


import 'reactjs-popup/dist/index.css';
import './PopUpWindow.css'

import { gapi } from 'gapi-script';
import LogoutForm from './forms/LogoutForm';
import { GoogleLogin, CredentialResponse } from '@react-oauth/google';

interface PopUpWindowProps {
    state: string
    setState: (arg: string) => void
    setAuthorisationStatus: (arg: boolean) => void
}


function PopUpWindow(props: PopUpWindowProps) {

    useEffect(() => {
        function start() {
            gapi.client.init({
                clientId: '1075351474485-6auar2g3v1pt2hm3l6sdipf776ame465.apps.googleusercontent.com',
                scope: ''
            })
        }

        gapi.load('auth2', start);
   });
        

    const LoginContent = (<>
            <h1>{getPhrase("login")}</h1>
            <div className='auth-btns'>
                <LoginForm selfClose={() => props.setState("hidden")} setAuthorised={props.setAuthorisationStatus} />
                <GoogleLogin onSuccess={
                    (response: CredentialResponse) => {
                    console.log(response);}}>
                        {getPhrase('login-with-google')}
                </GoogleLogin>
                <button className='auth-btn' onClick={() => props.setState("hidden")}>
                {getPhrase("cancel")}
                </button>
            </div>
        </>
    )
    

    const RegisterContent = (
        <>
            <h1>{getPhrase("register")}</h1>
            <div className='auth-btns'>
                <RegisterForm selfClose={() => props.setState("hidden")} setAuthorised={props.setAuthorisationStatus}/>
                <button className='auth-btn'>
                {getPhrase("register-with-google")}
                </button>
                <button className='auth-btn' onClick={() => props.setState("hidden")}>
                {getPhrase("cancel")}
                </button>
            </div>
        </>
    )
    
    const LogoutContent = (
        <>
            <h1>{getPhrase("logout")}</h1>
            <div className='auth-btns'>
                <LogoutForm selfClose={() => props.setState("hidden")} setAuthorised={props.setAuthorisationStatus}/>
                <button className='auth-btn' onClick={() => props.setState("hidden")}>
                {getPhrase("cancel")}
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
            content = <h1>{getPhrase("error-massage")}</h1>
    }
    
    return props.state != "hidden" ? (
        <div className='popup'>
            <div className='popup-inner'>
                <div className='close-button-container' onClick={() => props.setState("hidden")}>
                    <IoMdCloseCircleOutline />
                </div>
                <h1>
                {getPhrase("hi")}
                </h1>
                <p> {content} </p>
            </div>
        </div> 
    ) : <></>;
}



export default PopUpWindow;