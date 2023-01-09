import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';
import {  DxButtonModule } from 'devextreme-angular'

const routes: Routes = [{ path: '', component: DashboardComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes),DxButtonModule],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}
