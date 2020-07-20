import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { EquipePage } from './pages/equipe/equipe.page';
import {  ResultadoPage } from './pages/resultado/resultado.page';

const appRoutes: Routes = [
  { path: '', redirectTo: 'home',  pathMatch: 'full'},
  { path: 'home', component:  EquipePage},
  { path: 'resultado', component:  ResultadoPage}
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class Routing { }