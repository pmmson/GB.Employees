﻿using System;
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
    /// Логика взаимодействия для EditDep.xaml
    /// </summary>
    public partial class EditDep : Window
    {
        public EditDep()
        {
            InitializeComponent();
            btnOK.Click += delegate
            {
                this.DialogResult = true;
            };
        }
    }
}
