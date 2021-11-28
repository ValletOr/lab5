using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace lab5.Objects
{
    class Target : BaseObject
    {
        public Target(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-2, -2, 2, 2);
            return path;
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Red, 2), -10, -10, 20, 20);
            g.DrawLine(new Pen(Color.Red), -15, 0, 15, 0);
            g.DrawLine(new Pen(Color.Red), 0, -15, 0, 15);
        }
    }
}
