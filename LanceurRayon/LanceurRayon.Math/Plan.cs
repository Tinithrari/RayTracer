using System;

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
        public Point Pt { get; private set; }

        /// <summary>
        /// Vecteur normal au plan.
        /// </summary>
        public Vec3 Vecteur_normal { get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Pt">Point décrivant un plan.</param>
        /// <param name="Vecteur_normal">Vecteur normal au plan.</param>
        public Plan(Point Pt,Vec3 Vecteur_normal, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse, double Brillance)
        {
            this.Pt = Pt;
            this.Vecteur_normal = Vecteur_normal;
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
            double? t;
            double tmp =ray.dot(Vecteur_normal);

            if (tmp == 0)
                t = null;

            else
                t =  Pt.sub(eye).dot(Vecteur_normal) / tmp;
         
            return t;
        }

        public override Vec3 getNormaleIntersection(Point p)
        {
            return Vecteur_normal;
        }
    }
}
