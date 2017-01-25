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
            int rndNum = learnList.getRndWordNum();
            Dictionary<int, TrulyObservableCollection<easyWord>> wordDictionary = new Dictionary<int, TrulyObservableCollection<easyWord>>();
            wordDictionary.Add(rndNum, learnList.EwList);
            Application app = Application.Current;
            app.Properties["wordListObj"] = learnList;
            app.Properties["wordNum"] = rndNum;
            wordTextBox.DataContext = learnList.EwList[rndNum];
            slctdListLearningLabel.DataContext = learnList;

        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomePage());
        }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            if (app.Properties["wordListObj"] != null)
            {
                if (wordTextBox.DataContext == null || wordTextBox2.DataContext == null)
                {
                    ((easyWordListObj)app.Properties["wordListObj"]).EwList[(int)app.Properties["wordNum"]].EwKnowledgeLevel = 1;
                    System.IO.File.WriteAllText($@"C:\neXX\GIT Projects\EasyWordsApp\EasyWordsApp\EasyWordsApp\ewListsFolder\{((easyWordListObj)app.Properties["wordListObj"]).EwListName}.json", JsonConvert.SerializeObject(((easyWordListObj)app.Properties["wordListObj"]), Formatting.Indented));
                }

                this.NavigationService.Navigate(new LearningPage(((easyWordListObj)app.Properties["wordListObj"])));
            }

        }

        private void check_btn_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            if (app.Properties["wordListObj"] != null)
            {
                wordTextBox2.DataContext = ((easyWordListObj)app.Properties["wordListObj"]).EwList[(int)app.Properties["wordNum"]];
                ((easyWordListObj)app.Properties["wordListObj"]).EwList[(int)app.Properties["wordNum"]].EwKnowledgeLevel = 0;
                System.IO.File.WriteAllText($@"C:\neXX\GIT Projects\EasyWordsApp\EasyWordsApp\EasyWordsApp\ewListsFolder\{((easyWordListObj)app.Properties["wordListObj"]).EwListName}.json", JsonConvert.SerializeObject(((easyWordListObj)app.Properties["wordListObj"]), Formatting.Indented));
            }
        }
    }
}
