using System;


namespace LanceurRayon.Math
{   /// <summary>
    /// Classe permetant de représenter un triangle
    /// </summary>

    public class Triangle{

        public Math.Color Specular { get; private set; }
        public Math.Color Ambient { get; private set; }
        public Math.Color Diffuse { get; private set; }
        public Point pt { get; private set; }


        public Triangle(Point pt, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse)
        {
            this.pt = pt;
            this.Ambient = Ambient;
            this.Specular = Specular;
            this.Diffuse = Diffuse;
        }

    }
}
