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
    private static MyRectangle Top = null;
    private static int LastZIndex;

    public MyRectangle(in Point whereSetMe)
    {
        InitializeComponent();
        ContextMenu.AddPaletteHeader(new ShapeBackgroundChanger(this));
        Canvas.SetLeft(this, whereSetMe.X);
        Canvas.SetTop(this, whereSetMe.Y);
        LastZIndex = Canvas.GetZIndex(this);
    }

    private void RectMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (Top != null)
        {
            Top.BorderBrush = Brushes.Red;
            Top.BorderThickness = new Thickness(0);
        }
        Top = this;
        Canvas.SetZIndex(this, ++LastZIndex);
        CaptureMouse();
        BorderThickness = new Thickness(2);
    }

    private void RectMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ReleaseMouseCapture();
        BorderBrush = Brushes.Yellow;
        BorderThickness = new Thickness(1);
    }
}

