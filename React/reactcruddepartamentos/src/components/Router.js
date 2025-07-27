import React, { Component } from 'react';
import { BrowserRouter, Routes, Route, useParams } from 'react-router-dom';
import HomeDepartamentos from './HomeDepartamentos';
import MenuDepartamentos from './MenuDepartamentos';
import CreateDepartamentos from './CreateDepartamentos';
import DetalleDepartamento from './DetalleDepartamento';
import UpdateDepartamento from './UpdateDepartamento';
import DeleteDepartamentos from './DeleteDepartamentos';

export default class Router extends Component {
    render() {
        function DetalleDepartamentoElement() {
            let { iddepartamento } = useParams();
            return (
                <DetalleDepartamento id={iddepartamento} />
            )
        }
        function UpdateDepartamentoElement() {
            let { id, nombre, localidad } = useParams();
            return (
                <UpdateDepartamento id={id} nombre={nombre} localidad={localidad}></UpdateDepartamento>
            )
        }
        function DeleteDepartamentoElement() {
            let { id } = useParams();
            return (
                <DeleteDepartamentos id={id}></DeleteDepartamentos>
            )
        }
        return (
            <BrowserRouter>
                <MenuDepartamentos />
                <Routes>
                    <Route path="/" element={<HomeDepartamentos />}></Route>
                    <Route path="/create" element={<CreateDepartamentos />}></Route>
                    <Route path="/detalles/:iddepartamento" element={<DetalleDepartamentoElement />}></Route>
                    <Route path="/update/:id/:nombre/:localidad" element={<UpdateDepartamentoElement></UpdateDepartamentoElement>} />
                    <Route path="/delete/:id" element={<DeleteDepartamentoElement/>} />
                </Routes>
            </BrowserRouter>
        )
    }
}
