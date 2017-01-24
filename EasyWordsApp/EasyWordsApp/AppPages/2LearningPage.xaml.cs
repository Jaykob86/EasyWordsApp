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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasyWordsApp.Models;
using static EasyWordsApp.Models.easyWordListObj;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace EasyWordsApp
{
    /// <summary>
    /// Interaction logic for LearningPage.xaml
    /// </summary>
    public partial class LearningPage : Page
    {
        public LearningPage(easyWordListObj learnList)
        {
            InitializeComponent();
            Random rnd = new Random();
            
            wordTextBox.Text = learnList.EwList[rnd.Next(0, learnList.EwList.Count)].EwUpSide;
            
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomePage());
        }
    }
}
