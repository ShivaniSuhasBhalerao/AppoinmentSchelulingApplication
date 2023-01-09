import { FullAuditedEntityDto, ListResultDto, RestService } from "@abp/ng.core";
import { Injectable } from "@angular/core";
export class Appointment {
  text: string;

  startDate: Date

  endDate: Date;

  allDay?: boolean;
}
const appointments: Appointment[] = [
  {
    
    text: '',
    startDate: new Date(''),
      endDate: new Date(''),
}, 
];

export interface GetCustomersInput  {
    filterText?: string;
    name?: string;
    address?: string;
    mobileNumber?: string;
    appointmentDateMin?: string;
    appointmentDateMax?: string;
    verificationStatus?: boolean;
  }
  export interface CustomerDto extends FullAuditedEntityDto<string> {
    name: string;
    text:string;
    address?: string;
    mobileNumber: string;
    appointmentDate?: Date;
    verificationStatus?: boolean;
  }
  
 

@Injectable({
     providedIn: 'root'
})
export class CalenderService {
  
  apiName = 'Default';
  
  getcustincalender= () => 
{
  return this.restService.request<any, ListResultDto<CustomerDto>>({ 
 
  method: 'GET', 
 
 url: '/api/app/customers/Calender', 
 }, 
 { apiName: this.apiName }); 

}
  constructor(private restService: RestService) {}



getAppointments(): Appointment[] {
 return appointments;
    }
  }
