using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_Employees_pmmson
{
    interface IView
    {
        IEnumerable EmployeesDtGrid { get; set; }
        IEnumerable DepartmentsComBox { get; set; }
        string TitleWindow { get; set; }
        object DepartmentSelectItem { get; }
        object EmployeeSelectItem { get; }

    }
}
