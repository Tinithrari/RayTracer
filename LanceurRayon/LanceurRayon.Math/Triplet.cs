namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe abstraites pour les éléments contenants un triplet de valeurs
    /// </summary>
    public abstract class Triplet
    {
        private double x;
        private double y;
        private double z;

        /// <summary>
        /// Permet de construire un triplet à l'aide de trois valeurs
        /// </summary>
        /// <param name="x">Valeur x du triplet</param>
        /// <param name="y">Valeur y du triplet</param>
        /// <param name="z">Valeur z du triplet</param>
        public Triplet(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Permet de construire un triplet ayant toute coordonnées à zéro
        /// </summary>
        public Triplet() : this(0,0,0)
        {}

        /// <summary>
        /// Valeur x du triplet
        /// </summary>
        public double X
        {
            get
            {
                return x;
            }
        }

        /// <summary>
        /// Valeur y du triplet
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
        }

        /// <summary>
        /// Valeur z du triplet
        /// </summary>
        public double Z
        {
            get
            {
                return z;
            }
        }
    }
}
