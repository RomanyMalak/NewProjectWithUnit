using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Second_API_project.Dbcontext;
using Second_API_project.Model;

namespace Second_API_project.Repository

{
    public class MainRepository<Genral>:IRepository<Genral> where Genral : class
    {
        App_context repository;     
        public MainRepository(App_context repository)
        {
            this.repository = repository;
        }

        public List<Genral> GetAll()
        {

            return repository.Set<Genral>().ToList();
        }

        public Genral GetById(int id)
        {
          var emp=  repository.Set<Genral>().Find(id);
           
                return emp;
       
        }
        public void DeleteById(int id)
        {
            var emp = repository.Set<Genral>().Find(id);
            if (emp != null)
            {
                repository.Remove(emp);
            }
         
              
        }
        public Genral update(int id,Genral t)
        {
            var emp = repository.Set<Genral>().Find(id);
            if (emp != null)
            {
                repository.Entry(emp).State = EntityState.Modified;   

            }

            return emp;
        }


      


       

        
    }
}
