import { createRouter, createWebHistory } from "vue-router";
import LoginComponent from './components/LoginComponent.vue';
import AlumnosToken from './components/AlumnosToken.vue';
import CursosToken from './components/CursosToken.vue';
import FiltrarCurso from './components/FiltrarCurso.vue';
import FindAlumno from './components/FindAlumno.vue';
import InsertAlumno from './components/InsertAlumno.vue';
import UpdateAlumno from './components/UpdateAlumno.vue';
import DeleteAlumno from './components/DeleteAlumno.vue';
import UpdateState from './components/UpdateState.vue';

const myRoutes = [
    {
        path: "/", component: LoginComponent
    },
    {
        path: "/alumnostoken", component: AlumnosToken
    },
    {
        path: "/cursostoken", component: CursosToken
    },
    {
        path: "/filtrarcursos", component: FiltrarCurso
    },
    {
        path: "/findalumno", component: FindAlumno
    },
    {
        path: "/insertalumno", component: InsertAlumno
    },
    {
        path: "/updatealumno/:id", component: UpdateAlumno
    },
    {
        path: "/deletealumno/:id", component: DeleteAlumno
    },
    {
        path: "/updatestate/:id/:state", component: UpdateState
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes: myRoutes
})

export default router;