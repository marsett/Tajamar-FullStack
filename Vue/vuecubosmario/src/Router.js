import { createRouter, createWebHistory } from "vue-router";
import HomeComponent from './components/HomeComponent.vue';
import LoginComponent from './components/LoginComponent.vue';
import CubosMarcas from './components/CubosMarcas.vue';
import DetallesCubo from './components/DetallesCubo.vue';
import PerfilLogin from './components/PerfilLogin.vue';
import ComprasLogin from './components/ComprasLogin.vue';
import PedidoLogin from './components/PedidoLogin.vue';

const myRoutes = [
    {
        path: "/", component: HomeComponent
    },
    {
        path: "/login", component: LoginComponent
    },
    {
        path: "/cubos/:marca", component: CubosMarcas
    },
    {
        path: "/detalles/:id", component: DetallesCubo
    },
    {
        path: "/perfil", component: PerfilLogin
    },
    {
        path: "/compras", component: ComprasLogin
    },
    {
        path: "/pedido", component: PedidoLogin
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes: myRoutes
})

export default router;