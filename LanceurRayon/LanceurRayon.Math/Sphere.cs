using System;


namespace LanceurRayon.Math
{
 /// <summary>
 /// Classe permetant de représenter une sphère.
 /// </summary>
    public class Sphere{
        /// <summary>
        /// Reflêt.
        /// </summary>
        public Math.Color Specular { get; private set; }

        /// <summary>
        /// Lumière ambiante.
        /// </summary>
        public Math.Color Ambient { get; private set; }

        /// <summary>
        /// Lumière diffuse
        /// </summary>
        public Math.Color Diffuse { get; private set; }

        /// <summary>
        /// Centre de la sphère.
        /// </summary>
        public Point Centre{ get; private set; }

        /// <summary>
        /// Rayon de la sphère.
        /// </summary>
        public double Rayon{ get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Centre">Centre de la sphère</param>
        /// <param name="Rayon">Rayon de la sphère.</param>
        /// <param name="Specular">Reflêt.</param>
        /// <param name="Ambient">Lumière ambiante.</param>
        /// <param name="Diffuse">Lumière diffuse.</param>
        public Sphere(Point Centre, double Rayon, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse)
        {
            this.Ambient = Ambient;
            this.Specular = Specular;
            this.Diffuse = Diffuse;
            this.Centre = Centre;
            this.Rayon = Rayon;
        }
       

    }
}
