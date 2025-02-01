using System.ComponentModel.DataAnnotations;

namespace Employee_Management_System.Models
{
    public class Employees
    {
        // Primary Key for Employees table
        [Key]
        public int EmployeeID { get; set; }

        // Employee Name - Required with max length constraint
        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(50, ErrorMessage = "Employee Name cannot exceed 50 characters.")]
        public string EmployeeName { get; set; }

        // Employee Email - Required with proper email format validation
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email format.")]
        public string EmployeeEmail { get; set; }

        // Employee Phone Number - Required with phone validation
        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone(ErrorMessage = "Invalid Phone Number format.")]
        [StringLength(15, ErrorMessage = "Phone Number cannot exceed 15 digits.")]
        public string EmployeeNumber { get; set; }

        // Employee Department - Required to avoid blank values
        [Required(ErrorMessage = "Department is required.")]
        [StringLength(50, ErrorMessage = "Department Name cannot exceed 50 characters.")]
        public string EmployeeDepartment { get; set; }
    }
}
