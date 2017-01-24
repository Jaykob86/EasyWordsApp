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
    /// Interaction logic for WordManagerPage.xaml
    /// </summary>
    public partial class WordManagerPage : Page
    {
        public WordManagerPage(easyWordListObj newList, bool createNew)
        {
            InitializeComponent();
            if (createNew)
            {
                newListTextBox.Text = "";
            }
            else
            {
                newListTextBox.Text = newList.EwListName;
            }
            dgEditEwList.ItemsSource = newList.EwList;
        }

        private void backToLists_btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ListManagerPage());
        }

        private void saveChanges_btn_Click(object sender, RoutedEventArgs e)
        {
            easyWordListObj userList = new easyWordListObj(newListTextBox.Text);
            foreach (easyWord item in dgEditEwList.ItemsSource)
            {
                userList.EwList.Add(item);
            }
            System.IO.File.WriteAllText($@"C:\neXX\GIT Projects\EasyWordsApp\EasyWordsApp\EasyWordsApp\ewListsFolder\{userList.EwListName}.json", JsonConvert.SerializeObject(userList, Formatting.Indented));
            MessageBox.Show("Your list was saved!");
            this.NavigationService.Navigate(new ListManagerPage());
        }
    }
}
