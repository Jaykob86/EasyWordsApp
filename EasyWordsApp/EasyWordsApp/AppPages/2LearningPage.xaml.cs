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
using System.ComponentModel;

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
            easyWord rndWord = learnList.getRndWord();
            //Dictionary<easyWord, TrulyObservableCollection<easyWord>> wordDictionary = new Dictionary<easyWord, TrulyObservableCollection<easyWord>>();
            //wordDictionary.Add(rndWord, learnList.EwList);
            Application app = Application.Current;
            app.Properties["wordListObj"] = learnList;
            app.Properties["eW"] = rndWord;
            wordTextBox.DataContext = rndWord;
            slctdListLearningLabel.DataContext = learnList;

        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            System.IO.File.WriteAllText($@"C:\neXX\GIT Projects\EasyWordsApp\EasyWordsApp\EasyWordsApp\ewListsFolder\{((easyWordListObj)app.Properties["wordListObj"]).EwListName}.json", JsonConvert.SerializeObject(((easyWordListObj)app.Properties["wordListObj"]), Formatting.Indented));
            this.NavigationService.Navigate(new WelcomePage());
        }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            if (app.Properties["wordListObj"] != null)
            {
                if (wordTextBox.DataContext == null || wordTextBox2.DataContext == null)
                {
                    ((easyWordListObj)app.Properties["wordListObj"]).EwList.Select(x=>x)
                                                                    .Where(x => x == (easyWord)app.Properties["eW"])
                                                                    .First()
                                                                    .EwKnowledgeLevel = 1;
                    //System.IO.File.WriteAllText($@"C:\neXX\GIT Projects\EasyWordsApp\EasyWordsApp\EasyWordsApp\ewListsFolder\{((easyWordListObj)app.Properties["wordListObj"]).EwListName}.json", JsonConvert.SerializeObject(((easyWordListObj)app.Properties["wordListObj"]), Formatting.Indented));
                }

                this.NavigationService.Navigate(new LearningPage(((easyWordListObj)app.Properties["wordListObj"])));
            }

        }

        private void check_btn_Click(object sender, RoutedEventArgs e)
        {
            Application app = Application.Current;
            if (app.Properties["wordListObj"] != null)
            {
                wordTextBox2.DataContext = ((easyWordListObj)app.Properties["wordListObj"]).EwList.Select(x => x)
                                                                    .Where(x => x == (easyWord)app.Properties["eW"])
                                                                    .First();
                ((easyWordListObj)app.Properties["wordListObj"]).EwList.Select(x => x)
                                                                    .Where(x => x == (easyWord)app.Properties["eW"])
                                                                    .First()
                                                                    .EwKnowledgeLevel = 0;
                //System.IO.File.WriteAllText($@"C:\neXX\GIT Projects\EasyWordsApp\EasyWordsApp\EasyWordsApp\ewListsFolder\{((easyWordListObj)app.Properties["wordListObj"]).EwListName}.json", JsonConvert.SerializeObject(((easyWordListObj)app.Properties["wordListObj"]), Formatting.Indented));
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                e.Handled = true;
            }
        }

    }
}
