import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { EmployeeModel } from '../components/models/employee.model';
import { ResponseModel } from '../components/models/response.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private baseUrl = 'https://localhost:7047/api';

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<EmployeeModel[]> {
    const url = `${this.baseUrl}/employees`;
    return this.http.get<ResponseModel<EmployeeModel[]>>(url).pipe(
      map(response => response.result)
    );    
  }

  getEmployeeById(id: number): Observable<EmployeeModel> {
    const url = `${this.baseUrl}/employees/${id}`;
    return this.http.get<ResponseModel<EmployeeModel>>(url).pipe(
      map(response => response.result)
    );
  }
}
