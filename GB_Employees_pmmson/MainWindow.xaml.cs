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
            a.LoadDepartment();
            a.LoadEmployee();

            // связываем отображение с данными 
            // TODO: перенести в ресурсы возможно? Пока не разобрлася как это сделать...
            listDepartments.ItemsSource = a.Departments;
            listEmployees.ItemsSource = a.Employees;

            // TODO: как в XAML указать кол-во ? но итоговую реализацию хочу перенести в заголовок окна, возможно ? какое используется свойство ?
            lblCountDep.Content = a.CountDepart.ToString(); 
            lblCountEmp.Content = a.CountEmpl.ToString();
        }

        private void ListDepartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: возможно ли выборку прописать в XAML? Т.е. формировать вывод фильтрованной коллекции по выбранному в другом элементе свойству?
            // TODO: вывод всех сотрудников - (all) ?
            // TODO: лист сотрудников без департамента ?

            ComboBox comboBox = (ComboBox)sender;
            Department selectedItem = (Department)comboBox.SelectedItem;

            ObservableCollection<Employee> selectedEmployees = new ObservableCollection<Employee>();

            foreach (Employee employee in a.Employees)
            {
                if (employee.IdDepart == selectedItem?.IdDepart) selectedEmployees.Add(employee);
            }

            listEmployees.ItemsSource = selectedEmployees;
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
            lblCountDep.Content = a.CountDepart.ToString(); //
            lblCountEmp.Content = a.CountEmpl.ToString(); //
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            a.DelDep(lblDepName.Content.ToString());
            lblCountDep.Content = a.CountDepart.ToString(); //
            lblCountEmp.Content = a.CountEmpl.ToString(); //
        }
    }
}
