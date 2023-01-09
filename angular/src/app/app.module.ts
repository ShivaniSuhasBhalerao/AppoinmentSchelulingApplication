import { CoreModule } from '@abp/ng.core';
import { GdprConfigModule } from '@volo/abp.ng.gdpr/config';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { Component, CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommercialUiConfigModule } from '@volo/abp.commercial.ng.ui/config';
import { AccountAdminConfigModule } from '@volo/abp.ng.account/admin/config';
import { AccountPublicConfigModule } from '@volo/abp.ng.account/public/config';
import { AuditLoggingConfigModule } from '@volo/abp.ng.audit-logging/config';
import { IdentityServerConfigModule } from '@volo/abp.ng.identity-server/config';
import { IdentityConfigModule } from '@volo/abp.ng.identity/config';
import { LanguageManagementConfigModule } from '@volo/abp.ng.language-management/config';
import { registerLocale } from '@volo/abp.ng.language-management/locale';
import { SaasConfigModule } from '@volo/abp.ng.saas/config';
import { TextTemplateManagementConfigModule } from '@volo/abp.ng.text-template-management/config';
import { HttpErrorComponent, ThemeLeptonModule } from '@volo/abp.ng.theme.lepton';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { CUSTOMERS_CUSTOMER_ROUTE_PROVIDER } from './customers/customer/providers/customer-route.provider';

import { Routes } from '@angular/router';

 import { CalenderComponent } from './calender/calender.component';
 import { CALENDER_ROUTE_PROVIDER } from './calender/providers/calender-route.provider';

import { DxSchedulerModule } from 'devextreme-angular'; 


@NgModule({
  declarations: [AppComponent,
    CalenderComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    DxSchedulerModule,
 
    

    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
    
    }),
    ThemeSharedModule.forRoot({
      httpErrorConfig: {
        errorScreen: {
          component: HttpErrorComponent,
          forWhichErrors: [401, 403, 404, 500],
          hideCloseIcon: true,
        },
      },
    }),
    AccountAdminConfigModule.forRoot(),
    AccountPublicConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    LanguageManagementConfigModule.forRoot(),
    SaasConfigModule.forRoot(),
    AuditLoggingConfigModule.forRoot(),
    IdentityServerConfigModule.forRoot(),
    TextTemplateManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    ThemeLeptonModule.forRoot(),
    CommercialUiConfigModule.forRoot(),
    GdprConfigModule.forRoot(),
  
  ],
  providers: [
    APP_ROUTE_PROVIDER,
    CUSTOMERS_CUSTOMER_ROUTE_PROVIDER,
    
    CALENDER_ROUTE_PROVIDER,
    
    
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
