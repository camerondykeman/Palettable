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
using System.Windows.Shapes;

namespace Palettable
{
    /// <summary>
    /// Interaction logic for PallettableToolBar.xaml
    /// </summary>
    public partial class PalettableToolBar : UserControl
    {
        public PalettableToolBar()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            combo_colourBlindness.Items.Add("Protanopy");
            combo_colourBlindness.Items.Add("Deuteranopy");
            combo_colourBlindness.Items.Add("Tritanopy");
            combo_colourBlindness.Items.Add("Protanomaly");
            combo_colourBlindness.Items.Add("Deuteranomaly");
            combo_colourBlindness.Items.Add("Tritanomaly");
            combo_colourBlindness.Items.Add("Deuteranopy");
            combo_colourBlindness.Items.Add("Full Colourblindness");
        }

        /* Synchronize the combobox field with the given RGB textBox
        */
        public struct syncPack
        {
            public TextBox textBoxRGB;
            public String hex;
        };
        public void SynchronizeWith(TextBox textBoxRGB)
        {
            isSynchronizing = true;
            Synchronized<syncPack>(textBoxRGB, TextBox.TextProperty, SetPrimaryColour);
            isSynchronizing = false;

        }
        //Issues converting TextBox to syncPack -> address later
        private void Synchronized<T>(TextBox selection, DependencyProperty property, Action<T> methodToCall)
        {
            object value = selection;
            if (value != DependencyProperty.UnsetValue)
            {
                methodToCall((T)value);
            }
        }
        public bool isSynchronizing { get; private set; }

        /* Sets the colour text of the given TextBox
         */
        public void SetPrimaryColour(syncPack pack)
        {
            //make a new colour
            Color newColour = new Color();
            //get current colour from pack
            //get variety of colourblindness from combo
            //convert colour based on variety of CB
            //set RGB to new colour's hex
            pack.textBoxRGB.Text = newColour.ToString();
        }

        private void Swap()
        {
            //swap colour for polar opposite
        }

        private void Random()
        {
            //get random primary colour
        }

        private void combo_colourBlindness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_swap_Click(object sender, RoutedEventArgs e)
        {
            Swap();
        }

        private void button_random_Click(object sender, RoutedEventArgs e)
        {
            Random();
        }
    }
}
