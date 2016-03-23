
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    /// <summary>
    /// Modélisation d'un vecteur en dimension quatre.
    /// </summary>
    public abstract class Quadruplet : Triplet
    {
        /// <summary>
        /// Quatrième composante
        /// </summary>
        public double T { get; private  set; }
     
        
        /// <summary>
        /// Construit un vecteur à quatre coordonées
        /// </summary>
        /// <param name="x">Abscice</param>
        /// <param name="y">Ordonnée</param>
        /// <param name="z">Côte</param>
        /// <param name="t">Quatrième coordonnée</param>
        public Quadruplet(double x, double y, double z,double t) : base(x,y,z)
        {
            this.T = t;

        }

        /// <summary>
        /// Construit un vecteur nul à quatre variables.
        /// </summary>
        public Quadruplet() : this(0,0,0,0) {

          
        }
    }
}
