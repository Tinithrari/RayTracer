﻿using LanceurRayon.Math;
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
            Vec3 tmpU, tmpV, tmpW;
            double fovRad;

            if (Scene == null)
                throw new ArgumentNullException("Une scène doit-être spécifiée pour créer un lanceur de rayon");

            this.Scene = Scene;

            // Calcul du repère orthonormé de la scène par rapport à la caméra

            tmpW = Scene.Camera.LookFrom.sub(Scene.Camera.LookAt).norm();

            tmpU = Scene.Camera.Up.cross(tmpW).norm();

            tmpV = tmpW.cross(tmpU).norm();

            Repere = new Repere(tmpU, tmpV, tmpW);

            // Calcul des dimensions d'un pixels par rapport au domaine 3D

            fovRad = (Scene.Camera.Fov * System.Math.PI) / 180d; // Conversion du fielf of view en radian

            PixelHeight = System.Math.Tan(fovRad / 2d); // Calcul de la hauteur d'un pixel (Voir trigonométrie)
            PixelWidth = PixelHeight * ((double)Scene.Fenetre.Width / (double)Scene.Fenetre.Height); // Calcul de la largeur en utilisant le ratio de l'image
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
            a = (PixelWidth * ((double) i - ((double) Scene.Fenetre.Width / 2d) + 0.5)) / ((double) Scene.Fenetre.Width / 2d);
            b = (PixelHeight * ((double) j - ((double) Scene.Fenetre.Height / 2d) + 0.5)) / ((double) Scene.Fenetre.Height / 2d);

            // On crée le vecteur d
            d = (Repere.U.mul(a)).add((Repere.V.mul(b)).sub(Repere.W)).norm();

            return d;
        }

        private Color calculLumiereReflechie(Intersection intersect, Point p, Vec3 d, int maxDepth)
        {
            Vec3 r, negD, n;
            Color c;
            Intersection interLum;
            Point pp;

            if (intersect.Obj.Specular.R == 0 && intersect.Obj.Specular.G == 0 && intersect.Obj.Specular.R == 0 || maxDepth == Scene.maxdepth)
                return new Color();

            n = intersect.Obj.getNormaleIntersection(p);
            negD = new Vec3(-d.X, -d.Y, -d.Z);
            r = d.add( n.mul( 2 * n.dot(negD) ) );

            interLum = getCloserIntersection(p, r);

            if (interLum == null)
                return new Color();

            pp = p.add(r.mul(interLum.T));

            c = calculLumierePoint(interLum, r);

            return c.add(interLum.Obj.Specular.times( calculLumiereReflechie(interLum, pp, r, maxDepth + 1) ) );
        }

        private Color calculLumierePoint(Intersection intersect, Vec3 d)
        {
            Color c = new Color();

            if (intersect != null)
            {
                // Lorsqu'il y a présence de source(s) de lumière(s)
                if (Scene.NbLumieres > 0)
                {
                    Color somme = new Color();
                    Point p = Scene.Camera.LookFrom.add(d.mul(intersect.T));

                    // Calcul de la couleur à afficher
                    foreach (Lumiere l in Scene.Eclairage)
                    {
                        Color lightColor = l.Couleur;
                        Vec3 n = intersect.Obj.getNormaleIntersection(p), lightdir = l.getDirection(p);

                        // Si les ombres sont activées
                        if (Scene.Shadow)
                        {

                            // On regarde s'il y a un objet entre la lumière et le point d'intersection
                            foreach (VisualEntity e in Scene.Entite)
                            {
                                Intersection intersection = e.Collide(lightdir, p.add(lightdir.mul(0.000001d)));

                                if (intersection != null)
                                {
                                    if (intersection.T > 0.00001d)
                                    {
                                        lightColor = new Color();
                                        break;
                                    }
                                }
                            }
                        }
                        // Initialisation des variables pour Blinn-Phong
                        Vec3 eyedir = Scene.Camera.LookFrom.sub(Scene.Camera.LookAt).norm(), h = lightdir.cross(eyedir).norm();

                        somme = intersect.Obj.Diffuse.times(somme.add(lightColor.mul(System.Math.Max(n.dot(lightdir), 0))));
                        somme = somme.add( intersect.Obj.Specular.times( lightColor.mul( System.Math.Pow(System.Math.Max( n.dot(h), 0 ), intersect.Obj.Brillance ) ) ) );
                    }
                    c = intersect.Obj.Ambient.add(somme);
                }

                else
                    c = intersect.Obj.Ambient;
            }
            return c;
        }

        private Intersection getCloserIntersection(Point o, Vec3 d)
        {
            Intersection intersect = null;
            // Détection de l'intersection la plus proche
            foreach (VisualEntity entity in this.Scene.Entite)
            {
                Intersection tmp = entity.Collide(d, o);

                if (tmp != null && (intersect == null || tmp.T < intersect.T))
                    intersect = tmp;
            }

            return intersect;
        }

        /// <summary>
        /// Génère l'image relative à la scène
        /// </summary>
        public void GenerateImage()
        {
            Color c;
            for (int i = 0; i < Scene.Fenetre.Width; i++)
            {
                for (int j = 0; j < Scene.Fenetre.Height; j++)
                {
                    Intersection intersect = null;
                    Vec3 d = VecteurDirForPixel(i, j);
                    Point p;

                    // Détection de l'intersection la plus proche
                    intersect = getCloserIntersection(Scene.Camera.LookFrom, d);

                    p = Scene.Camera.LookFrom.add(d.mul(intersect.T));
                    c = calculLumierePoint(intersect, d);
                    c.add(intersect.Obj.Specular.times(calculLumiereReflechie(intersect, p, d, 1)));

                    this.Scene.Fenetre.SetPixel(i, (Scene.Fenetre.Height - 1) - j, System.Drawing.Color.FromArgb((int)System.Math.Round(c.R * 255, MidpointRounding.AwayFromZero), (int)System.Math.Round(c.G * 255, MidpointRounding.AwayFromZero), (int)System.Math.Round(c.B * 255, MidpointRounding.AwayFromZero)));
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
