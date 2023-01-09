import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const CUSTOMERS_CUSTOMER_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/customers',
        iconClass: 'fas fa-file-alt',
        name: '::Menu:Customers',
        layout: eLayoutType.application,
        requiredPolicy: 'AppoinmentSchelulingProject.Customers',
      },
    ]);
  };
}
