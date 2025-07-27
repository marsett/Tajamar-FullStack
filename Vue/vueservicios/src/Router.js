import { createRouter, createWebHistory } from "vue-router";
import CochesComponent from './components/CochesComponent.vue';
import CustomersComponent from './components/CustomersComponent.vue';
import EmpleadosDetalle from './components/EmpleadosDetalle.vue';
import HomeComponent from './components/HomeComponent.vue';
import EmpleadosOficios from './components/EmpleadosOficios.vue';

const myRoutes = [
    {
        path: "/", component: HomeComponent
    },
    {
        path: "/empleadosoficios/:oficio", component: EmpleadosOficios
    },
    {
        path: "/coche", component: CochesComponent
    },
    {
        path: "/customers", component: CustomersComponent
    },
    {
        path: "/empleadosdetalle", component: EmpleadosDetalle
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes: myRoutes
})

export default router;