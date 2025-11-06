import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from '../../Models/employee.model';
import { EmployeeService } from '../../Service/employee.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {

  employeeForm!: FormGroup;
  emailExists: boolean = false;
  isEditMode: boolean = false;
  editEmployeeId?: number;

  constructor(
    private fb: FormBuilder,
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.employeeForm = this.fb.group({
      employeeId: [0],
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
      dateOfBirth: ['', Validators.required],
      isActive: [true],
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.editEmployeeId = +id;
      this.loadEmployee(+id);
    }

    this.employeeForm.get('email')?.valueChanges.subscribe(email => {
      if (email) {
        const currentId = this.isEditMode ? this.editEmployeeId ?? 0 : 0;
        this.checkEmailExists(email, currentId);
      }
    });
  }

  loadEmployee(id: number): void {
    this.employeeService.getEmployeeById(id).subscribe({
      next: (res) => {
        if (res && res.data) {
          this.employeeForm.patchValue(res.data);
        }
      },
      error: (err) => console.error('Error loading employee:', err)
    });
  }

  checkEmailExists(email: string, id: number = 0): void {
    if (!email) return;

    this.employeeService.checkEmailExists(email, id).subscribe({
      next: (res: any) => {
        this.emailExists = res.data === true || res.data === 'true';
      },
      error: (err) => {
        console.error('Email check failed:', err);
        this.emailExists = false;
      }
    });
  }

  onSubmit(): void {
    if (this.employeeForm.invalid || this.emailExists) {
      alert(this.emailExists ? 'Email already exists!' : 'Please fill all required fields.');
      return;
    }

    const employee: Employee = this.employeeForm.value;

    if (this.isEditMode && this.editEmployeeId) {
      this.employeeService.updateEmployee(employee).subscribe({
        next: () => {
          alert('Employee updated successfully!');
          this.router.navigate(['/employee-list']);
        },
        error: (err) => console.error('Error updating employee:', err)
      });
    } else {
      this.employeeService.addEmployee(employee).subscribe({
        next: () => {
          alert('Employee created successfully!');
          this.router.navigate(['/employee-list']);
        },
        error: (err) => console.error('Error creating employee:', err)
      });
    }
  }
}
