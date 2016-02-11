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
        /// Position de l'objet.
        /// </summary>
        public Point Position { get; protected set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public Lumiere(Color Couleur, Point Position)
        {
            this.Couleur = Couleur;
            this.Position = Position;
        }
    }
}
