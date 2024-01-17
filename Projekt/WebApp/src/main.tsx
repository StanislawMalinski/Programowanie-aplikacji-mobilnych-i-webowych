import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import 'bootstrap/dist/css/bootstrap.css'
import { GoogleOAuthProvider } from '@react-oauth/google';


ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
      <GoogleOAuthProvider clientId={'1075351474485-6auar2g3v1pt2hm3l6sdipf776ame465.apps.googleusercontent.com'}>
        <App />
      </GoogleOAuthProvider>
  </React.StrictMode>,
)
