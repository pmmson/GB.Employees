using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GB_Employees_pmmson
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        Presenter p;

        public IEnumerable EmployeesDtGrid
        {
            get { return dtGrid.ItemsSource; }
            set { dtGrid.ItemsSource = value; }
        }

        public IEnumerable DepartmentsComBox
        {
            get { return listDepartments.ItemsSource; }
            set { listDepartments.ItemsSource = value; }
        }

        public string TitleWindow
        {
            get { return Title; }
            set { Title = value; }
        }

        public object EmployeeSelectItem => dtGrid.SelectedItem;

        public object DepartmentSelectItem
        {
            get { return listDepartments.SelectedItem; }
            set { listDepartments.SelectedItem = value; }
        }

        public MainWindow()
        {
            // инициализация компонентов
            InitializeComponent();

            p = new Presenter(this);

            p.Load();

            // выбираем сотрудников выбранного департамента
            listDepartments.SelectionChanged += delegate { p.DepartmentSelectionChanged(); };

            // удаляем департамент и всех его сотрудников
            btnDelDep.Click += delegate { p.DelDep(); };

            // удаляем выбранного сотрудника
            btnDelEmpl.Click += delegate { p.DelEmpl(); };

            // добавляем новый департамент
            btnAddDep.Click += delegate
            {
                var a = new AddDepart();
                a.ShowDialog();
                if (a.DialogResult == true)
                {
                    p.AddDep(a.addDepName.Text);
                    listDepartments.SelectedIndex = listDepartments.Items.Count - 1;
                }
            };

            // добавляем нового сотрудника
            btnAddEmpl.Click += delegate
            {
                var a = new AddEmpl();
                a.Depart.ItemsSource = DepartmentsComBox;
                a.Depart.SelectedItem = DepartmentSelectItem;
                a.ShowDialog();
                if (a.DialogResult == true)
                {
                    p.AddEmpl(a.FIO.Text, a.Age.Text, (a.Depart.SelectedItem as Department).IdDepart);
                }
            };

            // редактируем название департамента
            btnEditDep.Click += delegate
            {
                var a = new EditDep();
                a.oldDepName.Text = (DepartmentSelectItem as Department).NameDepart;
                a.ShowDialog();
                if (a.DialogResult == true)
                {
                    p.EditDep(a.oldDepName.Text, a.newDepName.Text);
                    listDepartments.Items.Refresh();
                }
            };

            // редактируем выбранного сотрудника
            btnEditEmpl.Click += delegate
            {
                var a = new EditEmpl(this);
                a.ShowDialog();
                if (a.DialogResult == true)
                {
                    p.EditEmpl((EmployeeSelectItem as Employee).ID, a.FIO.Text, a.Age.Text, (a.Depart.SelectedItem as Department).IdDepart);
                }
            };
        }
    }
}
