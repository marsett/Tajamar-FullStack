import { BrowserRouter, Routes, Route } from "react-router-dom";
import React, { Component } from 'react'
import Home from './Home';
import Cine from './Cine';
import Musica from './Musica';
import Collatz from "./Collatz";
import TablaMultiplicar from "./TablaMultiplicar";
import TablaSelect from "./TablaSelect";
import SeleccionMultiple from "./SeleccionMultiple";
import MenuRutas from "./MenuRutas";

export default class Router extends Component {
    render() {
        return (
            <BrowserRouter>
            <MenuRutas/>
                <Routes>
                    <Route path="/" element={<Home></Home>}></Route>
                    <Route path="/cine" element={<Cine></Cine>}></Route>
                    <Route path="/musica" element={<Musica></Musica>}></Route>
                    <Route path="/collatz" element={<Collatz></Collatz>}></Route>
                    <Route path="/tabla" element={<TablaMultiplicar></TablaMultiplicar>}></Route>
                    <Route path="/select" element={<TablaSelect></TablaSelect>}></Route>
                    <Route path="/seleccionmultiple" element={<SeleccionMultiple></SeleccionMultiple>}></Route>
                </Routes>
            </BrowserRouter>
        )
    }
}
