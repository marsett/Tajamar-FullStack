import { createRouter, createWebHistory } from "vue-router";
import HomeComponent from './components/HomeComponent.vue';
import SerieComponent from './components/SerieComponent.vue';
import PersonajesComponent from './components/PersonajesComponent.vue';
import CrearPersonajesComponent from './components/CrearPersonajesComponent.vue';
import ModificarPersonajesComponent from './components/ModificarPersonajesComponent.vue';

const myRoutes = [
    {
        path: "/", component: HomeComponent
    },
    {
        path: "/series/:idSerie", component: SerieComponent
    },
    {
        path: "/personajes/:idSerie", component: PersonajesComponent
    },
    {
        path: "/crear", component: CrearPersonajesComponent
    },
    {
        path: "/editar", component: ModificarPersonajesComponent
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes: myRoutes
})

export default router;