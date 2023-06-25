import { HttpErrorResponse } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, forkJoin, throwError } from 'rxjs';
import { Employee } from 'src/app/models/employee';
import { EmployeeAddress } from 'src/app/models/employee-address';
import { EmployeeAddressService } from 'src/app/services/employees/employee-address.service';
import { EmployeeService } from 'src/app/services/employees/employee.service';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {
  @Input() employeeId?: number;

  employee?: Employee;
  employeeAddress?: EmployeeAddress;

  constructor(
    private employeeService: EmployeeService,
    private employeeAddressService: EmployeeAddressService,
    private router: Router
  ) { }

  ngOnInit(): void {
    // don't think this should be possible? but better safe than sorry
    if (!this.employeeId) {
      this.redirectToNotFound();
    }

    forkJoin([
      this.employeeService.getEmployeeById(this.employeeId as number),
      this.employeeAddressService.getEmployeeAddressByEmployeeId(this.employeeId as number)
    ])
      .pipe(
        catchError((error: HttpErrorResponse) => {
          // am making a bit of an assumption here that an employee should always have an address
          if (error.status == 404) {
            this.redirectToNotFound();
          }

          return throwError(() => error);
        })
      )
      .subscribe(([employee, employeeAddress]: [Employee, EmployeeAddress]) => {
        this.employee = employee;
        this.employeeAddress = employeeAddress;
      });
  }

  redirectToNotFound(): void {
    this.router.navigate(['404']);
  }
}
