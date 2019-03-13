using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

class MyEllipse : AbstractShape
{
    public MyEllipse(in Point p) : base(p, new Ellipse() { Fill = Brushes.LightCoral })
    {

    }
}

