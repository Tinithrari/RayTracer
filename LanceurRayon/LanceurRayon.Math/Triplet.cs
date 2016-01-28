namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe abstraites pour les éléments contenants un triplet de valeurs
    /// </summary>
    public abstract class Triplet
    {
        /// <summary>
        /// Accesseur pour la coordonnée X du triplet
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// Accesseur pour la coordonnée Y du triplet
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// Accesseur pour la coordonnée Z du triplet
        /// </summary>
        public double Z { get; private set; }

        /// <summary>
        /// Permet de construire un triplet à l'aide de trois valeurs
        /// </summary>
        /// <param name="x">Valeur x du triplet</param>
        /// <param name="y">Valeur y du triplet</param>
        /// <param name="z">Valeur z du triplet</param>
        public Triplet(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Permet de construire un triplet ayant toute coordonnées à zéro
        /// </summary>
        public Triplet() : this(0,0,0)
        {}
    }
}
