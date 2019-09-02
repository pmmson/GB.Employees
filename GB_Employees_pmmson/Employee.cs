using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Employees_pmmson
{
    class Employee
    {
        public Employee(int id, string name, int age, int idDepart)
        {
            ID = id;
            Name = name;
            Age = age;
            IdDepart = idDepart;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int IdDepart { get; set; }
    }
}
