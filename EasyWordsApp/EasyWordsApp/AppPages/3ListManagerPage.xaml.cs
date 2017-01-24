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
using System.IO;
using static EasyWordsApp.Models.easyWordListObj;
using Newtonsoft.Json;

namespace EasyWordsApp
{
    /// <summary>
    /// Interaction logic for ListManagerPage.xaml
    /// </summary>
    public partial class ListManagerPage : Page
    {
        public ListManagerPage()
        {
            List<easyWordListObj> allEwLists = new List<easyWordListObj>();
            easyWordListObj oneEwList = new easyWordListObj();
            DirectoryInfo d = new DirectoryInfo(App.APPFOLDER);

            foreach (var file in d.GetFiles())
            {
                string filePath = file.FullName;
                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    oneEwList = JsonConvert.DeserializeObject<easyWordListObj>(json);
                }
                allEwLists.Add(oneEwList);
            }
            List<string> listNames = allEwLists.Select(x => x.EwListName).ToList();
            InitializeComponent();
            listsListView.ItemsSource = allEwLists.Select(x => x.EwListName).ToList();

        }

        private void back_button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WelcomePage());
        }

        private void selectList_btn_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("settings.txt",listsListView.SelectedItem.ToString());
            this.NavigationService.Navigate(new WelcomePage());
        }

        private void editList_btn_Click(object sender, RoutedEventArgs e)
        {
            easyWordListObj editEwList = new easyWordListObj();
            using (StreamReader r = new StreamReader(App.APPFOLDER + listsListView.SelectedItem + ".json"))
            {
                string json = r.ReadToEnd();
                editEwList = JsonConvert.DeserializeObject<easyWordListObj>(json);
            }
            
            this.NavigationService.Navigate(new WordManagerPage(editEwList,false));
        }

        private void createList_btn_Click(object sender, RoutedEventArgs e)
        {
            easyWordListObj newListObj = new Models.easyWordListObj();
            this.NavigationService.Navigate(new WordManagerPage(newListObj,true));
        }
    }
}

