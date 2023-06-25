import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Employee } from "src/app/models/employee";

@Injectable({providedIn: 'root'})
export class EmployeeService {
  constructor(private httpClient: HttpClient) {}

  getEmployeeById(employeeId: number): Observable<Employee> {
    return this.httpClient.get<Employee>(`employee/${employeeId}`);
  }
}
