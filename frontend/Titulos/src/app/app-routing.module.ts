import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DividasComponent } from './dividas/dividas.component';
import { ParcelasComponent } from './parcelas/parcelas.component';

const routes: Routes = [
  { path: '', redirectTo: "dividas", pathMatch: "full" },
  { path: 'dividas', component: DividasComponent },
  { path: 'parcelas', component: ParcelasComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
