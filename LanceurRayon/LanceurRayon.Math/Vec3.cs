using System;
using System.Globalization;

namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe représentant un vecteur dans un repère tridimensionnel
    /// </summary>
    public class Vec3 : Triplet
    {
        /// <summary>
        /// Permet de créer un vecteur nul
        /// </summary>
        public Vec3() : base() { }

        /// <summary>
        /// Permet de créer un vecteur tridimensionnel à partir de ses coordonnées
        /// </summary>
        /// <param name="x">Sa position en X</param>
        /// <param name="y">Sa position en Y</param>
        /// <param name="z">Sa position en Z</param>
        public Vec3(double x, double y, double z) : base(x, y, z) { }

        /// <summary>
        /// Permet de créer un Vec3 à partir de coordonnées
        /// </summary>
        /// <param name="x">Coordonnées en x</param>
        /// <param name="y">Coordonnées en y</param>
        /// <param name="z">Coordonnées en z</param>
        /// <returns>Le Vec3 correspondant à la description données en paramètre</returns>
        public static Vec3 createVec3(string x, string y, string z)
        {
            try {
                return new Vec3(double.Parse(x, CultureInfo.InvariantCulture), double.Parse(y, CultureInfo.InvariantCulture), double.Parse(z, CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Permet d'additioner deux vecteurs 
        /// </summary>
        /// <param name="v">Le vecteur à additioner aux vecteurs courants</param>
        /// <returns>Le vecteur résultant de l'opération</returns>
        public Vec3 add(Vec3 v)
        {
            if (v == null)
                throw new ArgumentNullException();
            return new Vec3(this.X + v.X, this.Y + v.Y, this.Z + v.Z);
        }

        /// <summary>
        /// Permet de soustraire deux vecteurs
        /// </summary>
        /// <param name="v">Le vecteur à soustraire aux vecteurs courant</param>
        /// <returns>Le vecteur résultant de la soustraction</returns>
        public Vec3 sub(Vec3 v)
        {
            if (v == null)
                throw new ArgumentNullException();
            return new Vec3(this.X - v.X, this.Y - v.Y, this.Z - v.Z);
        }

        /// <summary>
        /// Permet de faire la multiplication d'un vecteur avec un scalaire
        /// </summary>
        /// <param name="scal">Le scalaire pour la multiplication</param>
        /// <returns>Le résultat du produit par le scalaire scal</returns>
        public Vec3 mul(Double scal)
        {
            return new Vec3(this.X * scal, this.Y * scal, this.Z * scal);
        }

        /// <summary>
        /// Permet d'effectuer un produit scalaire
        /// </summary>
        /// <param name="v">Le vecteur à multiplier au vecteur courant</param>
        /// <returns>Le résultat du produit scalaire</returns>
        public Double dot(Vec3 v)
        {
            if (v == null)
                throw new ArgumentNullException();
            return (this.X * v.X) + (this.Y * v.Y) + (this.Z * v.Z);
        }

        /// <summary>
        /// Permet d'effectuer un produit vectoriel
        /// </summary>
        /// <param name="v">Le vecteur à multiplier au vecteur courant</param>
        /// <returns>Le résultat du produit vectoriel</returns>
        public Vec3 cross(Vec3 v)
        {
            if (v == null)
                throw new ArgumentNullException();
            return new Vec3( (this.Y * v.Z) - (this.Z * v.Y), (this.Z * v.X) - (this.X * v.Z), (this.X * v.Y) - (this.Y * v.X));
        }

        /// <summary>
        /// Permet de calculer la norme du vecteur
        /// </summary>
        /// <returns>La norme du vecteur courant</returns>
        public double length()
        {
            return System.Math.Sqrt( System.Math.Pow(this.X, 2) + System.Math.Pow(this.Y, 2) + System.Math.Pow(this.Z, 2) );
        }

        /// <summary>
        /// Permet de normaliser le vecteur courant
        /// </summary>
        /// <returns>Le vecteur normaliser</returns>
        public Vec3 norm()
        {
            double len = this.length();

            return this.mul(1/len);
        }

        /// <summary>
        /// Permet de créer une chaine pour représenter le vecteur
        /// </summary>
        /// <returns>Une chaine formatée de la forme V x y z</returns>
        public override string ToString()
        {
            return string.Format("V {0} {1} {2}", this.X.ToString("0.0#", CultureInfo.InvariantCulture), this.Y.ToString("0.0#", CultureInfo.InvariantCulture), this.Z.ToString("0.0#", CultureInfo.InvariantCulture));
        }
    }
}
