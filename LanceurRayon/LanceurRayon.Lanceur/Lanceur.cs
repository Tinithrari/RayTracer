using LanceurRayon.Math;
using LanceurRayon.Renderer;

using System;

namespace LanceurRayon.RayTracer
{
    public class Lanceur
    {

        public Scene Scene { get; private set; }
        public Repere Repere { get; private set; }
        public double PixelWidth { get; private set; }
        public double PixelHeight { get; private set; }
        
        /// <summary>
        /// Initialise un lanceur de rayon pour une scène donnée
        /// </summary>
        /// <param name="Scene">La scène où l'on souhaite effectuer un lancer de rayon</param>
        /// <exception cref="ArgumentNullException">Exception lancée si la scène n'est pas précisée</exception>
        public Lanceur(Scene Scene)
        {
            Vec3 tmpU, tmpV, tmpW, inter;
            double fovRad;

            if (Scene == null)
                throw new ArgumentNullException("Une scène doit-être spécifiée pour créer un lanceur de rayon");

            this.Scene = Scene;

            // Calcul du repère orthonormé de la scène par rapport à la caméra

            inter = Scene.Camera.LookFrom.sub(Scene.Camera.LookAt);
            tmpW = inter.mul( (1 / inter.length()) );

            inter = Scene.Camera.Up.sub(tmpW);
            tmpU = inter.mul(1 / inter.length());

            inter = tmpU.cross(tmpW);
            tmpV = inter.mul(1 / inter.length());

            Repere = new Repere(tmpU, tmpV, tmpW);

            // Calcul des dimensions d'un pixels par rapport au domaine 3D

            fovRad = (Scene.Camera.Fov * System.Math.PI) / 180; // Conversion du fielf of view en radian

            PixelHeight = System.Math.Tan(fovRad / 2); // Calcul de la hauteur d'un pixel (Voir trigonométrie)
            PixelWidth = PixelHeight * (Scene.Fenetre.Width / Scene.Fenetre.Height); // Calcul de la largeur en utilisant le ratio de l'image
        }

        /// <summary>
        /// Calcul le vecteur direction pour un pixel donné
        /// </summary>
        /// <param name="i">La position en i du pixel dans la matrice</param>
        /// <param name="j">La position en j du pixel dans la matrice</param>
        /// <returns>Le vecteur direction visant le centre de ce pixel</returns>
        private Vec3 VecteurDirForPixel(int i, int j)
        {
            double a, b;
            Vec3 d;

            // On projete i et dans le repère de la scène
            a = (PixelWidth * (i - (Scene.Fenetre.Width / 2) + 0.5)) / (Scene.Fenetre.Width / 2);
            b = (PixelHeight * (i - (Scene.Fenetre.Height / 2) + 0.5)) / (Scene.Fenetre.Height / 2);

            // On crée le vecteur d
            d = Repere.U.mul(a);
            d = d.add(Repere.V.mul(b));
            d = d.sub(Repere.W).norm();

            return d;
        }

        /// <summary>
        /// Génère l'image relative à la scène
        /// </summary>
        public void GenerateImage()
        {
            for (int i = 0; i < Scene.Fenetre.Width; i++)
                for (int j = 0; j < Scene.Fenetre.Width; j++)
                {
                    double? t = null;
                    Color c = new Color();
                    Vec3 unit = VecteurDirForPixel(i, j);

                    foreach (VisualEntity entity in this.Scene.Entite)
                    {
                        double? tmp = entity.Collide(unit, this.Scene.Camera.LookFrom);
                        if (tmp != null && t != null && tmp < t)
                        {
                            // Calcul lumière
                            t = tmp;
                            c = entity.Ambient;
                        }
                    }

                    this.Scene.Fenetre.SetPixel(i, j, System.Drawing.Color.FromArgb((int) c.R * 255, (int) c.G * 255, (int) c.B * 255));
                }
            this.Scene.Fenetre.Save(this.Scene.Output);
        }
    }
}
