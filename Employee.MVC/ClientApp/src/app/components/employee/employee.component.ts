import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/Services/employee.service';
import { EmployeeModel } from '../models/employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employeeId!: number;
  employees!: EmployeeModel[]; // Aquí debes definir la interfaz o tipo correspondiente para los empleados

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees() {
    this.employeeService.getEmployees().subscribe(employees => {
      this.employees = employees;
    });
  }

  searchEmployee() {
    debugger
    if (this.employeeId) {
      this.employeeService.getEmployeeById(this.employeeId).subscribe(employee => {
        debugger
        this.employees = [employee];
      });
    } else {
      this.getEmployees();
    }
  }
}
