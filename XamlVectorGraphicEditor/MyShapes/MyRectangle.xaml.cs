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

partial class MyRectangle : Border
{
    private static int LastZIndex = 1;

    public MyRectangle(in Point whereSetMe)
    {
        InitializeComponent();
        ContextMenu.AddPaletteHeader(new ShapeBackgroundChanger(this));
        Canvas.SetLeft(this, whereSetMe.X);
        Canvas.SetTop(this, whereSetMe.Y);
        Canvas.SetZIndex(this, 1);
    }

    private void RectMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        CaptureMouse();
        Canvas.SetZIndex(this, ++LastZIndex);
        BorderBrush = Brushes.Red;
        BorderThickness = new Thickness(2);
    }

    private void RectMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ReleaseMouseCapture();
        BorderBrush = Brushes.Black;
        BorderThickness = new Thickness(0.5);
    }
}

