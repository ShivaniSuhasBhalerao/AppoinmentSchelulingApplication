import { CoreModule } from '@abp/ng.core';

import { ThemeSharedModule } from '@abp/ng.theme.shared';

import { NgModule } from '@angular/core';


import {

  NgbCollapseModule,

  NgbDatepickerModule,

  NgbDropdownModule,
  NgbModalModule,

 
  

} from '@ng-bootstrap/ng-bootstrap';

// import { NgxValidateCoreModule } from '@ngx-validate/core';

import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';

import { PageModule } from '@abp/ng.components/page';

import { CommonModule } from '@angular/common';
import { CalenderRoutingModule } from './calender-routing.module';

//import { CommonModule } from '@angular/common';





@NgModule({

  declarations: [],

  imports: [

   CalenderRoutingModule,

    CoreModule,

    ThemeSharedModule,

    CommercialUiModule,

    // NgxValidateCoreModule,

    NgbCollapseModule,
     CommonModule,
     PageModule,

  ],

})

export class CalenderModule {}