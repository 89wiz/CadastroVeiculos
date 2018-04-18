import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { VeiculosComponent } from './components/veiculos/veiculos.component';
import { VeiculoDetalheComponent } from './components/veiculo-detalhe/veiculo-detalhe.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        VeiculosComponent,
        VeiculoDetalheComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'veiculos', component: VeiculosComponent },
            { path: 'veiculos/:id', component: VeiculoDetalheComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
