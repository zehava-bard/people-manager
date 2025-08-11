using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
namespace Project.DAL
{
    public class PersonDal : IPersonDal
    {
        private readonly Context Context;
        private readonly IConfiguration _Config;

        public PersonDal(Context Context, IConfiguration config)
        {
            this.Context = Context;
            _Config = config;
        }
        public async Task<IEnumerable<Person>> GetAllPerson()
        {
            return await Context.Person.ToListAsync();
        }
        public void AddPerson(Person person)
        {
            Context.Person.Add(person);
            Context.SaveChanges();
            Task.Delay(100);
        }
        public bool PersonExists(int personIDNumber)
        {
            return Context.Person.Any(p => p.IdNumber == personIDNumber);
        }
        public void DeletePerson(int id)
        {
            var person = Context.Person.FirstOrDefault(p => p.IdNumber == id);
            if (person == null)
            {
                throw new Exception($"person {id} not found");
            }
            Context.Person.Remove(person);
            Context.SaveChanges();
        }



    }





}
