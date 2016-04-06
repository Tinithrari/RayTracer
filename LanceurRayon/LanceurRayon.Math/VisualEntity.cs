using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe abstraite permetant de regroupés les entités géométriques tels que les triangles, les sphères ou les plans.
    /// </summary>
    public abstract class VisualEntity
    {
        /// <summary>
        /// Coefficient de brillance de la scène.
        /// </summary>
        public double Brillance { get; protected set; }

        /// <summary>
        /// Reflêt.
        /// </summary>
        public Math.Color Specular { get; protected set; }

        /// <summary>
        /// Lumière ambiante.
        /// </summary>
        public Math.Color Ambient { get; protected set; }

        /// <summary>
        /// Lumière diffuse
        /// </summary>
        public Math.Color Diffuse { get; protected set; }

        /// <summary>
        /// Detecte si le rayon entre en collision avec l'objet
        /// </summary>
        /// <param name="d">Le rayon</param>
        /// <param name="o">L'origine du rayon</param>
        /// <returns>Le discriminant de l'intersection ou null si pas d'intersection</returns>
        public abstract Intersection Collide(Vec3 d, Point o);

        /// <summary>
        /// Calcule la normale d'un point d'intersection
        /// </summary>
        /// <param name="p">Le point de collisition dont on souhaite connaitre la normale</param>
        /// <returns>LA normal du point d'intersection</returns>
        public abstract Vec3 getNormaleIntersection(Point p);

      
    }
}
