import './UpperMenu.css'
import { VscAccount } from "react-icons/vsc";
import { getPhrase } from "./LanguageSelector";
import LanguageSelector from './LanguageSelector';

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
                        onClick={props.onLogout}>{getPhrase("logout")}</button>
                    <div className="upper-menu-btn account-icon" onClick={props.onAccount}>
                        <VscAccount />
                    </div>
                </>) 
            :
            (<><button className="upper-menu-btn"
                       onClick={props.onLogin}>{getPhrase("login")}</button>
            <button className="upper-menu-btn"
                        onClick={props.onRegister}>{getPhrase("register")}</button></>);
    }

    return (
        <>
            <div className = "upper-menu-container">
                <div className='language-selector-container'>
                    <LanguageSelector />
                </div>
                {getButtons(props.authorisationStatus)}
                
            </div>
        </>
    );
}

export default UpperMenu;