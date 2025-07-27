import { createRouter, createWebHistory } from "vue-router";
import InicioCoches from './components/InicioCoches.vue';
import CrearCoche from './components/CrearCoche.vue';
import ActualizarCoche from './components/ActualizarCoche.vue';
import DetallesCoche from './components/DetallesCoche.vue';
import BorrarCoche from './components/BorrarCoche.vue';

const myRoutes = [
    {
        path: "/", component: InicioCoches
    },
    {
        path: "/crear", component: CrearCoche
    },
    {
        path: "/detalles/:id/:marca/:modelo/:conductor/:imagen", component: DetallesCoche
    },
    {
        path: "/editar/:id", component: ActualizarCoche
    },
    {
        path: "/eliminar/:id", component: BorrarCoche
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes: myRoutes
})

export default router;