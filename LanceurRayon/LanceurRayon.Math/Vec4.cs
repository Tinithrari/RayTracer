using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    public class Vec4 : Vec3
    {

        public double T { get; set; }

        public Vec4(double x, double y, double z, double T) :base(x,y,z){

            this.T = T;
        }

        public Vec4 add(Vec4 v) {
            if (v == null)
                throw new ArgumentNullException();
            return new Vec4((double)(this.X + v.X), (double)(this.Y + v.Y), (double)(this.Z + v.Z), (double)(this.T + v.T));
        }

        public Vec4 sub(Vec4 v)
        {
            if (v == null)
                throw new ArgumentNullException();
            return new Vec4((double)(this.X - v.X), (double)(this.Y - v.Y), (double)(this.Z - v.Z), (double)(this.T - v.T));
        }

    }
}
