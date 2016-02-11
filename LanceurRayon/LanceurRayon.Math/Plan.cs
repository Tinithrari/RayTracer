using System;

namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe décrivant un plan .
    /// </summary>
    public class Plan : VisualEntity
    {

        /// <summary>
        /// Point décrivant un plan.
        /// </summary>
        public Point Pt { get; private set; }

        /// <summary>
        /// Vecteur normal au plan.
        /// </summary>
        public Vec3 Vecteur_normal { get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Pt">Point décrivant un plan.</param>
        /// <param name="Vecteur_normal">Vecteur normal au plan.</param>
        public Plan(Point Pt,Vec3 Vecteur_normal)
        {
            this.Pt = Pt;
            this.Vecteur_normal = Vecteur_normal;
          
        }

        /// <summary>
        /// Detecte si le rayon entre en collision avec l'objet
        /// </summary>
        /// <param name="ray">Le rayon</param>
        /// <param name="eye">L'origine du rayon</param>
        /// <returns>Le discriminant de l'intersection ou null si pas d'intersection</returns>
        public override double? Collide(Vec3 ray, Point eye)
        {
            throw new NotImplementedException();
        }
    }
}
