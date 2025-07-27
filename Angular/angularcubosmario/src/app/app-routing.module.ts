import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CubosmarcasComponent } from './components/cubosmarcas/cubosmarcas.component';
import { DetallescuboComponent } from './components/detallescubo/detallescubo.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { LoginComponent } from './components/login/login.component';
import { ComprasComponent } from './components/compras/compras.component';
import { PedidoComponent } from './components/pedido/pedido.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'cubos/:marca',
    component: CubosmarcasComponent
  },
  {
    path: 'detalles/:id',
    component: DetallescuboComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'perfil',
    component: PerfilComponent
  },
  {
    path: 'compras',
    component: ComprasComponent
  },
  {
    path: 'pedido',
    component: PedidoComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
