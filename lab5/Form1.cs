using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab5.Objects;

namespace lab5
{
    public partial class Form1 : Form
    { 
        List<BaseObject> objectList = new List<BaseObject>();
        Player player;
        Target target;
        public Form1() 
        {
            InitializeComponent();
            player = new Player(pictureBox.Width / 2, pictureBox.Height / 2, 0);
            player.OnOverlap += (p, obj) =>
            {
                LogBox.Text = $"[{DateTime.Now:HH:mm:ss:ff}] {p} пересёкся с {obj}\n" + LogBox.Text;
            };
            player.OnTargetOverlap += (t) =>
            {
                objectList.Remove(t);
                target = null;
            };
            target = new Target(pictureBox.Width / 2 + 100, pictureBox.Height / 2 + 100, 0);
            objectList.Add(target);
            objectList.Add(player);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            foreach (var obj in objectList.ToList())
            {
                if ((obj != player) && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }

            foreach (var obj in objectList.ToList())
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (target == null)
            {
                target = new Target(0, 0, 0);
                objectList.Add(target);
            }
            target.X = e.X;
            target.Y = e.Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (target != null)
            {
                float dx = target.X - player.X;
                float dy = target.Y - player.Y;

                float length = (float)Math.Sqrt((dx * dx) + (dy * dy));
                dx /= length;
                dy /= length;

                player.X += dx * 2;
                player.Y += dy * 2;
            }

            pictureBox.Invalidate();
        }
    }
}
