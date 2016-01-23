using System;

namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe représentant un point par ses coordonnées dans l'espace
    /// et permettant d'effectuer quelques calculs
    /// </summary>
    public class Point : Triplet
    {
        /// <summary>
        /// Permet d'obtenir le point origine
        /// </summary>
        public Point() : base()
        { }
        
        /// <summary>
        /// Permet de construire un point à partir de coordonnées
        /// </summary>
        /// <param name="x">Position en X</param>
        /// <param name="y">Position en Y</param>
        /// <param name="z">Position en Z</param>
        public Point(double x, double y, double z) : base(x, y, z)
        { }

        /// <summary>
        /// Permet de créer l'image de la translation d'un point par rapport à un vecteur
        /// </summary>
        /// <param name="v">Le vecteur à utiliser pour la translation</param>
        /// <returns>Le point translaté</returns>
        public Point add(Vec3 v)
        {
            if (v == null)
                throw new ArgumentNullException();
            return new Point(this.X + v.X, this.Y + v.Y, this.Z + v.Z);
        }

        /// <summary>
        /// Permet de calculer la distance par rapport à un autre point
        /// </summary>
        /// <param name="p">Le point dont on souhaite connaitre la distance par rapport à l'objet courant</param>
        /// <returns>La distance entre le point courant et celui passé en paramètre</returns>
        public Vec3 sub(Point p)
        {
            if (p == null)
                throw new ArgumentNullException();
            return new Vec3(this.X - p.X, this.Y - p.Y, this.Z - p.Z);
        }

        /// <summary>
        /// Permet de multiplier le point par un scalaire
        /// </summary>
        /// <param name="scal">Le scalaire</param>
        /// <returns>Le point ayant subit la multiplication par le scalaire</returns>
        public Point mul(double scal)
        {
            return new Point(this.X * scal, this.Y * scal, this.Z * scal);
        }

        /// <summary>
        /// Permet d'afficher de façon formater les coordonnées d'un point
        /// </summary>
        /// <returns>Une chaine formaté de la manière suivante : P x y z</returns>
        public override string ToString()
        {
            return string.Format("P {0} {1} {2}", this.X.ToString("0.0"), this.Y.ToString("0.0"), this.Z.ToString("0.0"));
        }
    }
}
