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

namespace ZamianaUnitermu
{
    /// <summary>
    /// Logika interakcji dla klasy AddCycle.xaml
    /// </summary>
    public partial class AddCycle : Window
    {
        public AddCycle()
        {
            InitializeComponent();
        }

        private void cuiBtinAdd_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
