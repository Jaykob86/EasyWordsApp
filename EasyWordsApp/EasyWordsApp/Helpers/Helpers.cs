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
    public static class Helpers
    {
        public static string listsFolder = $@"{Directory.GetCurrentDirectory()}\ewListsFolder\";
    }
}
