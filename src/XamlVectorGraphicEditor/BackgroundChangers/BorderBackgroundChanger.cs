using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

class BorderBackgroundChanger : IBackgroundChanger
{
    private readonly Border Component;

    public Brush Background
    {
        get => Component.BorderBrush;
        set => Component.BorderBrush = value;
    }

    public BorderBackgroundChanger(in Border b)
    {
        Component = b;
    }
}

