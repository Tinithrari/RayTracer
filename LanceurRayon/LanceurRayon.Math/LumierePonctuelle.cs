using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{/// <summary>
 /// Source de lumière ponctuelle.
 /// </summary>
    public class LumierePonctuelle : Lumiere
    {

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Position">Vecteur désignant la direction.</param>
        /// <param name="Couleur">Couleur de la lumière.</param>
        public LumierePonctuelle(Color Couleur, Point Position) : base(Couleur, Position)
        {

        }

        /// <summary>
        /// Calcule le vecteur direction de la lumière
        /// </summary>
        /// <param name="p">Le poin t pour lequel on calcule le vecteur direction</param>
        /// <returns>Le vecteur direction correspondant à cette lumière</returns>
        public override Vec3 getDirection(Point p)
        {
            throw new NotImplementedException();
        }
    }
}
