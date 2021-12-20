using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName {get; set; }
        //public string Department { get; set; }
        
        public int DepartmentID { get; set; }

        public string DateOfJoining { get; set; }

        public string  PhotoFileName { get; set; }

        public Department Department { get; set; }

        //public static explicit operator Employee(ValueTask<Employee> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
