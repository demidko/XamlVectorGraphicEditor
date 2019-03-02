using System.Windows.Media;
using System.Windows.Shapes;

struct ShapeBackgroundChanger : IBackgroundChanger
{
    private readonly Shape Component;

    public Brush Background
    {
        get => Component.Fill;
        set => Component.Fill = value;
    }

    public ShapeBackgroundChanger(in Shape rect)
    {
        Component = rect;
    }
}

