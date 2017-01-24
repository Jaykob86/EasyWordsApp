using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyWordsApp.Models;
using System.IO;
using static EasyWordsApp.Models.easyWordListObj;
using Newtonsoft.Json;


namespace EasyWordsApp.Helpers
{
    public class Helpers
    {
        public List<easyWordListObj> getAllEwLists()
        {
            easyWordListObj oneEwList = new easyWordListObj();
            List<easyWordListObj> allEwLists = new List<easyWordListObj>();
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
            return allEwLists;
        }
    }
}
