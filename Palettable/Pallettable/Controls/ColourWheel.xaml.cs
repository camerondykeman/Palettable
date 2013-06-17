//ALL rectangles will synchronize with primary colour
    //each will then perform a slightly different calculation on that primary to get new colour

//NEED
//synch


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
    /// Interaction logic for ColourWheel.xaml
    /// </summary>
    public partial class ColourWheel : UserControl
    {

        public ColourWheel()
        {
            InitializeComponent();
        }

        /* Synchronize the RGB field with the given colourRectangle
         */
        public struct syncPack
        {
            public Rectangle rect;
            public String hex;
        };
        public void SynchronizeWith(Rectangle rect)
        {
            isSynchronizing = true;
            Synchronized<syncPack>(rect, Rectangle.FillProperty, SetColour);
            isSynchronizing = false;

        }

        //Issues converting Rectangle to syncPack -> address later
        private void Synchronized<T>(Rectangle selection, DependencyProperty property, Action<T> methodToCall)
        {
            object value = selection;
            if (value != DependencyProperty.UnsetValue)
            {
                methodToCall((T)value);
            }
        }
        public bool isSynchronizing { get; private set; }

        /* Sets the colour of the given rectangle
         */
        public void SetColour(syncPack pack)
        {
            Color color = (Color)ColorConverter.ConvertFromString(pack.hex);
            SolidColorBrush myBrush = new SolidColorBrush(color);
            pack.rect.Fill = myBrush;
        }

        public TextBox getTextBoxRGB()
        {
            return textBox_RGB;
        }

        private void image_colourWheelMono_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //get event x and y
            //translate that coordinate to a colour value
            //translate that to an RGB value
            //sync with RBG TextBox
        }
        
    }
}
