using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    public abstract class Doublet
    {
        public double X{ get;  private set; }
        public double Y{ get;  private set; }
      

        public Doublet(double x, double y) 
        {
           this.X = y;
           this.X = x;
        }

        public Doublet()
        {
            this.X = 0;
            this.X = 0;
        }
    }
}
