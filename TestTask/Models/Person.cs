using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class Person
    {
        private string  _fullName;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName {
            get 
            { 
                if (_fullName == null)
                {
                    return (LastName + " " + FirstName + " " + MiddleName);
                }
                return _fullName;  
            }
            set { _fullName = value; }
        }
        public List<Phone> Phones { get; set; }
    }
}
