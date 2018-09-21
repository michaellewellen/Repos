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

namespace Asteroids
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

public double RoidSize
        {
            get { return (double)GetValue(RoidSizeProperty); }
            set { SetValue(RoidSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RoidSizeProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RoidSizeProperty =
            DependencyProperty.Register("RoidSize", typeof(double), typeof(MainWindow), new PropertyMetadata(0));

public double XCoordinate
        {
            get { return (double)GetValue(XCoordinateProperty); }
            set { SetValue(XCoordinateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XCoordinateProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XCoordinateProperty =
            DependencyProperty.Register("XCoordinate", typeof(double), typeof(MainWindow), new PropertyMetadata(0));

public double YCoordinate
        {
            get { return (double)GetValue(YCoordinateProperty); }
            set { SetValue(YCoordinateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YCoordinateProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YCoordinateProperty =
            DependencyProperty.Register("YCoordinate", typeof(double), typeof(MainWindow), new PropertyMetadata(0));


    }



        


    }

