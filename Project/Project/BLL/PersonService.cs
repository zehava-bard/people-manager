using AutoMapper;
using Project.DAL;
using Project.Models;
using System;
using System.Text.RegularExpressions;
namespace Project.BLL
{
    public class PersonService : IPersonService
    {
        private readonly IPersonDal personDal;
        private readonly IMapper _mapper;
        public PersonService(IPersonDal personDal, IMapper mapper)
        {
            this.personDal = personDal;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Person>> GetAllPerson()
        {
            var res = await personDal.GetAllPerson();
            return res;
        }

        public void AddPerson(Person person)
        {
            if (personDal.PersonExists(person.IdNumber))
            {
                throw new InvalidOperationException("exists person");
            }
            if (IsValidPerson(person)) 
            {
                throw new ArgumentException("Invalid Person Details");
            }
            else
            {
                personDal.AddPerson(person);
            }
        }
        public bool IsValidPerson(Person person)
        {
            if (person == null)
            {
                return false;
            }
            if (person.Name == null)
            {
                return false;
            }
            if (!IsValidIsraeliId(person.IdNumber))
            {
                return false;
            }
            if (!IsValidPhone(person.Phone))
            {
                return false;
            }
            if (!string.IsNullOrWhiteSpace(person.Email) && !IsValidEmail(person.Email))
                return false;
            return true;

        }

        private bool IsValidIsraeliId(int id)
        {
            string idStr = id.ToString().PadLeft(9, '0');
            if (string.IsNullOrWhiteSpace(idStr)) return false;
            idStr = idStr.Trim();
            if (!int.TryParse(idStr, out _)) return false;
            idStr = idStr.PadLeft(9, '0');
            if (idStr.Length!=9) return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = int.Parse(idStr[i].ToString());
                int step = digit * ((i % 2) + 1);
                sum += step > 9 ? step - 9 : step;
            }
            return sum % 10 == 0;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        static bool IsValidPhone(string phone)
        {
            string pattern = @"^(02\d{7}|052\d{7})$";
            return Regex.IsMatch(phone, pattern);
        }

        public void DeletePerson(int id)
        {
            personDal.DeletePerson(id);

        }

    }
}
