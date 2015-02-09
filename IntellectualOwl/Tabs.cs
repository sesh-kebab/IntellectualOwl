using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Editing;

namespace IntellectualOwl
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TabItem> Tabs { get; set; }
        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                selectedIndex = value;
                OnPropertyChanged(this, "SelectedItem");
            }
        }

        public ViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();
            Tabs.Add(new TabItem(this) { Header = "hello1"});
            Tabs.Add(new TabItem(this) { Header = "hello2"});
            Tabs.Add(new TabItem(this) { Header = "hello3" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(object caller, string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(caller, new PropertyChangedEventArgs(property));
        }
    }

    public class TabItem
    {
        ViewModel m { get; set; }
        public string Header { get; set; }

        public TabItem(ViewModel m)
        {
            this.m = m;
        }

        public TabItem Item { get { return this; } }

        private int offset;
        public int Offset
        {
            get { return offset; }
            set
            {
                offset = value;
                OnPropertyChanged("Offset");
            }
        }

        private int selectionStart;
        public int SelectionStart
        {
            get { return selectionStart; }
            set
            {
                selectionStart = value;
                OnPropertyChanged("SelectionStart");
            }
        }

        private int selectionLength;
        public int SelectionLength
        {
            get { return selectionLength; }
            set
            {
                selectionLength = value;
                OnPropertyChanged("SelectionLength");
            }
        }

        private string text = string.Empty;
        public string Text
        {
            get { return text; }
            set 
            {
                text = value;
                OnPropertyChanged("Text"); 
            }
        }

        private TextDocument document = new TextDocument();
        public TextDocument Document {
            get { return document; }
            set 
            { 
                document = value;
                OnPropertyChanged("Document");
            }        
        }

        private IHighlightingDefinition _highlightdef = null;
        public IHighlightingDefinition HighlightDef
        {
            get { return this._highlightdef; }
            set
            {
                if (this._highlightdef != value)
                {
                    this._highlightdef = value;
                    OnPropertyChanged("HighlightDef");
                }
            }
        }

        public Selection Selection { get; set; }

        protected void OnPropertyChanged(string name)
        {
            m.OnPropertyChanged(this, name);
        }
    }
}
