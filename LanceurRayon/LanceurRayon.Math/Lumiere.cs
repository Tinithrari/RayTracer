namespace LanceurRayon.Math
{/// <summary>
 /// Classe permetant de représenter une lumière.
 /// </summary>
    public class Lumiere
    {

      
        public Vec3  direction{ get; private set; }
        public Color couleur{ get; private set; }

        public Lumiere(Vec3 direction, Color couleur)
        {
            this.direction = direction;
            this.couleur = couleur;

        }

    }
}
