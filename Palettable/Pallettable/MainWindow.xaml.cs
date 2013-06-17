/*
 * Palettable
 * 
 * Palettable is the easy way to get attractive colour combinations derived from a base colour.
 * The base colour is selectable either by colour wheel or by entering a RGB value into the provided TextBox.
 * 
 * All colour swatches are synchronized to this TextBox Control. This textbox updates the model.
 * 
 * By: Cameron Dykeman
 * 
 * LastEdited: 14/06/2013
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Palettable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DocumentManager _documentManager;
        private ColourWheel currentWheel;

        public MainWindow()
        {
            InitializeComponent();
            currentWheel = colourWheelMono;
            _documentManager = new DocumentManager(currentWheel.textBox_RGB);
        }

        /* Notifies us of the current tab
         */
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                //Sync the wheel with the colour rectangles
                //Ex. currentWheel.SynchronizeWith(rectangleComplementPrimaryOne);
                if (tab_mono.IsSelected)
                    currentWheel = colourWheelMono;
                if (tab_complement.IsSelected)
                    currentWheel = colourWheelComplement;
                if (tab_triad.IsSelected)
                    currentWheel = colourWheelTriad;
                //sync toolbar colourblindness combo with current RGB box
                //Ex. toolbar.SynchronizeWith(currentWheel.getTextBoxRGB());
            }
        }

        //Savers and Loaders
        private void NewDocument(object sender, ExecutedRoutedEventArgs e)
        {
            _documentManager.NewDocument();
            Title = "New Document";
        }

        private void OpenDocument(object sender, ExecutedRoutedEventArgs e)
        {
            if (_documentManager.OpenDocument())
                Title = "Document Loaded";
        }

        private void SaveDocument(object sender, ExecutedRoutedEventArgs e)
        {
            if (_documentManager.SaveDocument())
                Title = "Document Saved";
        }

        private void SaveDocumentAs(object sender, ExecutedRoutedEventArgs e)
        {
            if (_documentManager.SaveDocumentAs())
                Title = "Document Saved";
        }

        private void ApplicationClose(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void SaveDocument_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _documentManager.CanSaveDocument();
        }

    }
}
