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
    public class ViewModel
    {
        public ObservableCollection<TabItem> Tabs { get; set; }
        private int selectedIndex;
        public int SelectedIndex { get; set; }

        public ViewModel()
        {
            Tabs = new ObservableCollection<TabItem>();
            Tabs.Add(new TabItem() { Header = "hello1", Text = string.Empty });
            Tabs.Add(new TabItem() { Header = "hello2", Text = string.Empty });
            Tabs.Add(new TabItem() { Header = "hello3", Text = string.Empty });
        }
    }

    public class TabItem
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public TabItem()
        {
        }

        #region Properties
        public TabItem Item { get { return this; } }
        
        public string Header { get; set; }
        public int Offset { get; set; }

        public int SelectionStart { get; set; }
        public int SelectionLength { get; set; }
        public Selection Selection { get; set; }

        private TextDocument document = new TextDocument();
        public TextDocument Document {
            get { return document; }
            set 
            { 
                document = value;
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
                }
            }
        }

        #endregion
    }
}
