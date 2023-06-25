import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { EmployeeAddress } from "src/app/models/employee-address";

@Injectable({providedIn: 'root'})
export class EmployeeAddressService {
  constructor(private httpClient: HttpClient) {}

  getEmployeeAddressByEmployeeId(employeeId: number): Observable<EmployeeAddress> {
    return this.httpClient.get<EmployeeAddress>(`employee/${employeeId}/address`);
  }
}
