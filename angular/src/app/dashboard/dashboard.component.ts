import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'AppoinmentSchelulingProject.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'AppoinmentSchelulingProject.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
