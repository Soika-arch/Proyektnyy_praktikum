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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для Dovidnik_Spivrobitnykiv.xaml
    /// </summary>
    public partial class Dovidnik_Spivrobitnykiv : Window
    {
        public Dovidnik_Spivrobitnykiv()
        {
            InitializeComponent();
        }

        public Dovidnik_Spivrobitnykiv(dynamic ds)
        {
            InitializeComponent();
            DataContext = ds;
        }
    }
}
