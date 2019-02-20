using System.Windows.Media;

struct ShapeBackgroundChanger : IBackgroundChanger
{
    private readonly MyRectangle Component;

    public Brush Background
    {
        get => Component.Background;
        set => Component.Background = value;
    }

    public ShapeBackgroundChanger(in MyRectangle rect)
    {
        Component = rect;
    }
}

