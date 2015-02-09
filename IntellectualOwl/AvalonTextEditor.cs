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
        bool _reloadingChanges = false;

        public TabItem CurrentTabModel
        {
            get
            {
                return DataContext as TabItem;
            }
        }

        public CustomTextEditor()
        {
            TextArea.Caret.PositionChanged += Caret_PositionChanged;
            TextArea.Document.TextChanged += Document_TextChanged;
            TextArea.SelectionChanged += TextArea_SelectionChanged;

            GotFocus += CustomTextEditor_GotFocus;
        }

        void CustomTextEditor_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                _reloadingChanges = true;

                Document.Text = CurrentTabModel.Text;
                TextArea.Caret.Offset = CurrentTabModel.Offset;

                if (CurrentTabModel.Selection == null)
                    CurrentTabModel.Selection = TextArea.Selection;
                else
                    TextArea.Selection = CurrentTabModel.Selection;
            }
            finally
            {
                _reloadingChanges = false;
            }
            
        }

        void Document_TextChanged(object sender, EventArgs e)
        {
            if (_reloadingChanges)
                return;

            CurrentTabModel.Text = Document.Text;
        }

        void Caret_PositionChanged(object sender, EventArgs e)
        {
            if (_reloadingChanges)
                return;

            CurrentTabModel.Offset = TextArea.Caret.Offset;

        }

        void TextArea_SelectionChanged(object sender, EventArgs e)
        {
            if (_reloadingChanges)
                return;

            CurrentTabModel.Selection = TextArea.Selection;
        }
    }
}
