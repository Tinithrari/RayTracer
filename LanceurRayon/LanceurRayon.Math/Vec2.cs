using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    public class Vec2 : Doublet
    {
        public Vec2() : base() {
            
        }

         public Vec2(double x,double y) : base(x,y)
         {
         
         }

        public Double dot(Vec2 v)
        {
            if (v == null)
                throw new ArgumentNullException();
            return (this.X * v.X) + (this.Y * v.Y);
        }

    }
}
