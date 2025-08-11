using AutoMapper;
using Project.DAL;
using Project.Models;

namespace Project.BLL
{
    public interface IPersonService
    {
    
        public Task<IEnumerable<Person>> GetAllPerson();

        public void AddPerson(Person person);

        public void DeletePerson(int id);
        public bool IsValidPerson(Person person);

    }
}
