using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace IntellectualOwl
{
    public class CustomTextEditor : TextEditor
    {
        bool isDataContextChanging = false;

        public TabItem SelectedItem
        {
            get
            {
                return DataContext as TabItem;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CustomTextEditor()
        {
            DataContextChanged += CustomTextEditor_DataContextChanged;
            TextChanged += CustomTextEditor_TextChanged;
            TextArea.Caret.PositionChanged += Caret_PositionChanged;
        }

        void CustomTextEditor_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            isDataContextChanging = true;
        }

        void CustomTextEditor_TextChanged(object sender, EventArgs e)
        {
            if (isDataContextChanging)
                TextArea.Caret.Offset = SelectedItem.Offset;

            isDataContextChanging = false;
        }

        void Caret_PositionChanged(object sender, EventArgs e)
        {
            if (isDataContextChanging)
                return;

            SelectedItem.Offset = TextArea.Caret.Offset;
        }
    }
}
