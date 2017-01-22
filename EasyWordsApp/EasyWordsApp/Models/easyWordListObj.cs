using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized; // NotifyCollectionChangedEventHandler

namespace EasyWordsApp.Models
{
    public class easyWordListObj
    {
        private TrulyObservableCollection<easyWord> ewList;
        private string ewListName;

        public TrulyObservableCollection<easyWord> EwList
        {
            get { return ewList; }
            set {ewList = value; }
        }

        public string EwListName
        {
            get {  return ewListName; }
            set { ewListName = value; }
        }

        public easyWordListObj(string listName = "")
        {
            ewList = new TrulyObservableCollection<easyWord>();
            ewListName = listName;
        }


        public class easyWord : INotifyPropertyChanged
        {
            private string ewUpSide;
            private string ewDownSide;
            private int ewKnowledgeLevel;

            public string EwUpSide
            {
                get { return ewUpSide; }
                set
                {
                    if (this.ewUpSide != value)
                    {
                        this.ewUpSide = value;
                        this.OnPropertyChanged("EwUpSide");
                    }

                }
            }

            public string EwDownSide
            {
                get { return ewDownSide; }
                set
                {
                    if (this.ewDownSide != value)
                    {
                        this.ewDownSide = value;
                        this.OnPropertyChanged("EwDownSide");
                    }

                }
            }

            public int EwKnowledgeLevel
            {
                get { return ewKnowledgeLevel; }
                set
                {
                    if (this.ewKnowledgeLevel != value)
                    {
                        this.ewKnowledgeLevel = value;
                        this.OnPropertyChanged("EwKnowledgeLevel");
                    }

                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string property)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

            public easyWord()
            {
                ewUpSide = "";
                ewDownSide = "";
                ewKnowledgeLevel = 0;
            }
            public easyWord(string upSide, string downSide)
            {
                ewUpSide = upSide;
                ewDownSide = downSide;
                ewKnowledgeLevel = 0;
            }

        }

        // ATTN: Please note it's a "TrulyObservableCollection" that's instantiated. Otherwise, "Trades[0].Qty = 999" will NOT trigger event handler "Trades_CollectionChanged" in main.
        // REF: http://stackoverflow.com/questions/8490533/notify-observablecollection-when-item-changes
        #region TrulyObservableCollection
        public class TrulyObservableCollection<T> : ObservableCollection<T>
        where T : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler ItemPropertyChanged;

            public TrulyObservableCollection()
                : base()
            {
                CollectionChanged += new NotifyCollectionChangedEventHandler(TrulyObservableCollection_CollectionChanged);
            }

            void TrulyObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.NewItems != null)
                {
                    foreach (Object item in e.NewItems)
                    {
                        (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
                if (e.OldItems != null)
                {
                    foreach (Object item in e.OldItems)
                    {
                        (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                    }
                }
            }

            void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                NotifyCollectionChangedEventArgs a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                OnCollectionChanged(a);

                if (ItemPropertyChanged != null)
                {
                    ItemPropertyChanged(sender, e);
                }
            }
        }
        #endregion
    }

}
