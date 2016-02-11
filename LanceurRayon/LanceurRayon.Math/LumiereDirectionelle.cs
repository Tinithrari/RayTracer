namespace LanceurRayon.Math
{/// <summary>
 /// Classe permetant de représenter une lumière directionelle.
 /// </summary>
    public class LumiereDirectionelle :Lumiere
    {

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Position">Vecteur désignant la direction.</param>
        /// <param name="Couleur">Couleur de la lumière.</param>
        public LumiereDirectionelle(Color Couleur,Point Position) : base(Couleur, Position)
        {
         

        }

    }
}
