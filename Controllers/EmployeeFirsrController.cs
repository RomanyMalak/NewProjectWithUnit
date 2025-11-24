using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Second_API_project.Dbcontext;
using Second_API_project.DTO;
using Second_API_project.Model;
using Second_API_project.Repository;
using Second_API_project.Uint_of_Ropository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Second_API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFirsrController : ControllerBase

        



    {
        private readonly App_context context;
        //private readonly IRepository<Employee> repositoryEployee;
        //private readonly IRepository<Department> _repositorydepartment;
        private readonly IUnitofwork _unit;
        public EmployeeFirsrController(App_context db,/* IRepository<Employee> repositoryEployee,*/
            //IRepository<Department> repositorydepartment,
            IUnitofwork unit)
        {
            context = db;
          //  this.repositoryEployee = repositoryEployee;
            //this._repositorydepartment = repositorydepartment;
            this._unit = unit;
        }



        // GET: api/<EmployeeFirsrController>
        [HttpGet("NewUnit")]
        public ActionResult<List<Employee>> Get()
        {


            return _unit.EmployeeRepository.GetAll();
        }

        [HttpGet("Departmentqqqqqqqqqq/klklds")]
        public ActionResult<List<Department>> Gett()
        {


            return  _unit.DepartmentRepository
                .GetAll();
        }

        [HttpGet("emp&department")]
        public async Task<List<DTO_object>> Getti()
        {
           
            List<Employee> emplist= await context.Employees.Include(e=>e.Department).ToListAsync();

            List<DTO_object> Dtolist=new List<DTO_object>();
            foreach (var emp in emplist)
            {
                DTO_object dTO_Object=new DTO_object();
                dTO_Object.Id=emp.Id;
                dTO_Object.Name = emp.Name;
                dTO_Object.DepartmentId=emp.DepartmentId;
                
                //dTO_Object.Phone=emp.Phone;
                //dTO_Object.Email=emp.Email;

                Dtolist.Add(dTO_Object);
            }



            return Dtolist;
        }

        // GET api/<EmployeeFirsrController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var d = _unit.EmployeeRepository.GetById(id);
            if (d==null)
            {
                return NotFound("not found");
            }
            
            return Ok(d);
        }

        // POST api/<EmployeeFirsrController>
        [HttpPost]
        public void Post([FromBody] string value)
        {



        }

        // PUT api/<EmployeeFirsrController>/5
        [HttpPut("{id}")]

       
        public ActionResult<Employee> update (int id, DTO_object obj)
        {
           var emp= _unit.EmployeeRepository.GetById(id);
            if (emp == null)
            {
                return NotFound ($"the id {id} not found");
            }


            Employee employee = new Employee
            {
                Name=obj.Name,
                Password=obj.Password,
            };
            _unit.EmployeeRepository.update(employee);

            _unit.Save();

            return Ok();
        }
        
        // DELETE api/<EmployeeFirsrController>/5
        [HttpDelete("{id}")]
        public ActionResult<Employee> Delete(int id)
        {
         _unit.EmployeeRepository.DeleteById(id);

            _unit.Save();
            return Ok();
        }
    }
}
