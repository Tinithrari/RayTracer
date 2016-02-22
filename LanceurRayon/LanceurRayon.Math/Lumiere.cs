using System;

namespace LanceurRayon.Math
{/// <summary>
 /// Classe/Interface permetant de représenter une lumière.
 /// </summary>
    public abstract class Lumiere
    {
        /// <summary>
        /// Couleur de la source de lumière.
        /// </summary>
        public Math.Color Couleur { get; protected set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public Lumiere(Color Couleur)
        {
            this.Couleur = Couleur;
        }

        /// <summary>
        /// Calcule le vecteur direction de la lumière
        /// </summary>
        /// <param name="p">Le point pour lequel on calcule le vecteur direction</param>
        /// <returns>Le vecteur direction correspondant à cette lumière</returns>
        public abstract Vec3 getDirection(Point p);
    }
}
