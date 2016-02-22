using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{
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
        /// <param name="ray">Le rayon</param>
        /// <param name="eye">L'origine du rayon</param>
        /// <returns>Le discriminant de l'intersection ou null si pas d'intersection</returns>
        public abstract double? Collide(Vec3 ray, Point eye);

        /// <summary>
        /// Calcule la normale d'un point d'intersection
        /// </summary>
        /// <param name="rayon">Le vecteur entrainant un point de collision dont on souhaite la normal</param>
        /// <param name="discriminant"></param>
        /// <param name="eye"></param>
        /// <returns>LA normal du point d'intersection</returns>
        public abstract Vec3 getNormaleIntersection(Vec3 rayon, double discriminant, Point eye);
    }
}
