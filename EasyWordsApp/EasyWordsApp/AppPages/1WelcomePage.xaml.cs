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
using System.IO;
using EasyWordsApp.Models;
using static EasyWordsApp.Models.easyWordListObj;
using Newtonsoft.Json;

namespace EasyWordsApp
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            if (File.Exists("settings.txt"))
            {
                string slctdListName = File.ReadAllText("settings.txt");
                startLearning_btn.IsEnabled = true;
                slctdListLabel.Content = slctdListName;
            }
            else
            {
                slctdListLabel.Content = "No list selected in List manager";
                startLearning_btn.IsEnabled = false;
            }

        }

        private void startLearning_btn_Click(object sender, RoutedEventArgs e)
        {
            string slctdListName = File.ReadAllText("settings.txt");
            easyWordListObj learnEwList = new easyWordListObj();
            using (StreamReader r = new StreamReader(App.APPFOLDER + slctdListName + ".json"))
            {
                string json = r.ReadToEnd();
                learnEwList = JsonConvert.DeserializeObject<easyWordListObj>(json);
            }
            this.NavigationService.Navigate(new LearningPage(learnEwList));
        }

        private void listManager_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListManagerPage());
        }
    }
}
