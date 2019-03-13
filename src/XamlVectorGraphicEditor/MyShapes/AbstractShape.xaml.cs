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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

partial class AbstractShape : Border
{
    private static AbstractShape Top;
    private static int LastZIndex;
    private double CurrentRotate = 0;

    private void RectMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (Top != null)
        {
            Top.BorderBrush = Brushes.Black;
            Top.BorderThickness = new Thickness(0.2);
        }
        Top = this;
        Canvas.SetZIndex(this, ++LastZIndex);
        CaptureMouse();
        BorderThickness = new Thickness(2);
        BorderBrush = Brushes.Red;
    }

    private void RectMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        ReleaseMouseCapture();
        BorderBrush = Brushes.DeepSkyBlue;
    }

    private void DeleteClick(object sender, RoutedEventArgs e) => (VisualParent as Canvas).Children.Remove(this);

    private void Rotate(in int angle)
    {
        CurrentRotate += angle;
        if (CurrentRotate >= 360)
        {
            CurrentRotate -= 360;
        }
        var shape = Child as Shape;

        var rotate = new RotateTransform(CurrentRotate, Height / 2, Width / 2);
        if (shape is Rectangle && (CurrentRotate % 90) == 0)
        {
            var h = Height;
            Height = Width;
            Width = h;
        }
        shape.LayoutTransform = rotate;
    }

    private void Right10Click(object sender, RoutedEventArgs e) => Rotate(10);

    private void Right30Click(object sender, RoutedEventArgs e) => Rotate(30);

    private void Right60Click(object sender, RoutedEventArgs e) => Rotate(60);

    private void Right90Click(object sender, RoutedEventArgs e) => Rotate(90);

    private void CloneClick(object sender, RoutedEventArgs e) =>
        (VisualParent as Canvas).Children.Add(new AbstractShape(this));

    public AbstractShape(in Point whereSetMe, in Shape shape)
    {
        InitializeComponent();
        Child = shape;
        ContextMenu.AddPaletteHeader(new ShapeBackgroundChanger(shape));
        Canvas.SetLeft(this, whereSetMe.X);
        Canvas.SetTop(this, whereSetMe.Y);
        LastZIndex = Canvas.GetZIndex(this);
    }

    public AbstractShape(in AbstractShape other)
    {
        InitializeComponent();
        Height = other.Height;
        Width = other.Width;
        RenderTransform = other.RenderTransform;
        LayoutTransform = other.LayoutTransform;
        Canvas.SetLeft(this, Canvas.GetLeft(other) - 15);
        Canvas.SetTop(this, Canvas.GetTop(other) - 15);
        BorderBrush = Brushes.Yellow;
        LastZIndex = Canvas.GetZIndex(this);
        var otherShape = other.Child as Shape;
        Shape newShape;
        switch (otherShape)
        {
            case Ellipse elli:
                newShape = new Ellipse();
                break;
            case Polygon poly:
                newShape = new Polygon()
                {
                    Points = poly.Points,
                    Stretch = Stretch.Fill
                };
                break;
            case Rectangle rect:
            default:
                newShape = new Rectangle();
                break;
        }
        newShape.Fill = otherShape.Fill;
        newShape.RenderTransform = otherShape.RenderTransform;
        newShape.LayoutTransform = otherShape.LayoutTransform;
        Child = newShape;
        ContextMenu.AddPaletteHeader(new ShapeBackgroundChanger(newShape));
    }

    private void Border_SizeChanged(object sender, SizeChangedEventArgs e)
    {

    }
}

