import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import Contador from './components/Contador';
import DibujosComplejos from './components/DibujosComplejos';
import DibujosComplejosReact from './components/DibujosComplejosReact';
import PadreDeportes from './components/PadreDeportes';
import PadreNumeros from './components/PadreNumeros';
import Comics from './components/Comics';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    {/* <App /> */}
    {/* <Contador inicio="9"></Contador>
    <Contador inicio="14"></Contador> */}
    {/* <DibujosComplejos></DibujosComplejos> */}
    {/* <DibujosComplejosReact></DibujosComplejosReact> */}
    {/* <PadreDeportes></PadreDeportes> */}
    {/* <PadreNumeros></PadreNumeros> */}
    <Comics></Comics>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
