// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from "./components/home/home.component";

@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: "", component: HomeComponent, data: { title: "Home" } },
            { path: "home", redirectTo: "/", pathMatch: "full" },
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }
