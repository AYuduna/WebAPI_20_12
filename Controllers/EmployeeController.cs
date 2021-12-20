using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebAPI_1.Models;
using WebAPI_1.Data;

using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace WebAPI_1.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DepContext _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IConfiguration configuration,IWebHostEnvironment env, DepContext context)
        {
            _configuration = configuration;
            _context = context;
            _env = env;
        }


        [HttpGet]
        //public async Task<IEnumerable<EmployeeData>> Get()
        public async Task<IEnumerable<Employee>> Get()
        {
            
            return await _context.Employees.ToListAsync();


        }

        [HttpPut]
        public async Task<JsonResult> Put(Employee empdata)

        {
            _context.Entry(empdata).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new JsonResult("Updated Successfully");
        }
        
        [HttpPost]
        public async Task<JsonResult> Post(Employee empdata)

        {
            if (empdata == null) return new JsonResult("Not Added");
            _context.Employees.Add(empdata);
            await _context.SaveChangesAsync();
            return new JsonResult("Added Successfully");
        }

        [HttpDelete("{id}")]
        public async  Task<JsonResult> Delete(int id)

        {
            var emp = _context.Employees.FindAsync(id);
            if (emp.Result == null)
            {
                return new JsonResult("Not Id for delete");
            }

            _context.Employees.Remove((Employee)emp.Result);
            await  _context.SaveChangesAsync();
            return new JsonResult("Deleted Successfully");
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

    }


}

