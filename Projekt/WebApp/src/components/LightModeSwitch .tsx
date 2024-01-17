import { IoMdSunny } from "react-icons/io";
import { MdOutlineWbSunny } from "react-icons/md";

import { useState } from "react";
import './LightModeSwitch.css';

interface LightModeSwitchProps {
    lightMode: boolean;
    changeLightMode: (arg0: boolean) => void;
}

function LightModeSwitch(props: LightModeSwitchProps) {
    const {lightMode, changeLightMode} = props;
    const change = () => {
        changeLightMode(!lightMode);
    }

    return (<>
            <div className="light-mode-switch-container">
                <button className="side-menu-btn light-mode-switch-btn" onClick={change}>
                    {lightMode ? <IoMdSunny /> : <MdOutlineWbSunny />}
                </button>
            </div>
        </>);
}

export default LightModeSwitch;