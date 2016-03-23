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
        /// Position dans l'espace de la source de lumière ponctuelle.
        /// </summary>
        public Point Position { get; private set; }
        
        
        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Position">Vecteur désignant la direction.</param>
        /// <param name="Couleur">Couleur de la lumière.</param>
        public LumierePonctuelle(Color Couleur, Point Position) : base(Couleur)
        {
            this.Position = Position;
        }

        /// <summary>
        /// Calcule le vecteur direction de la lumière
        /// </summary>
        /// <param name="p">Le point pour lequel on calcule le vecteur direction</param>
        /// <returns>Le vecteur direction correspondant à cette lumière</returns>
        public override Vec3 getDirection(Point p)
        {
            return Position.sub(p).norm();
        }


        /// <summary>
        /// Permet d'obtenir la distance au point d'intersection.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>La distance au point d'intersection.</returns>
        public override double getDistance(Point p)
        {
            return Position.sub(p).length(); 
        }
    }
}
