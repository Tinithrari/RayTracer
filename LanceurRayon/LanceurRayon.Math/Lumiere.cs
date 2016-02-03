namespace LanceurRayon.Math
{/// <summary>
 /// Classe permetant de représenter une lumière.
 /// </summary>
    public class Lumiere
    {

      /// <summary>
      /// Vecteur désignant la direction.
      /// </summary>
      public Vec3  Direction{ get; private set; }

      /// <summary>
      /// Couleur de la lumière.
      /// </summary>
      public Color Couleur{ get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Direction">Vecteur désignant la direction.</param>
        /// <param name="Couleur">Couleur de la lumière.</param>
        public Lumiere(Vec3 Direction, Color Couleur)
        {
            this.Direction = Direction;
            this.Couleur = Couleur;

        }

    }
}
