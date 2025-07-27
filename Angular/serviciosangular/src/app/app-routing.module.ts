import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LibreriaComponent } from './components/libreria/libreria.component';
import { MenuComponent } from './components/menu/menu.component';
import { PersonasstandaloneComponent } from './components/personasstandalone/personasstandalone.component';
import { CochesComponent } from './components/coches/coches.component';
import { PlantillafuncionsimpleComponent } from './components/plantillafuncionsimple/plantillafuncionsimple.component';
import { PlantillafuncionmultipleComponent } from './components/plantillafuncionmultiple/plantillafuncionmultiple.component';

const routes: Routes = [
  {
    path: '',
    component: PersonasstandaloneComponent
  },
  {
    path: 'libreria',
    component: LibreriaComponent
  },
  {
    path: 'coches',
    component: CochesComponent
  },
  {
    path: 'plantilla',
    component: PlantillafuncionsimpleComponent
  },
  {
    path: 'plantillamultiple',
    component: PlantillafuncionmultipleComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
