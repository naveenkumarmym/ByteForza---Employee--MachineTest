# Employee Management App

This is an **Employee Management** app made with **Angular 17** and **.NET Core** backend.  
You can **add, edit, delete, and view employees**. The app also checks if an email is already used.

---

## Features

- Add new employee  
- Edit existing employee   
- Show all employees in a list  
- Check if email already exists  
- Form validation (required fields, max length, valid email)  
- Active/inactive employee toggle  

---

## Technology Used

- Angular 17  
- TypeScript  
- Bootstrap 5  
- .NET Core Web API  
- SQL Server  
- Reactive Forms  

---


## Setup Instructions

1. **Clone the project

       git clone <repository-url>
       cd employee-app
       
2. **Install Dependies

       npm install
3. **Run Angular app

       ng serve
   
   **Open http://localhost:4200in your browser.

4. **Backend API
   
    Set Base URL in employee.service.ts if needed.
   
---

## How to Use

1.Go to Add Employee to add new employee.

2.Go to Employee List to see all employees.

3.Click Edit to update employee details.

4.If email is already used, it will show a warning.

5.Active status can be turned on/off with checkbox.

---

## Notes

1.Submit button is disabled if form is invalid or email exists.

2.Shows error messages if input is wrong.

3.Shows alert after success (create or update).
       





