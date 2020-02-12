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

namespace REACH_Mastermind_Project
{
    /// <summary>
    /// Interaction logic for Result_Fail.xaml
    /// Window opens if player has no more attempts
    /// </summary>
    public partial class Result_Fail : Window
    {
        public Result_Fail()
        {
            InitializeComponent();
        }

        //Close Button---------------------------------------------
        private void Close_Btn(object sender, RoutedEventArgs e)
        {
            MainWindow returnMain = new MainWindow();
            returnMain.Show();
            this.Close();
        }
    }
}