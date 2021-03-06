﻿using System;


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

        /// <summary>
        /// Detecte si le rayon entre en collision avec l'objet
        /// </summary>
        /// <param name="ray">Le rayon</param>
        /// <param name="eye">L'origine du rayon</param>
        /// <returns>Le discriminant de l'intersection ou null si pas d'intersection</returns>
        public override Intersection Collide(Vec3 ray, Point eye)
        {
            double delta, a, b, c, t1, t2;
            Vec3 eyeToCenter;

            if (ray == null)
                throw new ArgumentNullException("ray doit-être défini");

			eyeToCenter = eye.sub (Centre);

            a = 1.0;
            b = 2.0 * (eyeToCenter.dot(ray));
            c = (eyeToCenter.dot(eyeToCenter)) - (Rayon * Rayon);

            delta = (b * b) - (4.0 * a * c);

            if (delta < 0)
                return null;
            else if (delta == 0.0)
                if ( (-b / (2 * a)) > 0)
                    return new Intersection ((-b / (2 * a)), this);
                else
                    return null;

            t1 = (-b + System.Math.Sqrt(delta)) / (2d * a);
            t2 = (-b - System.Math.Sqrt(delta)) / (2d * a);

            if (t2 > 0.0)
                return new Intersection(t2,this);
            else if (t1 > 0.0)
                return new Intersection(t1, this);
            else
                return null;
        }
        
        /// <summary>
        /// Calcul l'intersection entre le rayon et la normale a la sphère. 
        /// </summary>
        /// <param name="p">Le point décrivant le Pla</param>
        /// <returns>Le vecteur normale à l'intersection</returns>
        public override Vec3 getNormaleIntersection(Point p)
        {
            return p.sub(Centre).norm();
        }
        
        public override VisualEntity getTransform(Mat4 m)
        {
            return new Sphere(m.productOnePoint(Centre), Rayon, Specular, Ambient, Diffuse, Brillance);
        }
    }
}
