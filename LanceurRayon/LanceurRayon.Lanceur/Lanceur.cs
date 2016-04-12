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
            a = (PixelWidth * (i - (Scene.Fenetre.Width / 2d) + 0.5)) / (Scene.Fenetre.Width / 2d);
            b = (PixelHeight * (j - (Scene.Fenetre.Height / 2d) + 0.5)) / (Scene.Fenetre.Height / 2d);

            // On crée le vecteur d
			d = Repere.U.mul(a);
			d = d.add(Repere.V.mul(b));
			d = d.sub(Repere.W);
			d = d.norm(); 

            return d;
        }

        private Color calculLumiereReflechie(Intersection intersect, Point p, Vec3 d, int maxDepth)
        {
            Vec3 r, negD, n;
            Color c;
            Intersection interLum;
            Point pp;

            if ( (intersect.Obj.Specular.R == 0 && intersect.Obj.Specular.G == 0 && intersect.Obj.Specular.B == 0) || maxDepth == Scene.maxdepth)
                return new Color();

            if (Scene.Transformation.Count > 0)
                p = Scene.Transformation[0].Inverse().productOnePoint(p);

            n = intersect.Obj.getNormaleIntersection(p);
            
            if (Scene.Transformation.Count != 0)
                n = Scene.Transformation[0].Inverse().transpose().productOneVector(n);
            
            negD = new Vec3(-d.X, -d.Y, -d.Z);

            r = d.add( n.mul( 2 * n.dot(negD) ) );

            interLum = getCloserIntersection(p, r);

            if (interLum == null || interLum.T < 0.00001d)
                return new Color();

            pp = p.add(r.mul(interLum.T));

            c = calculLumierePoint(p, interLum, r);

            return c.add(interLum.Obj.Specular.times( calculLumiereReflechie(interLum, pp, r, maxDepth + 1) ) );
        }

        private Color calculLumierePoint(Point o, Intersection intersect, Vec3 d)
        {
            Color c = new Color();

            if (intersect != null)
            {
                // Lorsqu'il y a présence de source(s) de lumière(s)
                if (Scene.NbLumieres > 0)
                {
                    Color somme = new Color();
                    Point p = o.add(d.mul(intersect.T));

                    // Calcul de la couleur à afficher
                    foreach (Lumiere l in Scene.Eclairage)
                    {
                        Color lightColor = l.Couleur;

                        if (Scene.Transformation.Count > 0)
                        {
                            Mat4 transformation_inverse = Scene.Transformation[0].Inverse();
                            p = transformation_inverse.productOnePoint(o).add((transformation_inverse.Scalaire(intersect.T)).productOneVector(d));
                        }

                        Vec3 n = intersect.Obj.getNormaleIntersection(p), lightdir = l.getDirection(p);

                        if (Scene.Transformation.Count != 0)
                        {
                            n = Scene.Transformation[0].Inverse().transpose().productOneVector(n);
                            Point p_transform = Scene.Transformation[0].productOnePoint(p);
                            if (d.X != 0)
                                intersect.T = p_transform.sub(o).X / d.X;

                            else if (d.Y != 0)
                                intersect.T = p_transform.sub(o).Y / d.Y;

                            else if (d.Z != 0)
                                intersect.T = p_transform.sub(o).Z / d.Z;
                            else
                                intersect = null;
                        }

                        // Si les ombres sont activées
                        if (Scene.Shadow)
                        {

                            // On regarde s'il y a un objet entre la lumière et le point d'intersection
                            foreach (VisualEntity e in Scene.Entite)
                            {
                                Intersection intersection = e.Collide(lightdir, p.add(lightdir.mul(0.00001d)));

                                if (intersection != null)
                                {
                                    if (intersection.T >= 0.00001d && intersection.T < l.getDistance(p))
                                    {
                                        lightColor = new Color();
                                        break;
                                    }
                                }
                            }
                        }
                        // Initialisation des variables pour Blinn-Phong
						Vec3 eyedir = new Vec3(-d.X, -d.Y, -d.Z), 
						h = lightdir.add(eyedir).norm();

						somme = somme.add (intersect.Obj.Diffuse.times (lightColor.mul (System.Math.Max (n.dot (lightdir), 0))));
						somme = somme.add (intersect.Obj.Specular.times (lightColor.mul (System.Math.Pow (System.Math.Max (n.dot (h), 0), intersect.Obj.Brillance))));
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
            Mat4 transformation, transformation_inverse;
            Point p,p_transform;
            

            // Détection de l'intersection la plus proche
            foreach (VisualEntity entity in this.Scene.Entite)
            {
                Intersection tmp = entity.Collide(d, o);
                /*
                if (tmp != null &&  tmp.Obj.GetType() == typeof(Sphere) && Scene.Transformation.Count > 0)
                {

                    transformation = Scene.Transformation[0];
                    transformation_inverse = transformation.Inverse();

                     p = transformation_inverse.productOnePoint(o).add((transformation_inverse.Scalaire(tmp.T)).productOneVector(d));
                  // p = transformation_inverse.productOnePoint(o).add(transformation_inverse.productOneVector(d.mul(tmp.T)))  ;
                    p_transform = transformation.productOnePoint(p);

                    if (d.X != 0)
                        tmp.T = p_transform.sub(o).X / d.X;

                    else if (d.Y != 0)
                        tmp.T = p_transform.sub(o).Y / d.Y;

                    else if (d.Z != 0)
                        tmp.T = p_transform.sub(o).Z / d.Z;
                    else
                        tmp = null;
                }*/
                
				if (tmp != null && tmp.T > 0.00001d && (intersect == null || tmp.T < intersect.T))
                    intersect = tmp;
            }

            return intersect;
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
                    Intersection intersect = null;
                    Color c = new Color();
                    Vec3 d = VecteurDirForPixel(i, j);
                    Point p;
                    

					intersect = getCloserIntersection(Scene.Camera.LookFrom, d);

					if (intersect != null)
					{
                            p = Scene.Camera.LookFrom.add(d.mul(intersect.T));
                            c = calculLumierePoint(Scene.Camera.LookFrom, intersect, d);
                            c = c.add(intersect.Obj.Specular.times(calculLumiereReflechie(intersect, p, d, 1)));
					}
					double newR, newG, newB;
					newR = c.R > 1 ? 1 : c.R;
					newG = c.G > 1 ? 1 : c.G;
					newB = c.B > 1 ? 1 : c.B;

					c = new Color (newR, newG, newB);

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
                
                ///Application des transformations aux triangles
                if (scene.Transformation.Count > 0)
                {
                    for (int i = 0; i < scene.Entite.Count; i++)
                        scene.Entite[i] = scene.Entite[i].getTransform(scene.Transformation[0]);
                }

                //Initialisation du lanceur et génération de l'image.
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
