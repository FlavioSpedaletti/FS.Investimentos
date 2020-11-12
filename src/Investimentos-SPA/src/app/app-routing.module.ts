import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './views/home/home.component';
import { InvestmentCrudComponent } from './views/investment-crud/investment-crud.component';


const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'investments', component: InvestmentCrudComponent
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
