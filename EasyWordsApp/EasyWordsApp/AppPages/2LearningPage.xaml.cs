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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyWordsApp
{
    /// <summary>
    /// Interaction logic for LearningPage.xaml
    /// </summary>
    public partial class LearningPage : Page
    {
        public LearningPage()
        {
            InitializeComponent();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(@"\AppPages\1WelcomePage.xaml", UriKind.Relative));
        }
    }
}
