using System;


namespace LanceurRayon.Math
{
    public class Triangle{
        public double x { get; private set; }
        public double y { get; private set; }
        public double z { get; private set; }
     

        public Triangle(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

    }
}
