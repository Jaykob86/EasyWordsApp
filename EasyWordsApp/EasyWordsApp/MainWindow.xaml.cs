using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainWindowFrame.Navigate(new WelcomePage());
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application app = Application.Current;
            if ((easyWordListObj)app.Properties["wordListObj"] != null)
            {
                System.IO.File.WriteAllText(Helpers.Helpers.listsFolder + ((easyWordListObj)app.Properties["wordListObj"]).EwListName + ".json", JsonConvert.SerializeObject(((easyWordListObj)app.Properties["wordListObj"]), Formatting.Indented));
            }
        }

    }
}
