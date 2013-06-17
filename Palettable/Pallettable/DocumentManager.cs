using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;

namespace Palettable
{
    class DocumentManager
    {

        private string _currentFile;
        private TextBox _RGB;

        public DocumentManager(TextBox RGB)
        {
            _RGB = RGB;
        }

        public bool OpenDocument()
        {
            OpenFileDialog dig = new OpenFileDialog();
            if (dig.ShowDialog() == true)
            {
                _currentFile = dig.FileName;
                //Load in all info from file
                //if mono
                //if comp
                //if triad

                return true;
            }
            return false;
        }

        public bool SaveDocument()
        {
            if (string.IsNullOrEmpty(_currentFile))
            {
                return SaveDocumentAs();
            }
            else
            {
                using (StreamWriter stream = new StreamWriter(_currentFile))
                {
                    //Add all values to output string
                    //if mono
                        //derive all mono colours from _BRG
                        //stream.writeLine("Primary1[" + _RGB.Text + ']');
                    //if comp
                        //derive comp colours from _BRG
                    //if triad
                        //derive triad colours from _BRG
                }
                return true;
            }
        }
        public bool SaveDocumentAs()
        {
            SaveFileDialog dig = new SaveFileDialog();
            dig.Filter = "Rich Text DocumentManager|*.rtf|Text  DocumentManager|*.txt";

            if (dig.ShowDialog() == true)
            {
                _currentFile = dig.FileName;
                return SaveDocument();
            }
            return false;
        }


        public void NewDocument()
        {
            _currentFile = null;
            //Set _RGB.Text back to starting colour
        }

        public bool CanSaveDocument()
        {
            return !string.IsNullOrEmpty(_currentFile);
        }

        public void Swap()
        {

        }

        public void Random()
        {

        }

    }
}
