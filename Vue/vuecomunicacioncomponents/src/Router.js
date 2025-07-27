import { createRouter, createWebHistory } from "vue-router";
import HomeComponent from './components/HomeComponent.vue';
import PadreDeportes from './components/PadreDeportes.vue';
import EjemploCheckbox from './components/EjemploCheckbox.vue';
import NumeroDoble from './components/NumeroDoble.vue';
import TablaMultiplicar from './components/TablaMultiplicar.vue';

const myRoutes = [
    {
        path: "/", component: HomeComponent
    },
    {
        path: "/deportes/:id?", component: PadreDeportes
    },
    {
        path: "/ejemplo", component: EjemploCheckbox
    },
    {
        path: "/numerodoble/:numero?", component: NumeroDoble
    },
    {
        path: "/tabla/:numero", component: TablaMultiplicar
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes: myRoutes
})

export default router;