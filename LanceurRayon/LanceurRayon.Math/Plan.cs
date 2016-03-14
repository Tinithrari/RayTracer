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
        public Point Q { get; private set; }

        /// <summary>
        /// Vecteur normal au plan.
        /// </summary>
        public Vec3 N { get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Q">Point décrivant un plan.</param>
        /// <param name="N">Vecteur normal au plan.</param>
        /// <param name="Specular">Reflêt</param>
        /// <param name="Ambient">Lumière ambiante</param>
        /// <param name="Diffuse">Lumière diffuse</param>
        /// <param name="Brillance">Brillance de la scène.</param> 
        public Plan(Point Q,Vec3 N, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse, double Brillance)
        {
            this.Q = Q;
            this.N = N;
            this.Ambient = Ambient;
            this.Specular = Specular;
            this.Diffuse = Diffuse;
            this.Brillance = Brillance;
        }

        /// <summary>
        /// Detecte si le rayon entre en collision avec l'objet
        /// </summary>
        /// <param name="d">Le rayon</param>
        /// <param name="o">L'origine du rayon</param>
        /// <returns>Le discriminant de l'intersection ou null si pas d'intersection</returns>
        public override Intersection Collide(Vec3 d, Point o)
        {
            double numerateur = (Q.sub(o)).dot(N);
            double denominateur = d.dot(N);

            return denominateur == 0d ? null : new Intersection(numerateur / denominateur, this);
        }

        /// <summary>
        /// Calcul l'intersection entre le rayon et la normale au plan. 
        /// </summary>
        /// <param name="p">Le point décrivant le Pla</param>
        /// <returns>Le vecteur normale à l'intersection</returns>
        public override Vec3 getNormaleIntersection(Point p)
        {
            return N;
        }
    }
}
