﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_1.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        //public static explicit operator Department(ValueTask<Department> v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
