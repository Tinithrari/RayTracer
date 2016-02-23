using LanceurRayon.Math;
using LanceurRayon.Renderer;

using System;
using System.IO;

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
            tmpW = inter.norm();

            inter = Scene.Camera.Up.cross(tmpW);
            tmpU = inter.norm();

            inter = tmpW.cross(tmpU);
            tmpV = inter.norm();

            Repere = new Repere(tmpU, tmpV, tmpW);

            // Calcul des dimensions d'un pixels par rapport au domaine 3D

            fovRad = (Scene.Camera.Fov * System.Math.PI) / 180; // Conversion du fielf of view en radian

            PixelHeight = System.Math.Tan(fovRad / 2); // Calcul de la hauteur d'un pixel (Voir trigonométrie)
            PixelWidth = PixelHeight * Scene.Fenetre.Width / Scene.Fenetre.Height; // Calcul de la largeur en utilisant le ratio de l'image
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
            a = (PixelWidth * (i - (Scene.Fenetre.Width / 2d) + 0.5)) / (Scene.Fenetre.Width / 2d);
            b = (PixelHeight * (j - (Scene.Fenetre.Height / 2d) + 0.5)) / (Scene.Fenetre.Height / 2d);

            // On crée le vecteur d
            d = Repere.U.mul(a);
            d = d.add(Repere.V.mul(b));
            d = d.sub(Repere.W);
            d = d.norm();

            return d;
        }

        /// <summary>
        /// Génère l'image relative à la scène
        /// </summary>
        public void GenerateImage()
        {
            for (int i = 0; i < Scene.Fenetre.Width; i++)
            {
                for (int j = 0; j < Scene.Fenetre.Height; j++)
                {
                    double? t = null;
                    Color c = new Color();
                    Vec3 d = VecteurDirForPixel(i, j);

                    foreach (VisualEntity entity in this.Scene.Entite)
                    {
                        double? tmp = entity.Collide(d, this.Scene.Camera.LookFrom);

                        if (Scene.NbLumieres > 0)
                        {
                            if (tmp != null && (t == null || tmp < t && tmp != null))
                            {
                                Color somme = new Color();
                                Point p;
                                t = tmp;
                                p = Scene.Camera.LookFrom.add(d.mul((double) t));

                                foreach (Lumiere l in Scene.Eclairage)
                                {
                                    Color cPoint = l.Couleur.mul(System.Math.Max(entity.getNormaleIntersection(p).dot(l.getDirection(p)), 0));
                                    somme = somme.add(cPoint);
                                }

                                c = entity.Ambient.add(somme.times(entity.Diffuse));
                            }
                        }
                        else
                        {
                            
                            if (tmp != null && (t == null || tmp < t && tmp != null))
                            {
                                t = tmp;
                                c = entity.Ambient;
                            }
                        }
                    }

                    this.Scene.Fenetre.SetPixel(i, j, System.Drawing.Color.FromArgb((int) System.Math.Round(c.R * 255, MidpointRounding.AwayFromZero), (int)System.Math.Round(c.G * 255, MidpointRounding.AwayFromZero), (int)System.Math.Round(c.B * 255, MidpointRounding.AwayFromZero)));
                }
            }
            this.Scene.Fenetre.Save(this.Scene.Output);
        }

        public static void Main(string[] args)
        {
            ReadFile reader = new ReadFile();
            Scene scene;

            if (args.Length != 1)
            {
                Console.Error.WriteLine("Le lecteur de fichier de scène attend un fichier exactement !!");
                System.Environment.Exit(1);
            }

            try
            {
                scene = reader.Analyze(args[0]);
                Lanceur lanceur = new Lanceur(scene);
                lanceur.GenerateImage();
            }

            catch (IOException e)
            {

                Console.WriteLine("Le fichier de sortie n'à pas pu être enregistré !!!");
                Console.Error.WriteLine(e.Message);
                System.Environment.Exit(1);
            }
            catch (ArgumentException f)
            {
                Console.WriteLine(f.Message);
                System.Environment.Exit(1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Un ou plusieurs arguments ne sont pas des nombres !!!");
                System.Environment.Exit(1);
            }
        }
    }
}
