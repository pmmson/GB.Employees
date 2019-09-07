using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Employees_pmmson
{
    class Model
    {

        ObservableCollection<Employee> employees;
        ObservableCollection<Department> departments;

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
            }
        }

        public ObservableCollection<Department> Departments
        {
            get => departments;
            set
            {
                departments = value;
            }
        }

        public void Load()
        {
            employees = new ObservableCollection<Employee>();
            departments = new ObservableCollection<Department>();

            Random r = new Random();

            for (int i = 0; i < 100; i++)
            {
                departments.Add(new Department(i + 1, "D." + $"{ i + 1 }".PadLeft(3, '0')));
            }

            for (int i = 0; i < 1000; i++)
            {
                employees.Add(new Employee(i + 1, "FIO." + $"{i + 1}".PadLeft(4, '0'), r.Next(21, 60), r.Next(1, 101)));
            }
        }

        public int CountEmpl
        {
            get => employees.Count();
        }

        public int CountDepart
        {
            get => departments.Count();
        }

        public void DelDep(int idDepart)
        {
            for (int i = departments.Count - 1; i >= 0; i--)
            {
                if (departments[i].IdDepart == idDepart)
                {
                    DelEmplByIdDepart(departments[i].IdDepart);
                    departments.Remove(departments[i]);
                }
            }
        }

        public void DelEmplByIdDepart(int idDepart)
        {
            for (int i = Employees.Count - 1; i >= 0; i--)
            {
                if (Employees[i].IdDepart == idDepart) Employees.Remove(Employees[i]);
            }
        }

        public void DelEmplById(int id)
        {
            for (int i = Employees.Count - 1; i >= 0; i--)
            {
                if (Employees[i].ID == id) Employees.Remove(Employees[i]);
            }
        }

        public void AddDep(string nameDepart)
        {
            if (nameDepart != "")
            {
                int idDepart = departments[departments.Count - 1].IdDepart + 1;
                departments.Add(new Department(idDepart, nameDepart));
            }
        }

        public void AddEmpl(string name, string age, int idDepart)
        {
            if (name != "" && age != "")
            {
                int idEmpl = employees[employees.Count - 1].ID + 1;
                Employees.Add(new Employee(idEmpl, name, Int32.Parse(age), idDepart));
            }
        }

        public void EditDep(string oldNameDep, string newNameDep)
        {
            for (int i = departments.Count - 1; i >= 0; i--)
            {
                if (departments[i].NameDepart == oldNameDep)
                {
                    departments[i].NameDepart = newNameDep;
                }
            }
        }

        public void EditEmpl(int id, string newName, string newAge, int idDepart)
        {
            for(int i = employees.Count - 1; i > 0; i--)
            {
                if(employees[i].ID == id)
                {
                    employees[i].Name = newName;
                    employees[i].Age = Int32.Parse(newAge);
                    employees[i].IdDepart = idDepart;
                }
            }
        }
    }
}
