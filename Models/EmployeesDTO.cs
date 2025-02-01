using System.ComponentModel.DataAnnotations;

public class EmployeesDTO
{
    // Employee Name - Required field
    [Required(ErrorMessage = "Employee Name is required.")]
    [StringLength(50, ErrorMessage = "Employee Name cannot exceed 50 characters.")]
    public string EmployeeName { get; set; }

    // Employee Email - Required with Email validation
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email format. Please enter a valid email.")]
    public string EmployeeEmail { get; set; }

    // Employee Phone Number - Required with proper phone validation
    [Required(ErrorMessage = "Phone Number is required.")]
    [Phone(ErrorMessage = "Invalid Phone Number format.")]
    [StringLength(10, ErrorMessage = "Phone Number cannot exceed 10 digits.")]
    public string EmployeeNumber { get; set; }

    // Employee Department - Required to avoid empty submissions
    [Required(ErrorMessage = "Department is required.")]
    [StringLength(50, ErrorMessage = "Department Name cannot exceed 50 characters.")]
    public string EmployeeDepartment { get; set; }
}
