using System;


namespace LanceurRayon.Math
{   /// <summary>
    /// Classe permetant de représenter un triangle
    /// </summary>

    public class Triangle{

        public Point pt { get; private set; }


        public Triangle(Point pt)
        {
            this.pt = pt;
           
        }

    }
}
