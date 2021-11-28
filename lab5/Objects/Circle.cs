using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace lab5.Objects
{
    class Circle : BaseObject
    {
        private int SizeSleep = 0;
        public int Size = 40;
        public Action SizeIsZero;
        public Circle(float x, float y, float angle, int id) : base(x, y, angle, id)
        {
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-(Size/2), -(Size/2), Size, Size);
            return path;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), -(Size/2), -(Size/2), Size, Size);
        }

        public void SizeChange()
        {
            SizeSleep++;
            if(SizeSleep == 5)
            {
                SizeSleep = 0;
                Size--;
            }
            if(Size <= 0)
            {
                if(SizeIsZero != null)
                {
                    SizeIsZero();
                }
            }
        }
    }
}
