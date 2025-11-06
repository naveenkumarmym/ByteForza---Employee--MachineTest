import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../Service/employee.service';
import { Employee } from '../../Models/employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) {}

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void {
    this.employeeService.getAllEmployees().subscribe({
      next: (res) => {
        this.employees = res.data;
      },
      error: (err) => {
        console.error('Error fetching employees:', err);
      }
    });
  }
}
