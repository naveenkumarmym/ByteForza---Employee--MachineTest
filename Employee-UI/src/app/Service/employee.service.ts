import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../Models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private readonly baseURL = 'https://localhost:7132/api/Employee';

  constructor(private http: HttpClient) {}

getAllEmployees(): Observable<any> {
  return this.http.get(`${this.baseURL}/GetAllEmployeeList`);
}

getEmployeeById(id: number): Observable<any> {
  return this.http.get<Employee>(`${this.baseURL}/GetEmployeeById/${id}`);
}

updateEmployee(employee: Employee): Observable<any> {
  return this.http.put(`${this.baseURL}/UpdateEmployee`, employee);
}

addEmployee(employee: Employee): Observable<any> {
  return this.http.post(`${this.baseURL}/CreateEmployee`, employee);
}

checkEmailExists(email: string, id: number = 0) {
  return this.http.get<any>(`${this.baseURL}/CheckEmailExists`, {
    params: { email, id }
  });
}
}
