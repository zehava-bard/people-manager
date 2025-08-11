using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.DAL
{
    public interface IPersonDal
    {
        //public Task<Person> CheckBuyer(PersonDTO2 buyer);      
        public Task<IEnumerable<Person>> GetAllPerson();
        public void AddPerson(Person person);
        public void DeletePerson(int id);
        public bool PersonExists(int personIDNumber);


    }
}
