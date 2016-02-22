using System;

namespace LanceurRayon.Math
{/// <summary>
 /// Classe permetant de représenter une lumière directionelle.
 /// </summary>
    public class LumiereDirectionelle :Lumiere
    {

        public Vec3 Direction { get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Position">Vecteur désignant la direction.</param>
        /// <param name="Couleur">Couleur de la lumière.</param>
        public LumiereDirectionelle(Color Couleur, Vec3 Direction) : base(Couleur)
        {
            this.Direction = Direction;
        }

        /// <summary>
        /// Calcule le vecteur direction de la lumière
        /// </summary>
        /// <param name="p">Le poin t pour lequel on calcule le vecteur direction</param>
        /// <returns>Le vecteur direction correspondant à cette lumière</returns>
        public override Vec3 getDirection(Point p)
        {
            return this.Direction;
        }
    }
}
