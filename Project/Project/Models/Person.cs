using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project.Models
{
    public class Person
    {
       [Key]
        public int ID { get; set; }
        public int IdNumber { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
            