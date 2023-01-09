
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalenderComponent } from '../calender.component';


const routes: Routes = [
  {
    path: '',
    component: CalenderComponent,
   // canActivate: [AuthGuard, PermissionGuard],
   
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes),CommonModule],
  exports: [RouterModule],
})
export class CalenderRoutingModule {}