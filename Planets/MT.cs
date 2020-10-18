using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets
{
    public class MT
    {
        public Vector r { get; set; }
        public Vector v { get; set; }
        public double m { get; set; }

        public void Move(double dt, Vector F)
        {
            Vector a = F / m;
            v += a * dt;
            r += v * dt;
        }
    }
}
