using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyWordsApp.Models
{
    public class easyWordListObj
    {
        public List<easyWord> ewList { get; set; }
        public string ewListName { get; set; }

        public easyWordListObj(string listName = "")
        {
            ewList = new List<easyWord>();
            ewListName = listName;
        }


        public class easyWord
        {
            public string ewLeftSide { get; set; }
            public string ewRightSide { get; set; }
            public int ewKnowledgeLevel { get; set; }

            public easyWord(string leftSide = "", string rightSide = "")
            {
                ewLeftSide = leftSide;
                ewRightSide = rightSide;
                ewKnowledgeLevel = 0;
            }

        }

    }

}
