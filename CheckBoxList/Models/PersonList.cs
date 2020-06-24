using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckBoxList.Models
{
    public class PersonList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }
    }
}