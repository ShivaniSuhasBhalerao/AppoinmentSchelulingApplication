import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
})
export class AppComponent {
  static getCurrentTraining(arg0: any, employeeID: any) {
    throw new Error('Method not implemented.');
  }
}
