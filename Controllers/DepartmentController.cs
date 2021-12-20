using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_1.Models;
using WebAPI_1.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Cors;
//using System.Web.Http;



namespace WebAPI_1.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepContext _context;

        public DepartmentController(DepContext context)
        {
            _context = context;
            //SampleData.Initialize(_context);
        }

        // GET: api/Phones
        [HttpGet]
        
       
        
        public async Task<IEnumerable<Department>> Get()
        {
            return await _context.Departments.ToListAsync();
        }

        //// GET: api/Phones/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Phone>> GetPhone(int id)
        //{
        //    var phone = await _context.Phones.FindAsync(id);

        //    if (phone == null)
        //    {
        //        return NotFound();
        //    }

        //    return phone;
        //}

        // PUT: api/Phones/5
     
        
    
        [HttpPut]
        public JsonResult Put(Department dep)
        
        {
            
            _context.Entry(dep).State = EntityState.Modified;

           
                 _context.SaveChangesAsync();


            return new JsonResult("Updated Successfully");
        }
        //[EnableCors("Cors")]
     
        // POST: Phones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
        [HttpPost]
        public async Task<JsonResult> Post(Department dep)
        
        {         
                  
             _context.Departments.Add(dep);
             await _context.SaveChangesAsync();
             return new JsonResult("Succes");
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        
        {
            var dep =  _context.Departments.FindAsync(id);
            if (dep.Result == null)
            {
                return new JsonResult("Not Id for delete");
            }

            _context.Departments.Remove((Department)dep.Result);
             await _context.SaveChangesAsync();

            return new JsonResult("Deleted Successfully");
        }

      
    }
}
