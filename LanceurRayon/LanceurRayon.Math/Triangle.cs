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
        /// <param name="Pt">Centre de gravité du triangle</param>
        /// <param name="Specular">Reflêt</param>
        /// <param name="Ambient">Lumière ambiante</param>
        /// <param name="Diffuse">Lumière diffuse</param>
        /// <param name="Brillance">Brillance de la scène.</param> 
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
        /// <param name="ray">Le rayon</param>
        /// <param name="eye">L'origine du rayon</param>
        /// <returns>Le discriminant de l'intersection ou null si pas d'intersection</returns>
        public override double? Collide(Vec3 ray, Point eye)
        {
            Vec3 normale = getNormaleIntersection(null);

            double? t;
            double tmp = ray.dot(normale);

            if (tmp == 0.0)
                t = null;
            else
                t = A.sub(eye).dot(normale) / ray.dot(normale);

            if (B.sub(A).cross(eye.sub(A)).dot(normale) < 0)
                return null;

            if (C.sub(B).cross(eye.sub(B)).dot(normale) < 0)
                return null;

            if (A.sub(C).cross(eye.sub(C)).dot(normale) < 0)
                return null;

            return t;
        }

        public override Vec3 getNormaleIntersection(Point p)
        {
            return this.B.sub(this.A).cross(this.C.sub(this.A)).norm();
        }
    }
}
