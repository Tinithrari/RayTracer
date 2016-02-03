using System;


namespace LanceurRayon.Math
{   
    /// <summary>
    /// Classe permetant de représenter un triangle
    /// </summary>
    public class Triangle{
       
        /// <summary>
        /// Reflêt
        /// </summary>
        public Math.Color Specular { get; private set; }
        
        /// <summary>
        /// Lumière ambiante
        /// </summary>
        public Math.Color Ambient { get; private set; }
        
        /// <summary>
        /// Lumière diffuse
        /// </summary>
        public Math.Color Diffuse { get; private set; }
        
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
        public Triangle(Point Pt, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse)
        {
            this.Pt = Pt;
            this.Ambient = Ambient;
            this.Specular = Specular;
            this.Diffuse = Diffuse;
        }

    }
}
