﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Employees_pmmson
{
    class Main : INotifyPropertyChanged
    {
        ObservableCollection<Employee> employees;
        ObservableCollection<Department> departments;
        int idDepart;
        string nameDepart;
        int idEmpl;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Employee> Employees { get => employees; set => employees = value; }
        public ObservableCollection<Department> Departments { get => departments; set => departments = value; }

        public int CountEmpl { get => employees.Count(); }
        public int CountDepart { get => departments.Count(); }
        public string GetNameDepart { get => GetNameDepartById(idDepart); }


        public void LoadDepartment()
        {
            departments = new ObservableCollection<Department>();

            for (int i = 0; i < 100; i++)
            {
                departments.Add(new Department(i + 1, "D." + $"{ i + 1 }".PadLeft(3, '0')));
            }
        }

        public void LoadEmployee()
        {
            Random r = new Random();
            employees = new ObservableCollection<Employee>();

            for (int i = 0; i < 1000; i++)
            {
                employees.Add(new Employee(i + 1, "FIO." + $"{i + 1}".PadLeft(4, '0'), r.Next(21, 60), r.Next(1, 101)));
            }
        }

        public void AddDep(string nameDepart)
        {
            if (nameDepart != "")
            {
                idDepart = departments[departments.Count - 1].IdDepart + 1;
                departments.Add(new Department(idDepart, nameDepart));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CountDepart)));
        }

        public void DelDep(string nameDepart)
        {
            for (int i = departments.Count - 1; i >= 0; i--)
            {
                // TODO: проблема если удаляем все департаменты с таким же именем!
                if (departments[i].NameDepart == nameDepart)
                {
                    DelEmpl(departments[i].IdDepart);
                    departments.Remove(departments[i]);
                }
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CountDepart)));
        }

        public void DelEmpl(int idDepart)
        {
            for (int i = employees.Count - 1; i >= 0; i--)
            {
                if (employees[i].IdDepart == idDepart) employees.Remove(employees[i]);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CountEmpl)));
        }

        public void DelEmpl(string name)
        {
            for (int i = employees.Count - 1; i >= 0; i--)
            {
                if (employees[i].Name == name) employees.Remove(employees[i]);
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CountEmpl)));
        }

        public void AddEmpl(string name, string age, string nameDepart)
        {
            idEmpl = employees[employees.Count - 1].ID + 1;

            for (int i = departments.Count - 1; i >= 0; i--)
            {

                if (departments[i].NameDepart != nameDepart)
                {
                    if (i == 0)
                    {
                        AddDep(nameDepart);
                    }
                    continue;
                }

                idDepart = departments[i].IdDepart;
            }

            employees.Add(new Employee(idEmpl, name, Int32.Parse(age), idDepart));

            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Employees)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CountEmpl)));
        }

        public string GetNameDepartById(int idDepart)
        {
            for (int i = departments.Count - 1; i >= 0; i--)
            {
                if (departments[i].IdDepart == idDepart)
                {
                    nameDepart = departments[i].NameDepart;
                }
            }

            return nameDepart;
        }
    }
}
