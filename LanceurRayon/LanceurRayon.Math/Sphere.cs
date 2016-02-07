using System;


namespace LanceurRayon.Math
{
 /// <summary>
 /// Classe permetant de représenter une sphère.
 /// </summary>
    public class Sphere : VisualEntity{
        /// <summary>
        /// Centre de la sphère.
        /// </summary>
        public Point Centre{ get; private set; }

        /// <summary>
        /// Rayon de la sphère.
        /// </summary>
        public double Rayon{ get; private set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="Centre">Centre de la sphère</param>
        /// <param name="Rayon">Rayon de la sphère.</param>
        /// <param name="Specular">Reflêt.</param>
        /// <param name="Ambient">Lumière ambiante.</param>
        /// <param name="Diffuse">Lumière diffuse.</param>
        /// <param name="Brillance">Brillance de la scène.</param>
        public Sphere(Point Centre, double Rayon, Math.Color Specular, Math.Color Ambient, Math.Color Diffuse, double Brillance)
        {
            this.Ambient = Ambient;
            this.Specular = Specular;
            this.Diffuse = Diffuse;
            this.Centre = Centre;
            this.Rayon = Rayon;
            this.Brillance = Brillance;
        }

        public override double? Collide(Vec3 ray, Point eye)
        {
            double delta, a, b, c, t1, t2;
            Vec3 eyeToCenter;

            if (ray == null)
                throw new ArgumentNullException("ray doit-être défini");

            eyeToCenter = eye.sub(Centre);

            a = ray.dot(ray);
            b = 2 * eyeToCenter.dot(ray);
            c = eyeToCenter.dot(eyeToCenter) - System.Math.Pow(Rayon, 2);

            delta = System.Math.Pow(b, 2) - 4 * a * c;

            if (delta < 0)
                return null;
            else if (delta == 0)
                return -b / 2 * a;

            t1 = (-b + System.Math.Sqrt(delta)) / (2 * a);
            t2 = (-b - System.Math.Sqrt(delta)) / (2 * a);

            return t2 < 0 ? t1 : (t2 < t1 ? t2 : t1);
        }
    }
}
