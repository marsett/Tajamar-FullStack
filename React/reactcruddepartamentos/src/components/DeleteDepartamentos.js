import React, { Component } from 'react';
import axios from 'axios';
import Global from './Global';
import { Navigate, NavLink } from 'react-router-dom';
import Swal from 'sweetalert2';

export default class DeleteDepartamentos extends Component {
    state = {
        status: false
    }

    deleteDepartamento = () => {
        let id = this.props.id;
        let request = "api/departamentos/" + id;
        let url = Global.apiUrlDepartamentos + request;
        Swal.fire({
            title: "¿Estás seguro?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Sí, borralo"
        }).then((result) => {
            if (result.isConfirmed) {
                axios.delete(url).then(response => {
                    console.log("Borrado");
                    this.setState({
                        status: true
                    })
                })
                Swal.fire({
                    title: "Deleted!",
                    text: "Your file has been deleted.",
                    icon: "success"
                });
            }
        });
    }
    
    componentDidMount = () => {
        this.deleteDepartamento();
    }

    render() {
        return (
            <div>
                {
                    this.state.status == true &&
                    (
                        <Navigate to="/" />
                    )
                }
            </div>
        )
    }
}
