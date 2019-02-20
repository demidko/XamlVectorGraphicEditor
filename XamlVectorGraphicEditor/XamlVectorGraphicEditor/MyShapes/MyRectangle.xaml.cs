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
    public MyRectangle(in Point whereSetMe)
    {
        InitializeComponent();
        Canvas.SetLeft(this, whereSetMe.X);
        Canvas.SetTop(this, whereSetMe.Y);
    }

    private void RectMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        CaptureMouse();
        BorderThickness = new Thickness(2);
    }

    private void RectMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ReleaseMouseCapture();
        BorderThickness = new Thickness(0);
    }
}

