﻿using System;
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
using System.Windows.Shapes;

namespace myShop
{
    /// <summary>
    /// Логика взаимодействия для ChangeCheck.xaml
    /// </summary>
    public partial class ChangeCheck : Window
    {
        public ChangeCheck(CheckModel Selectedcheck, DBOperations db)
        {
            InitializeComponent();
            DataContext = new ChangeCheckViewModel(this, Selectedcheck, db);
        }
    }
}
