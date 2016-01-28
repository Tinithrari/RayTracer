using System;


namespace LanceurRayon.Math
{/// <summary>
 /// Classe permetant de représenter une sphère.
 /// </summary>
    public class Sphere{

        public Point centre{ get; private set; }  
        public double rayon{ get; private set; }


        public Sphere(Point centre, double rayon)
        {

            this.centre = centre;
            this.rayon = rayon;
        }
       

    }
}
