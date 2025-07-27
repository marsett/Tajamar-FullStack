import { createRouter, createWebHistory } from "vue-router";
import LoginComponent from './components/LoginComponent.vue';
import PerfilEmpleadoComponent from './components/PerfilEmpleadoComponent.vue';
import MenuComponent from './components/MenuComponent.vue';
import SubordinadosEmpleadoComponent from './components/SubordinadosEmpleadoComponent.vue';

const myRoutes = [
    {
        path: "/", component: LoginComponent
    },
    {
        path: "/perfil", component: PerfilEmpleadoComponent
    },
    {
        path: "/menu", component: MenuComponent
    },
    {
        path: "/subordinados", component: SubordinadosEmpleadoComponent
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes: myRoutes
})

export default router;