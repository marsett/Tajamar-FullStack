import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { PerfilempleadoComponent } from './components/perfilempleado/perfilempleado.component';
import { MenuComponent } from './components/menu/menu.component';
import { SubordinadosempleadoComponent } from './components/subordinadosempleado/subordinadosempleado.component';


const routes: Routes = [
  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'perfil',
    component: PerfilempleadoComponent
  },
  {
    path: 'menu',
    component: MenuComponent
  },
  {
    path: 'subordinados',
    component: SubordinadosempleadoComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
