using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    /// <summary>
    /// Objet décrivant l'intersection entre le rayon et l'entité touché.
    /// </summary>
    public class Intersection
    {
        /// <summary>
        ///Entier décrivant la distance de l'intersection au rayon, on peut en déduire le point en faisaint p=o+d*t 
        /// </summary>
        public double T { get;  set; }
        
        /// <summary>
        ///Entité géométrique concerné par l'intersection( triangle, sphère ,etc).
        /// </summary>
        public VisualEntity Obj { get; private set; }
      
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="t">Distance d'intersection.</param>
        /// <param name="obj">Nature de l'intersection.</param>
        public Intersection(double t, VisualEntity obj)
        {
            T = t;
            Obj = obj;
        }
    }
}
