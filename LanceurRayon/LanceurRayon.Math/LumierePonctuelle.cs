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

    }
}
