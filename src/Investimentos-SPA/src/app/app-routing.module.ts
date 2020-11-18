import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './views/home/home.component';
import { InvestmentCrudComponent } from './views/investment-crud/investment-crud.component';
import { InvestmentCreateComponent } from './components/investment/investment-create/investment-create.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'investments', component: InvestmentCrudComponent
  },
  {
    path: 'investments/create', component: InvestmentCreateComponent
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
