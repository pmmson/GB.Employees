using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GB_Employees_pmmson
{
    /// <summary>
    /// Логика взаимодействия для EditEmpl.xaml
    /// </summary>
    public partial class EditEmpl : Window
    {
        public EditEmpl(MainWindow mainWin)
        {
            InitializeComponent();

            Depart.ItemsSource = mainWin.DepartmentsComBox;

            FIO.Text = (mainWin.EmployeeSelectItem as Employee)?.Name;
            Age.Text = (mainWin.EmployeeSelectItem as Employee)?.Age.ToString();
            Depart.SelectedItem = mainWin.DepartmentSelectItem;

            btnOK.Click += delegate
            {
                this.DialogResult = true;
            };
        }
    }
}
