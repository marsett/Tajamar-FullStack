import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ComprasComponent } from './components/compras/compras.component';
import { CubosmarcasComponent } from './components/cubosmarcas/cubosmarcas.component';
import { DetallescuboComponent } from './components/detallescubo/detallescubo.component';
import { MenuComponent } from './components/menu/menu.component';
import { PedidoComponent } from './components/pedido/pedido.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { provideHttpClient } from '@angular/common/http';
import { ServiceCubo } from './services/service.cubo';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    ComprasComponent,
    CubosmarcasComponent,
    DetallescuboComponent,
    MenuComponent,
    PedidoComponent,
    PerfilComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [provideHttpClient(), ServiceCubo],
  bootstrap: [AppComponent]
})
export class AppModule { }
