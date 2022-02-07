using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Занятие17WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для СolorPicker.xaml
    /// </summary>
    public partial class СolorPicker : UserControl
    {
        
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register(
                "Color",
                typeof(Color),
                typeof(СolorPicker),
                new FrameworkPropertyMetadata(
                    Colors.Black,
                    new PropertyChangedCallback(OnColorChanged))); 

        public static readonly DependencyProperty RedProperty =
            DependencyProperty.Register(
                "Red",
                typeof(byte),
                typeof(СolorPicker),
                new FrameworkPropertyMetadata(
                    new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty GreenProperty =
           DependencyProperty.Register(
               "Green",
               typeof(byte),
               typeof(СolorPicker),
               new FrameworkPropertyMetadata(
                   new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty BlueProperty =
          DependencyProperty.Register(
              "Blue",
              typeof(byte),
              typeof(СolorPicker),
              new FrameworkPropertyMetadata(
                  new PropertyChangedCallback(OnColorRGBChanged)));
    

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            СolorPicker colorPicker = (СolorPicker)sender;
            colorPicker.Red = newColor.R;
            colorPicker.Green = newColor.G;
            colorPicker.Blue = newColor.B;
        }

        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            СolorPicker colorPicker = (СolorPicker)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }

        public static readonly RoutedEvent ColorChangedEvent =
            EventManager.RegisterRoutedEvent(
                "ColorChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>),
                typeof(СolorPicker));

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }
        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }
        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }

        public СolorPicker()
        {
            InitializeComponent();
        }
    }
}
