using System.Windows.Controls;
using System.Windows.Media;

struct PanelBackgroundChanger : IBackgroundChanger
{
    private readonly Panel MyPanel;

    public Brush Background
    {
        get => MyPanel.Background;
        set => MyPanel.Background = value;
    }

    public PanelBackgroundChanger(in Panel panel)
    {
        MyPanel = panel;
    }
}
