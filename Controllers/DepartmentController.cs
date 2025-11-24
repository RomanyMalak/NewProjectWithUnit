using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Second_API_project.Dbcontext;
using Second_API_project.DTO;
using Second_API_project.Model;
using Second_API_project.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Second_API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _repositorydepartment;

        public DepartmentController(App_context _Context,IRepository<Department> repository)
        {
            Context = _Context;
            _repositorydepartment = repository;
        }

        App_context Context;
        // GET: api/<DepartmentController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}



        [HttpGet("myown")]
        public async Task<ActionResult<List<Dto_For_department>>> Gett()
        {

            List<Department> deplist = await Context.Departments.Include(op => op.Employe).ToListAsync();

            List<Dto_For_department> dtolist = new List<Dto_For_department>();

            foreach (var department in deplist)
            {
                Dto_For_department obj = new Dto_For_department();

                obj.Id = department.Id;
                obj.Name = department.Name;
                obj.MemberofEmployee = department.Employe.Count();
                dtolist.Add(obj);
            }
            return Ok(dtolist);
        }
        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dto_For_department>> Gett(int id)
        {

           var fiund = await Context.Departments.Include(op => op.Employe).FirstOrDefaultAsync(o=>o.Id==id);

            Dto_For_department obj = new Dto_For_department

            {
                        Id =       fiund.Id,
                        Name =     fiund.Name,
                MemberofEmployee = fiund.Employe.Count()

            };

            return (obj);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public ActionResult<Department> Gett(Dto_For_department opt)
        
        {
            

            Department dep = new Department
            {
                Name = opt.Name,
                Id = opt.Id,

            };
            Context.Add(dep);
            Context.SaveChanges();
            return Ok(dep);
            
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Department>> Delete(int id)
        {
            var deleteitem=await Context.Departments.FirstOrDefaultAsync(r=>r.Id==id);

            if (deleteitem==null)
            {
                return NotFound($"the id {id} not exsist ");
            }

           Context.Departments.Remove(deleteitem);
            Context.SaveChanges();
            return Ok();
        }
    }
}
