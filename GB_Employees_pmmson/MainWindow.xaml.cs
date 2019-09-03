using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// TODO: символ подчеркивания _ в разметке?

namespace GB_Employees_pmmson
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // инициализация внутренней логики
        Main a;  

        public MainWindow()
        {
            // инициализация компонентов
            InitializeComponent();

            // загружаем данные
            a = new Main();

            // связь отображения и данных
            this.DataContext = a;

            a.LoadDepartment();
            a.LoadEmployee();

            // TODO: реализацию подсчета кол-ва сотрудников и департаментов хочу перенести в заголовок окна, возможно ? какое используется свойство ?

        }

        private void ListDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: возможно ли выборку прописать в XAML? Т.е. формировать вывод фильтрованной коллекции по выбранному в другом элементе свойству?
            // TODO: вывод всех сотрудников - (all) ?
            // TODO: лист сотрудников без департамента ?


            // Solution Sergeya
            //listEmpl.ItemsSource = data.EmployeesDb.Where(
            //    w => w.DepartamentId == (cmbDept.SelectedValue as Department)?.DepartmentId
            //    );

            // TODO: не работает обновление при удалении или добавлении сотрудника
            ComboBox comboBox = (ComboBox)sender;
            Department selectedItem = (Department)comboBox.SelectedItem;
           
            listEmployees.ItemsSource = from employee in a.Employees
                                        where employee.IdDepart == selectedItem?.IdDepart
                                        select employee;
            
        }

        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            // TODO: если департаменты совпадают, то сотрудники должны быть в том же департаменте ?
            // TODO: что должна делать данная кнопка, если обновление коллекции реализована через XAML (при потери фокуса Text по связке изменил источник) ?
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            a.AddDep(txtAddDepName.Text);
            txtAddDepName.Text = "";
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            a.DelDep(txtDepName.Text);
        }

        private void BtnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            a.AddEmpl(txtAddEmplName.Text, txtAddEmplAge.Text, txtAddEmplDep.Text);
            txtAddEmplName.Text = "";
            txtAddEmplAge.Text = "";
            txtAddEmplDep.Text = "";
        }

        private void BtnDelEmpl_Click(object sender, RoutedEventArgs e)
        {
            a.DelEmpl(txtDelEmplName.Text);
        }
    }
}
