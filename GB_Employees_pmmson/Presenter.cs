using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Employees_pmmson
{
    class Presenter
    {
        IView view;
        Model model;

        public Presenter(IView view)
        {
            this.view = view;
            model = new Model();

            model.Load();

            this.view.TitleWindow = $"Сотрудник L2.6 | департаментов:{model.CountDepart} | сотрудников:{model.CountEmpl}";
            this.view.EmployeesDtGrid = model.Employees;
            this.view.DepartmentsComBox = model.Departments;
            

        }
        /// <summary>
        /// выбранный департамент
        /// </summary>
        public void DepartmentSelectionChanged()
        {
            Department selectedItem = (Department)this.view.DepartmentSelectItem;

            this.view.EmployeesDtGrid = from employee in model.Employees
                                        where employee.IdDepart == selectedItem?.IdDepart
                                        select employee;
        }
        /// <summary>
        /// удаление выбранного департамента с сотрудниками
        /// </summary>
        public void DelDep()
        {
            model.DelDep(((Department)this.view.DepartmentSelectItem).IdDepart);
            this.view.TitleWindow = $"Сотрудник L2.6 | департаментов:{model.CountDepart} | сотрудников:{model.CountEmpl}";
            // TODO: можно ли изменение название окна (кол-ва департаментов и сотрудников) реализовать не так как я сделал через копипаст строки в двух методах ?
        }
        /// <summary>
        /// удаление выбранного сотрудника
        /// </summary>
        public void DelEmpl()
        {
            model.DelEmplById(((Employee)this.view.EmployeeSelectItem).ID);
            this.view.TitleWindow = $"Сотрудник L2.6 | департаментов:{model.CountDepart} | сотрудников:{model.CountEmpl}";

            // TODO: не работает обновление при удалении сотрудника
        }
        /// <summary>
        /// добавление нового департамента
        /// </summary>
        /// <param name="depName"></param>
        public void AddDep(string depName)
        {
            model.AddDep(depName);
            this.view.TitleWindow = $"Сотрудник L2.6 | департаментов:{model.CountDepart} | сотрудников:{model.CountEmpl}";
        }
        /// <summary>
        /// добавление нового сотрудника
        /// </summary>
        /// <param name="emplName"></param>
        /// <param name="emplAge"></param>
        /// <param name="idDepart"></param>
        public void AddEmpl(string emplName, string emplAge, int idDepart)
        {
            model.AddEmpl(emplName, emplAge, idDepart);
            this.view.TitleWindow = $"Сотрудник L2.6 | департаментов:{model.CountDepart} | сотрудников:{model.CountEmpl}";
        }
        /// <summary>
        /// редактирование названия департамента
        /// </summary>
        /// <param name="oldNameDep"></param>
        /// <param name="newNameDep"></param>
        public void EditDep(string oldNameDep, string newNameDep)
        {
            model.EditDep(oldNameDep, newNameDep);
        }
        /// <summary>
        /// редактирование сотрудника департамента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        /// <param name="newAge"></param>
        /// <param name="idDepart"></param>
        public void EditEmpl(int id, string newName, string newAge, int idDepart)
        {
            model.EditEmpl(id, newName, newAge, idDepart);
        }
    }
}
