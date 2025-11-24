using Second_API_project.Dbcontext;
using Second_API_project.Model;
using Second_API_project.Repository;

namespace Second_API_project.Uint_of_Ropository
{
    public class UnitRrpository:IUnitofwork
    {

        IRepository<Employee> _employeeRepository;
        IRepository<Department> _departRepositry;
        public IRepository<Employee> EmployeeRepository {
            get {

                if (_employeeRepository == null)
                {
                    _employeeRepository = new MainRepository<Employee>(_db);
                }
                
                return _employeeRepository;

            }

        }

                

        public IRepository<Department> DepartmentRepository {

            get
            {
                if (_departRepositry == null)
                {
                    _departRepositry = new MainRepository<Department>(_db);
                }

                return _departRepositry;

            }
                
        }

          App_context _db;
        
        public UnitRrpository(App_context db)
        {
            _db = db;
            //EmployeeRepository= new MainRepository<Employee>(_db);
           // EmployeeRepository = new MainRepository<Employee>(_db);
           // DepartmentRepository = new MainRepository<Department>(_db);
        }


        //public IRepository<Employee> EmployeeRepo
        //{
        //    get
        //    {
        //        if (EmployeeRepository == null)
        //        {
        //            EmployeeRepository = new MainRepository<Employee>(_db);
        //        }
        //        return EmployeeRepository;
        //    }
        //}

        //public IRepository<Department> _MainRepoemp
        //{
        //    get
        //    {
        //        if (DepartmentRepository == null)
        //        {
        //            DepartmentRepository = new MainRepository<Department>(_db);
        //        }
        //        return DepartmentRepository;
        //    }
        //}


        public void Dispose()
        {
           _db.Dispose();
        }

        public int Save()
        {
         return  _db.SaveChanges();
        }
    }
}
