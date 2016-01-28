using System;


namespace LanceurRayon.Math
{/// <summary>
 /// Classe permetant de représenter une sphère.
 /// </summary>
    public class Sphere{

        public Math.Color Specular { get; private set; }
        public Math.Color Ambient { get; private set; }
        public Math.Color Diffuse { get; private set; }
        public Point centre{ get; private set; }  
        public double rayon{ get; private set; }


        public Sphere(Point centre, double rayon, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse)
        {
            this.Ambient = Ambient;
            this.Specular = Specular;
            this.Diffuse = Diffuse;
            this.centre = centre;
            this.rayon = rayon;
        }
       

    }
}
