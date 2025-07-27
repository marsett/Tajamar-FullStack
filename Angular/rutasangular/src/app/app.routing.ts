import { HomeComponent } from "./components/home/home.component";
import { CineComponent } from "./components/cine/cine.component";
import { MusicaComponent } from "./components/musica/musica.component";

// Necesitamos una serie de módulos que se encuentran dentro de Angular
// para la navegación de rutas
import { Routes, RouterModule } from "@angular/router";
import { ModuleWithProviders } from "@angular/core";
import { NotfoundComponent } from "./components/notfound/notfound.component";
import { NumerodobleComponent } from "./components/numerodoble/numerodoble.component";
import { TablamultiplicarroutingComponent } from "./components/tablamultiplicarrouting/tablamultiplicarrouting.component";

// Necesitamos un array con las rutas
const appRoutes: Routes = [
    {
        path: "", component: HomeComponent
    },
    {
        path: "cine", component: CineComponent
    },
    {
        path: "musica", component: MusicaComponent
    },
    {
        path: "numerodoble", component: NumerodobleComponent
    },
    {
        path: "numerodoble/:numero", component: NumerodobleComponent
    },
    {
        path: "tabla/:numero", component: TablamultiplicarroutingComponent
    },
    {
        path: "**", component: NotfoundComponent
    },
];

// Desde esta clase debemos exportar el array de rutas como proveedor
export const appRoutingProvider: any[] = [];
// Las rutas en sí mismas
export const routing: ModuleWithProviders<any> = RouterModule.forRoot(appRoutes);
