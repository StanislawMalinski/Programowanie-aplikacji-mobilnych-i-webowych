import './UpperMenu.css'
import { VscAccount } from "react-icons/vsc";

interface UpperMenuProps {
    state: boolean
    onLogin: () => void
    onLogout: () => void
    onRegister: () => void
    onAccount: () => void

    authorisationStatus: boolean
    setAuthorisationStatus: (arg: boolean) => void
}

function UpperMenu(props: UpperMenuProps) {
    const getButtons = (arg: boolean) => {
        return arg ? 
            ( <><button className="upper-menu-btn"
                        onClick={props.onLogout}>Logout</button>
                    <div className="upper-menu-btn account-icon" onClick={props.onAccount}>
                        <VscAccount />
                    </div>
                </>) 
            :
            (<><button className="upper-menu-btn"
                       onClick={props.onLogin}>Login</button>
            <button className="upper-menu-btn"
                        onClick={props.onRegister}>Register</button></>);
    }

    return (
        <>
            <div className = "upper-menu-container">
                {getButtons(props.authorisationStatus)}
                <button onClick={() => props.setAuthorisationStatus(!props.authorisationStatus)}> (tmp change)</button>
            </div>
        </>
    );
}

export default UpperMenu;