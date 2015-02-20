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
using Dragablz;
using System.Data;

namespace IntellectualOwl
{
    public class ViewModel
    {
        private int tabCounter = 0;
        private readonly IInterTabClient _interTabClient;
        public IInterTabClient InterTabClient
        {
            get { return _interTabClient; }
        }
        public ObservableCollection<TabItem> Tabs { get; set; }
        public int SelectedIndex { get; set; }

        public ViewModel()
        {
            _interTabClient = new DefaultInterTabClient();

            Tabs = new ObservableCollection<TabItem>();
            Tabs.Add(new TabItem() { Header = "query1" });

            tabCounter = Tabs.Count;
        }

        public Func<object> NewItemFactory
        {
            get { return () => new TabItem() { Header = string.Format("query{0}", ++tabCounter) }; }
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

        DataTable results = null;
        public DataTable Results
        {
            get
            {
                if (results == null)
                    results = CreateRandomTable();

                return results;
            }
            set
            {
                results = value;
            }
        }

        #endregion

        private DataTable CreateRandomTable()
        {
            DataTable table = new DataTable();

            //table.Columns.Add(new DataColumn("adf"));
            //table.Columns.Add(new DataColumn("aasdfadfdf"));
            //table.Columns.Add(new DataColumn("dfs"));
            //table.Columns.Add(new DataColumn("af asdf"));

            return table;
        }
    }

    public class InterTabClient : IInterTabClient
    {

        public INewTabHost<Window> GetNewHost(IInterTabClient interTabClient, object partition, TabablzControl source)
        {
            return null;
        }

        public TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            var resp = new TabEmptiedResponse();
            return resp;
        }
    }
}
