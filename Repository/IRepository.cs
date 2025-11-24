using Microsoft.CodeAnalysis.CSharp.Syntax;
using Second_API_project.Model;

namespace Second_API_project.Repository
{
    public interface IRepository<Genarl> where Genarl : class
    {
        public List<Genarl> GetAll();

        public Genarl GetById(int id);

        public void DeleteById(int id);

        public void update(int id);


      

    }
}
