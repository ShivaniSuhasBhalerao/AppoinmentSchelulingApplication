import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CustomerCreateDto {
  name: string;
  address?: string;
  mobileNumber: string;
  appointmentDate?: string;
  verificationStatus?: boolean;
}

export interface CustomerDto extends FullAuditedEntityDto<string> {
  name: string;
  address?: string;
  mobileNumber: string;
  appointmentDate?: Date;
  verificationStatus?: boolean;
}

export interface CustomerUpdateDto {
  name: string;
  address?: string;
  mobileNumber: string;
  appointmentDate?: string;
  verificationStatus?: boolean;
}

export interface GetCustomersInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  address?: string;
  mobileNumber?: string;
  appointmentDateMin?: string;
  appointmentDateMax?: string;
  verificationStatus?: boolean;
}
