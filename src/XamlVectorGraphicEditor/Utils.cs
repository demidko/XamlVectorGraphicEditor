using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

static class Utils
{
    public static void AddPaletteHeader(this ContextMenu root, IBackgroundChanger changer, in string header = "Палитра")
    {
        var palette = new MenuItem()
        {
            Header = header
            
        };
        
        foreach (var inf in typeof(Brushes).GetProperties(BindingFlags.Static | BindingFlags.Public))
        {
            var brush = inf.GetValue(null) as SolidColorBrush;
            var item = new MenuItem()
            {
                Icon = new Ellipse()
                {
                    Fill = brush
                },
                Header = inf.Name
            };
            item.Click += (o, e) => changer.Background = brush;
            palette.Items.Add(item);
        }
        
        root.Items.Insert(0, palette);
        
    }
}
