import React, { useState } from "react";
import Webcam from "react-webcam";

import './WebCamView.css';
import { getPhrase } from "./LanguageSelector";

const videoConstraints = {
    width: 1280,
    height: 720,
    facingMode: "user"
  };
  
const WebcamCapture = () => {
    const webcamRef = React.useRef(null);
    const [switchValue, setSwitch] = useState(false);
    
    return (
      <>
        <button className='side-menu-btn' onClick={() => setSwitch(!switchValue)}>
            {switchValue ? getPhrase('turn-off') : getPhrase('turn-on')}
        </button>
      {switchValue ? (
        <div className="webcam-container">
            <Webcam
            audio={false}
            mirrored={true}
            height={Math.floor(screen.width * 0.1)}      
            ref={webcamRef}
            screenshotFormat="image/jpeg"
            
            videoConstraints={videoConstraints}
            className="webcam"
            />
        </div>
      ) : <></>}

      </>
    );
  };

  export default WebcamCapture;
  