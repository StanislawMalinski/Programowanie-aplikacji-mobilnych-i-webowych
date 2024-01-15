import React from 'react';
import Popup from 'reactjs-popup';
import { IoMdCloseCircleOutline } from "react-icons/io";
import { getPhrase } from './../LanguageSelector';


import 'reactjs-popup/dist/index.css';
import './PopUpWindowForPost.css'

import EditForm from './EditForm';
import DeleteForm from './DeleteForm';

interface PopUpWindowForPostProps {
    state: string
    setState: (arg: string) => void
    postId: number
}


function PopUpWindowForPost(props: PopUpWindowForPostProps) {

    const EditContent = (
        <>
            <h1>{getPhrase("edit")}</h1>
            <div className='auth-btns'>
                <EditForm selfClose={() => 
                    props.setState("hidden")} 
                    postId={props.postId}/>
                <button className='auth-btn' onClick={() => props.setState("hidden")}>
                {getPhrase("cancel")}
                </button>
            </div>
        </>
    )
    
    const DeleteContent = (
        <>
            <h1>{getPhrase("delete")}</h1>
            <div className='auth-btns'>
                <DeleteForm selfClose={() => props.setState("hidden")} postId={props.postId} />
                <button className='auth-btn' onClick={() => props.setState("hidden")}>
                {getPhrase("cancel")}
                </button>
            </div>
        </>
    )

    var content;
    // console.log(props.state);
    switch (props.state) {
        case "hidden":
            content = <div></div>;
            break;
        case "edit": 
            content = EditContent;
            break;
        case "delete":
            content = DeleteContent;
            break;
        default:
            content = <h1>{getPhrase("error-massage")}</h1>
    }
    
    return props.state != "hidden" && (
        <div className='popup'>
            <div className='popup-inner'>
                <div className='close-button-container' onClick={() => props.setState("hidden")}>
                    <IoMdCloseCircleOutline />
                </div>
                <p> {content} </p>
            </div>
        </div> 
    )
}



export default PopUpWindowForPost;