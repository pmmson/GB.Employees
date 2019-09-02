using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Employees_pmmson
{
    class Department
    {
        public Department(int idDepart, string nameDepart)
        {
            NameDepart = nameDepart;
            IdDepart = idDepart;
        }

        public string NameDepart { get; set; }
        public int IdDepart { get; set; }
    }
}
