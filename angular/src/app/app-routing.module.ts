import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'dashboard',
    loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule),
    canActivate: [AuthGuard, PermissionGuard],
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@volo/abp.ng.account/public').then(m => m.AccountPublicModule.forLazy()),
  },
  {
    path: 'gdpr',
    loadChildren: () => import('@volo/abp.ng.gdpr').then(m => m.GdprModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@volo/abp.ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'language-management',
    loadChildren: () =>
      import('@volo/abp.ng.language-management').then(m => m.LanguageManagementModule.forLazy()),
  },
  {
    path: 'saas',
    loadChildren: () => import('@volo/abp.ng.saas').then(m => m.SaasModule.forLazy()),
  },
  {
    path: 'audit-logs',
    loadChildren: () =>
      import('@volo/abp.ng.audit-logging').then(m => m.AuditLoggingModule.forLazy()),
  },
  {
    path: 'identity-server',
    loadChildren: () =>
      import('@volo/abp.ng.identity-server').then(m => m.IdentityServerModule.forLazy()),
  },
  {
    path: 'text-template-management',
    loadChildren: () =>
      import('@volo/abp.ng.text-template-management').then(m =>
        m.TextTemplateManagementModule.forLazy()
      ),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'customers',
    loadChildren: () => import('./customers/customer/customer.module').then(m => m.CustomerModule),
  },
  {
    path: 'calender',
    loadChildren: () =>
      import('./calender/providers/calender.module').then(m => m.CalenderModule),
    
     
     
  },

  // {
  //      path: 'cust',
  //     loadChildren: () => import('./index/index.module').then(m => m.IndexModule),
  //    },

  // {
  //   path: 'index',
  //   component: IndexComponent,

  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
