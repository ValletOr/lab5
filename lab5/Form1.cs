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
        Random rand = new Random();
        Player player;
        Target target;
        Circle circle;
        Circle circle2;
        public int points = 0;
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
            player.OnCircleOverlap += (c) =>
            {
                points++;
                if (c.Id == 0) circle = null;
                else if (c.Id == 1) circle2 = null;
                objectList.Remove(c);
                c = null;
            };
            target = new Target(pictureBox.Width / 2 + 100, pictureBox.Height / 2 + 100, 0);
            circle = new Circle(rand.Next(pictureBox.Width), rand.Next(pictureBox.Height), 0, 0);
            circle2 = new Circle(rand.Next(pictureBox.Width), rand.Next(pictureBox.Height), 0, 1);
            
            circle.SizeIsZero += () =>
            {
                objectList.Remove(circle);
                circle = null;
            };
            circle2.SizeIsZero += () =>
            {
                objectList.Remove(circle2);
                circle2 = null;
            };

            objectList.Add(player);
            objectList.Add(target);
            objectList.Add(circle);
            objectList.Add(circle2);

            UpdatePoints();
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            UpdatePlayer();
            UpdateCircles();
            UpdatePoints();

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

        public void UpdatePlayer()
        {
            if (target != null)
            {
                float dx = target.X - player.X;
                float dy = target.Y - player.Y;

                float length = (float)Math.Sqrt((dx * dx) + (dy * dy));
                dx /= length;
                dy /= length;

                player.vX = dx * 3.5f;
                player.vY = dy * 3.5f;

                player.Angle = 90f - (float)Math.Atan2(player.vX, player.vY) * 180f / (float)Math.PI;
            }
            player.vX -= player.vX * 0.1f;
            player.vY -= player.vY * 0.1f;

            player.X += player.vX;
            player.Y += player.vY;
        }

        public void UpdateCircles()
        {
            if(circle == null)
            {
                circle = new Circle(rand.Next(pictureBox.Width), rand.Next(pictureBox.Height), 0, 0);
                circle.SizeIsZero += () =>
                {
                    objectList.Remove(circle);
                    circle = null;
                };
                objectList.Add(circle);
            }
            else
            {
                circle.SizeChange();
            }

            if (circle2 == null)
            {
                circle2 = new Circle(rand.Next(pictureBox.Width), rand.Next(pictureBox.Height), 0, 1);
                circle2.SizeIsZero += () =>
                {
                    objectList.Remove(circle2);
                    circle2 = null;
                };
                objectList.Add(circle2);
            }
            else
            {
                circle2.SizeChange();
            }
        }

        public void UpdatePoints()
        {
            pointsCounter.Text = $"Points: {points}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }
    }
}
