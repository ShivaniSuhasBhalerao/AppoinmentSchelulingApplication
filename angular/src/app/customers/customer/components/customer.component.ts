import { ABP, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter, NgbDatepickerConfig } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetCustomersInput, CustomerDto } from '../../../proxy/customers/models';
import { CustomerService } from '../../../proxy/customers/customer.service';




@Component({
  selector: 'app-customer',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './customer.component.html',
  styles: [],
})
export class CustomerComponent implements OnInit {
 //currentdate=new Date();

 

  data: PagedResultDto<CustomerDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetCustomersInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  selected?: CustomerDto;

  btnstate: boolean = false;


  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: CustomerService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder,
    private _apiservice: CustomerService, 
    private config: NgbDatepickerConfig
  ) {
    const current = new Date();
    config.minDate = {
      year: current.getFullYear(), month:
        current.getMonth() + 1, day: current.getDate()
    };
    config.outsideDays = 'hidden';

  }


  ngOnInit() {


    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<CustomerDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }


  clearFilters() {
    this.filters = {} as GetCustomersInput;
  }

  buildForm() {
    const { name, address, mobileNumber, appointmentDate, verificationStatus } =
      this.selected || {};

    this.form = this.fb.group({
      name: [name ?? null, [Validators.required]],
      address: [address ?? null, []],
      mobileNumber: [mobileNumber ?? null, [Validators.required]],
      appointmentDate: [appointmentDate ? appointmentDate : null, []],
      verificationStatus: [verificationStatus ?? false, []],
    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;

    const request = this.selected
      ? this.service.update(this.selected.id, this.form.value)
      : this.service.create(this.form.value);

    this.isModalBusy = true;
console.log(this.form.value)
    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm())
      )
      .subscribe(this.list.get)
    alert("Your Appointment is confirmed")

console.log(this.form.value)
  }

  customers!: any[]
  getUpcomingappointment() {
    this._apiservice.getUpcomingAppointments().subscribe({
      next: (data) => {

        console.log(data)

        this.customers = data.items
      }
    }


    )
    console.log(this.customers)
  }

  deleteappointments!: any[]
  getDeletedData() {
    this._apiservice.DeletedAppoinments().subscribe({
      next: (data) => {

        console.log(data)

        this.deleteappointments = data.items
      }
    }


    )
    console.log(this.customers)
  }





  create() {
    this.selected = undefined;
    this.showForm();

  }

  update(record: CustomerDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: CustomerDto) {
    this.confirmation
      .warn('::DeleteConfirmationMessage', '::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.service.delete(record.id))
      )
      .subscribe(this.list.get);
  }



}
