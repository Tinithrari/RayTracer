using System;

namespace LanceurRayon.Math
{/// <summary>
 /// Classe permetant de représenter une lumière directionelle.
 /// </summary>
    public class LumiereDirectionelle :Lumiere
    {

        /// <summary>
        /// Vecteur décrivant la direction des rayons lumineux émanant de la source.
        /// </summary>
        public Vec3 Direction { get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Direction">Vecteur désignant la direction.</param>
        /// <param name="Couleur">Couleur de la lumière.</param>
        public LumiereDirectionelle(Color Couleur, Vec3 Direction) : base(Couleur)
        {
            this.Direction = Direction.norm();
        }

        /// <summary>
        /// Calcule le vecteur direction de la lumière
        /// </summary>
        /// <param name="p">Le point pour lequel on calcule le vecteur direction</param>
        /// <returns>Le vecteur direction correspondant à cette lumière</returns>
        public override Vec3 getDirection(Point p)
        {
            return this.Direction;
        }

        public override double getDistance(Point p)
        {
            return double.PositiveInfinity;
        }
    }
}
