using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planets
{
    public partial class Form1 : Form
    {
        MT earth, moon;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double dt = timer1.Interval / 1000.0 * 300000;

            Vector m_e = earth.r - moon.r;
            double r3 = Math.Pow(m_e.Abs, 3);
            Vector Fe = -6.67e-29 * moon.m * earth.m * m_e / r3;
            Vector Fm = -Fe;

            moon.Move(dt, Fm);
            earth.Move(dt, Fe);

            pictureBox1.Location = new Point((int)earth.r.X, (int)earth.r.Y);
            pictureBox2.Location = new Point((int)moon.r.X, (int)moon.r.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            earth = new MT() { m = 6e+24, v = new Vector(), r = new Vector(pictureBox1.Left, pictureBox1.Top) };
            moon = new MT() { m = 7e+22, v = new Vector(0.0018,0), r = new Vector(pictureBox2.Left, pictureBox2.Top) };

            timer1.Start();
        }
    }
}
