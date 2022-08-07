using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFirstApproach.Models
{
    public class EmpModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public Nullable<int> Salary { get; set; }

    }  
}