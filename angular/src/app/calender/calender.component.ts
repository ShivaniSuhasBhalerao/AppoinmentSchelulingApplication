import { Component, NgModule, OnInit } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { DxSchedulerModule } from 'devextreme-angular';
import { DatePipe } from '@angular/common';

import { Appointment, CalenderService, CustomerDto } from './calender.service';
import { getRandomBackgroundColor } from '@abp/ng.components/chart.js';
import { style } from '@angular/animations';

@Component({
  selector: 'app-calender',
  templateUrl: './calender.component.html',
  styleUrls: ['./calender.component.scss'],
  providers: [CalenderService],
})
export class CalenderComponent {
  time = {hour: 13, minute: 30};
  appointmentsData: Appointment[] = [];
  appointmentsData1: CustomerDto;

  currentDate: Date = new Date(2022, 9, 27);

  constructor(public readonly service: CalenderService,
    private _apiservice: CalenderService,) {
    //this.appointmentsData1.name="something";
    // this.appointmentsData = service.getAppointments();
    this.getCustomerinCalender();
    //console.log("const",this.appointmentsData1);


  }
  // ngOnInit(): void {
  //  this.getCustomerinCalender()
  // }
  customers!: any[]

  getCustomerinCalender() {

    this._apiservice.getcustincalender().subscribe({
      next: (data) => {
        console.log(data)
        if (data.items.length > 0) {
          data.items.forEach(item => {
            let event = new Appointment();
            event.text = item.name;
            event.startDate = new Date(item.appointmentDate);
            event.endDate = new Date(new Date(item.appointmentDate).setMinutes(new Date(item.appointmentDate).getMinutes() + 30));
            this.appointmentsData.push(event);
          });
          this.appointmentsData = [...this.appointmentsData];
          console.log(this.appointmentsData);

        }
        // console.log(data)

        // this.appointmentsData1 = data.items[0];
        // this.appointmentsData1.appointmentDate = new Date('2022-09-27T21:00:00.000Z')
        // console.log("const", this.appointmentsData1);
      }
    }
    )
    //console.log(this.customers ,"customer");
  }

}






function getUpcomingappointment() {
  throw new Error('Function not implemented.');
}

