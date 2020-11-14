using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class Room
    {
        private string _fullName;
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Build { get; set; }
        public int Office { get; set; }
        [NotMapped]
        public string FullAddress 
        {
            get 
            { 
                if(_fullName == null)
                {
                    return Country + ", " + City + ", " + Street + " " + Build + " кв." + Office.ToString();
                }
                return _fullName;
            }
            set { _fullName = value; }
        }
        public List<Phone> Phones { get; set; }
    }
}
