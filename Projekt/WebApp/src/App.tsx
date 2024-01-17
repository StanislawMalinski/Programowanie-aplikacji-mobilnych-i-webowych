import { Fragment, useEffect, useState } from "react";


import SideMenu from "./components/SideMenu";
import UpperMenu from "./components/UpperMenu";
import MainContent from "./components/MainContent";
import PopUpWindow from "./components/PopUpWindow";
import './App.css'

import { getUser, setUser, usr } from "./User";

function App () {
  const [mainContentState, setMainContentState] = useState("main-page");
  const [authPopUpState, setAuthPopUpState] = useState("hidden");
  const [authorized, setAuthorized] = useState(getUser() !== null);
  const [selectedUser, setSelectedUser] = useState(1);

  const [lightMode, setLightMode] = useState(true);
  const [styles, setStyles] = useState("light.css");

  useEffect(() => {
  setMainContentState("main-page");
  }, []);

  useEffect(() => {
    if (lightMode) {
      setStyles("light.css");
    } else {
      setStyles("dark.css");
    }
  }, [lightMode]);

    return <>
      <link rel="stylesheet" href={"src/components/light_modes/" + styles} />
      <div className="left split">
        <SideMenu changeState={setMainContentState} 
        loggedIn={authorized}
        setLightMode={setLightMode}
        lightMode={lightMode}/>
      </div>
      <div className="right split">
        <UpperMenu state={true} onLogin={function (): void {
            setAuthPopUpState("logging-in");
          } } onLogout={function (): void {
            setAuthPopUpState("logging-out");
          } } onRegister={function (): void {
            setAuthPopUpState("registering");
          } } onAccount={function (): void {
            setMainContentState("my-profile");
          } } authorisationStatus={authorized} 
            setAuthorisationStatus={
              setAuthorized
          }/>
        <MainContent state={mainContentState} 
            navigateToProfile={() => {setMainContentState("profile")}}
            selectedUser={selectedUser}
            setSelectedUser={setSelectedUser}
            />
      </div>
      
      <PopUpWindow state={authPopUpState}  
        setState={setAuthPopUpState} 
        setAuthorisationStatus={setAuthorized}/>
  </>
}

export default App;