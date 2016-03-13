using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{   /// <summary>
    /// Vecteur de dimension quatre.
    /// </summary>
    public class Vec4 : Vec3
    {
        /// <summary>
        /// Quatrième coordonnée du vecteur
        /// </summary>
        public double T { get; set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="x">Abscice</param>
        /// <param name="y">Ordonnée</param>
        /// <param name="z">Côte</param>
        /// <param name="T">4 ème coordonnée</param>
        public Vec4(double x, double y, double z, double T) :base(x,y,z){

            this.T = T;
        }

        /// <summary>
        /// Addition de deux vecteurs.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Vec4 résultant de l'opération</returns>
        public Vec4 add(Vec4 v) {
            if (v == null)
                throw new ArgumentNullException();
            return new Vec4((double)(this.X + v.X), (double)(this.Y + v.Y), (double)(this.Z + v.Z), (double)(this.T + v.T));
        }

        /// <summary>
        /// Soustraction de 2 vecteurs
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Vec4 résultant de l'opération</returns>
        public Vec4 sub(Vec4 v)
        {
            if (v == null)
                throw new ArgumentNullException();
            return new Vec4((double)(this.X - v.X), (double)(this.Y - v.Y), (double)(this.Z - v.Z), (double)(this.T - v.T));
        }

    }
}
