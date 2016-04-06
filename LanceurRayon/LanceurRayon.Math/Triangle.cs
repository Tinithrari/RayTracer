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
			Point p;
			double t;
			double tmp = d.dot(n);

			if (tmp == 0.0)
				return null;
			
			t = A.sub(o).dot(n) / tmp;
			p = o.add(d.mul(t));

			if (B.sub (A).cross (p.sub (A)).dot (n) < 0.0)
				return null;

			if (C.sub (B).cross (p.sub (B)).dot (n) < 0.0)
				return null;
			
			if (A.sub (C).cross (p.sub (C)).dot (n) < 0.0)
				return null;

			return new Intersection(t,this);
        }

        /// <summary>
        /// Calcul  de l'intersection entre le rayon et la normale au triangle. 
        /// </summary>
        /// <param name="p">Le point décrivant le Pla</param>
        /// <returns>Le vecteur normale à l'intersection</returns>
        public override Vec3 getNormaleIntersection(Point p)
        {
            return ( ( B.sub(A) ).cross( ( C.sub(A) ) ) ).norm();
        }

        /// <summary>
        /// Effectue la transformation du triangle par la matrice donnée en paramètre.
        /// </summary>
        /// <param name="m"></param>
        /// <returns>Le triangle Transformé</returns>
        
        public Triangle getTransform(Mat4 m) {
             return new Triangle(m.productOnePoint(A), 
                                 m.productOnePoint(B), 
                                 m.productOnePoint(C),
                                 Specular, Ambient,Diffuse,Brillance);
            
        }
        
    }
}
