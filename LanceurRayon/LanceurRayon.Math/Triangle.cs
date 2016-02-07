using System;


namespace LanceurRayon.Math
{   
    /// <summary>
    /// Classe permetant de représenter un triangle
    /// </summary>
    public class Triangle : VisualEntity{
        
        /// <summary>
        /// Centre d'un triangle
        /// </summary>
        public Point Pt { get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Pt">Centre de gravité du triangle</param>
        /// <param name="Specular">Reflêt</param>
        /// <param name="Ambient">Lumière ambiante</param>
        /// <param name="Diffuse">Lumière diffuse</param>
        /// <param name="Brillance">Brillance de la scène.</param> 
        public Triangle(Point Pt, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse,double Brillance)
        {
            this.Pt = Pt;
            this.Ambient = Ambient;
            this.Specular = Specular;
            this.Diffuse = Diffuse;
            this.Brillance = Brillance;
        }

        public override double? Collide(Vec3 ray, Point eye)
        {
            throw new NotImplementedException();
        }
    }
}
