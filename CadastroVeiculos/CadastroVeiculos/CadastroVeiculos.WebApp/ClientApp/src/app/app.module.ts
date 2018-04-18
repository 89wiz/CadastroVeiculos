import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { VeiculosComponent } from './veiculos/veiculos.component';
import { VeiculoDetalheComponent } from './veiculo-detalhe/veiculo-detalhe.component';

import { VeiculoService } from '../services/veiculo.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    VeiculosComponent,
    VeiculoDetalheComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'veiculos', component: VeiculosComponent },
      { path: 'veiculos/:id', component: VeiculoDetalheComponent },
    ])
  ],
  providers: [
    VeiculoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
