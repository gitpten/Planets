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
        MT sun, earth, vines, merc, mars;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double dt = 86400 * 2;

            Vector FEarth = GetF(earth, sun);
            Vector FMerc = GetF(merc, sun);
            Vector FVines = GetF(vines, sun);
            Vector FMars = GetF(mars, sun);
            Vector FSun = -FEarth - FMerc - FVines - FMars;

            earth.Move(dt, FEarth);
            merc.Move(dt, FMerc);
            vines.Move(dt, FVines);
            mars.Move(dt, FMars);
            sun.Move(dt, FSun);

            pictureBox1.Location = GetLocation(sun.r);
            pictureBox2.Location = GetLocation(earth.r);
            pictureBox3.Location = GetLocation(merc.r);
            pictureBox4.Location = GetLocation(vines.r);
            pictureBox5.Location = GetLocation(mars.r);
        }

        private Vector GetF(MT mt1, MT sun)
        {
            Vector fromSunToEarth = mt1.r - sun.r;
            double r3 = Math.Pow(fromSunToEarth.Abs, 3);
            return -6.67e-11 * mt1.m * sun.m * fromSunToEarth / r3;            
        }

        private Point GetLocation(Vector r)
        {
            return new Point((int)(r.X / 0.8e+9) + 600, (int)(r.Y / 0.8e+9) + 400);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sun = new MT() { m = 1.9885e+30, v = new Vector(), r = new Vector(0, 0) };
            earth = new MT() { m = 5.9726e+24, v = new Vector(29783,0), r = new Vector(0, 1.5e+11) };
            merc = new MT() { m = 3.3e+23, v = new Vector(47360,0), r = new Vector(0,5.79e+10) };
            vines = new MT() { m = 4.8675e+24, v = new Vector(35020, 0), r = new Vector(0, 1.08e+11) };
            mars = new MT() { m = 6.4171e+23, v = new Vector(24130, 0), r = new Vector(0, 2.2e+11) };

            timer1.Start();
        }
    }
}
