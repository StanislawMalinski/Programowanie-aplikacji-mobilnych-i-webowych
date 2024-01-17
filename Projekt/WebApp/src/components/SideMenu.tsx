import { Fragment } from "react";
import { getPhrase } from "./LanguageSelector";
import './SideMenu.css';
import WebcamCapture from "./WebCamView";
import LightModeSwitch from "./LightModeSwitch ";

interface SideMenuProps {
    changeState: (arg: string) => void
    loggedIn: boolean
    setLightMode: (arg: boolean) => void
    lightMode: boolean
}

function SideMenu(props: SideMenuProps) {
    const {lightMode} = props;
    var loggedInContent = props.loggedIn ? (<>
    <button className="side-menu-btn" 
        onClick={() =>props.changeState("my-profile") }>{getPhrase("my-profile")}</button>
    <button className="side-menu-btn" 
        onClick={() => props.changeState("new-post")}>{getPhrase("new-post")}</button></>) : null;

    return (
        <>
            <div className = "side-menu-container">
            <h1>{getPhrase("forface")}</h1>
                <button className="side-menu-btn"
                        onClick={() => props.changeState("main-page")}>{getPhrase("main-page")}</button>
                {loggedInContent}
                <WebcamCapture />
                <LightModeSwitch lightMode={props.lightMode} changeLightMode={props.setLightMode} />
            </div>
        </>
    );
}

export default SideMenu;