import { Fragment } from "react"
import './SideMenu.css'

interface SideMenuProps {
    changeState: (arg: string) => void
    loggedIn: boolean
}

function SideMenu(props: SideMenuProps) {
    var loggedInContent = props.loggedIn ? (<>
    <button className="side-menu-btn" 
        onClick={() =>props.changeState("my-profile") }>My Profile</button>
    <button className="side-menu-btn" 
        onClick={() => props.changeState("new-post")}>New Post</button></>) : null;

    return (
        <>
            <div className = "side-menu-container">
            <h1>ForFace</h1>
                <button className="side-menu-btn"
                        onClick={() => props.changeState("main-page")}>Home</button>
                {loggedInContent}
            </div>
        </>
    );
}

export default SideMenu;