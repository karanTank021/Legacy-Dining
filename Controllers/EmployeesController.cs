using Employee_Management_System.Models;
using Employee_Management_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var employees = context.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeesDTO eDTO)
        {
            if (eDTO == null)
            {
                ModelState.AddModelError("EmployeeName", "Employee Name is Required");
            }

            if (!ModelState.IsValid)
            {
                return View(eDTO);
            }

            var employee = new Employees
            {
                EmployeeName = eDTO.EmployeeName,
                EmployeeEmail = eDTO.EmployeeEmail,
                EmployeeNumber = eDTO.EmployeeNumber,
                EmployeeDepartment = eDTO.EmployeeDepartment
            };
            
            context.Employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }

        public IActionResult Edit(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound(); // Better than redirecting to Index
            }

            var employeeDTO = new EmployeesDTO()
            {
                EmployeeName = employee.EmployeeName,
                EmployeeEmail = employee.EmployeeEmail,
                EmployeeNumber = employee.EmployeeNumber,
                EmployeeDepartment = employee.EmployeeDepartment
            };

            return View(employeeDTO); // Pass EmployeeDTO to the view
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeesDTO eDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(eDTO);
            }

            var existingEmployee = context.Employees.Find(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            // Update properties
            existingEmployee.EmployeeName = eDTO.EmployeeName;
            existingEmployee.EmployeeEmail = eDTO.EmployeeEmail;
            existingEmployee.EmployeeNumber = eDTO.EmployeeNumber;
            existingEmployee.EmployeeDepartment = eDTO.EmployeeDepartment;

            context.Update(existingEmployee);  // Explicitly mark entity as updated
            context.SaveChanges();  // Save changes in the database

            TempData["SuccessMessage"] = "Employee details updated successfully!";

            return RedirectToAction("Index", "Employees");
        }

        public IActionResult Delete(int id)
        {
            var employees = context.Employees.Find(id);

            if(employees == null) 
            { 
                return NotFound(); 
            }

            context.Employees.Remove(employees);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Employee deleted successfully!";

            return RedirectToAction("Index", "Employees");
        }
    }
}
