import type { CustomerCreateDto, CustomerDto, CustomerUpdateDto, GetCustomersInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CustomerService {
  apiName = 'Default';
  getUpcomingAppointments = () => 

 this.restService.request<any, PagedResultDto<CustomerDto>>({ 

 method: 'GET', 

url: '/api/app/customers/Upcoming', 

 //params: { filterText: input.filterText, name: input.name, address: input.address, mobileNumber: input.mobileNumber, appointmentDateMin: input.appointmentDateMin, appointmentDateMax: input.appointmentDateMax, verificationStatus: input.verificationStatus, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount }, 

 }, 

 { apiName: this.apiName }); 

 

DeletedAppoinments = () => 

this.restService.request<any, PagedResultDto<CustomerDto>>({ 


 method: 'GET', 

 url: '/api/app/customers/Deletedata', 

//params: { filterText: input.filterText, name: input.name, address: input.address, mobileNumber: input.mobileNumber, appointmentDateMin: input.appointmentDateMin, appointmentDateMax: input.appointmentDateMax, verificationStatus: input.verificationStatus, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount }, 

}, 

{ apiName: this.apiName }); 

  create = (input: CustomerCreateDto) =>
    this.restService.request<any, CustomerDto>({
      method: 'POST',
      url: '/api/app/customers',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/customers/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CustomerDto>({
      method: 'GET',
      url: `/api/app/customers/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetCustomersInput) =>
    this.restService.request<any, PagedResultDto<CustomerDto>>({
      method: 'GET',
      url: '/api/app/customers',
      params: { filterText: input.filterText, name: input.name, address: input.address, mobileNumber: input.mobileNumber, appointmentDateMin: input.appointmentDateMin, appointmentDateMax: input.appointmentDateMax, verificationStatus: input.verificationStatus, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: CustomerUpdateDto) =>
    this.restService.request<any, CustomerDto>({
      method: 'PUT',
      url: `/api/app/customers/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
