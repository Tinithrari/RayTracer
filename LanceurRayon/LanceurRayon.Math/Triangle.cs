namespace LanceurRayon.Math
{
    /// <summary>
    /// Classe permetant de représenter un triangle
    /// </summary>
    public class Triangle : VisualEntity{
        
        /// <summary>
        /// Coordonnées du point A
        /// </summary>
        public Point A { get; private set; }

        /// <summary>
        /// Coordonnées du point B
        /// </summary>
        public Point B { get; private set; }
        
        /// <summary>
        /// Coordonnées du point C
        /// </summary>
        public Point C { get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Specular">Reflêt</param>
        /// <param name="Ambient">Lumière ambiante</param>
        /// <param name="Diffuse">Lumière diffuse</param>
        /// <param name="Brillance">Brillance de la scène.</param>
        /// <param name="A">Coordonnées du point A</param>
        /// <param name="B">Coordonnées du point B</param>
        /// <param name="C">Coordonnées du point C</param>
        public Triangle(Point A, Point B, Point C, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse,double Brillance)
        {
            this.A = A;
            this.B = B;
            this.C = C;
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
            Vec3 n = getNormaleIntersection(null);
            Intersection intersectionPlan;
            bool a, b, c;
            Plan plan = new Plan(C, n, Specular, Ambient, Diffuse, Brillance);
            Point p;

            intersectionPlan = plan.Collide(d, o);

            if (intersectionPlan == null)
                return null;

            p = o.add( (d.mul(intersectionPlan.T)) );

            a = ( ( B.sub(A) ).cross( ( p.sub(A) ) ) ).dot(n) >= 0;
            b = ( ( C.sub(B) ).cross( ( p.sub(B) ) ) ).dot(n) >= 0;
            c = ( ( A.sub(C) ).cross( ( p.sub(C) ) ) ).dot(n) >= 0;

            return a && b && c ? new Intersection(intersectionPlan.T, this) : null;
        }

        /// <summary>
        /// Calcul l'intersection entre le rayon et la normale au triangle. 
        /// </summary>
        /// <param name="p">Le point décrivant le Pla</param>
        /// <returns>Le vecteur normale à l'intersection</returns>
        public override Vec3 getNormaleIntersection(Point p)
        {
            return ( ( B.sub(A) ).cross( ( C.sub(A) ) ) ).norm();
        }
    }
}
