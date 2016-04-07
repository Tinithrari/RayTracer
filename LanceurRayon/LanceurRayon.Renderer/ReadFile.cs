using System;
using System.Drawing;
using LanceurRayon.Math;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LanceurRayon.Renderer
{
    /// <summary>
    /// Classe permetant de lire un fichier de scène
    /// </summary>
    public class ReadFile
    {
        /// <summary>
        /// Analyse le fichier de scène et convertit en un objet scène.
        /// </summary>
        /// <param name="nom_fichier">nom fichier de scène</param>
        /// <returns>Scène décrite par le fichier en paramètre.</returns>
        public Scene Analyze(string nom_fichier)
        {
            string ligne_courante;
            string[] tmp;
            int maxPoint = -1,PointsRecontres=0;
            double brillance = 1;
            bool output_present, size_present, camera_present;

            Math.Color ambient, specular, diffuse,couleur_noire= new Math.Color();
            StreamReader stream = new StreamReader(nom_fichier);
            Scene ma_scene = new Scene();
            ma_scene.Shadow = false;
            ma_scene.maxdepth = 1;
            output_present = size_present = camera_present = false;
            ambient =specular=diffuse= couleur_noire;

            while ((ligne_courante = stream.ReadLine()) != null)
            {
                if (!ligne_courante.Equals(""))
                {
                    if (ligne_courante[0] == '#' || ligne_courante == " ")//Si le parser rencontre un #  la ligne est considéré comme un commentaire et ignoré.
                        continue;

                    //On découpe la ligne de manière à récupérer séparément les mots constituants la ligne.
                    tmp = ligne_courante.Split(' ');
                    tmp = tmp.Where(val => !val.Equals("")).ToArray();

                    //Reconnaissance des différents mot clefs
                    switch (tmp[0])
                    {
                        //Caractéristiques de la scène


                        case "checker":

                            if (tmp.Length != 8)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ma_scene.damier=new Damier(  Math.Color.createColor(tmp[1], tmp[2], tmp[3]), 
                                                         Math.Color.createColor(tmp[4], tmp[5], tmp[6]),
                                                         Double.Parse(tmp[7]));
                           
                            break;

                        case "shadow":

                            if (tmp.Length != 2)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);
                           ma_scene.Shadow= bool.Parse(tmp[1]);

                            break;

                        case "size":

                            if (tmp.Length != 3)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);
                            ma_scene.Fenetre = new Bitmap(Int32.Parse(tmp[1]), Int32.Parse(tmp[2]));
                            size_present = true;

                            break;

                        case "output":
                            if (tmp.Length != 2)
                                throw new ArgumentException("Nombre d'arguments  incorrect", tmp[0]);

                            ma_scene.Output = tmp[1];
                            output_present = true;
                            break;

                        case "camera":
                            if (tmp.Length != 11)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ma_scene.Camera = new Camera(Math.Point.createPoint(tmp[1], tmp[2], tmp[3]), Math.Point.createPoint(tmp[4], tmp[5], tmp[6]),
                                                         Math.Vec3.createVec3(tmp[7], tmp[8], tmp[9]), double.Parse(tmp[10], CultureInfo.InvariantCulture));
                            camera_present = true;
                            break;

                        case "maxdepth":
                            if (tmp.Length != 2)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ma_scene.maxdepth = Int32.Parse(tmp[1]);
                          
                            break;

                        //Les couleurs
                        case "ambient":
                            if (tmp.Length != 4)
                                throw new System.ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ambient = Math.Color.createColor(tmp[1], tmp[2], tmp[3]);
                            break;

                        case "diffuse":
                            if (tmp.Length != 4)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            diffuse = Math.Color.createColor(tmp[1], tmp[2], tmp[3]);
                            break;

                        case "specular":
                            if (tmp.Length != 4)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            specular = Math.Color.createColor(tmp[1], tmp[2], tmp[3]);
                            break;

                        case "shininess":
                            if (tmp.Length != 2)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            brillance = double.Parse(tmp[1], CultureInfo.InvariantCulture);
                            break;

                        //Source de lumière
                        case "directional":
                            if (tmp.Length != 7)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ma_scene.Eclairage.Add(new LumiereDirectionelle(Math.Color.createColor(tmp[4], tmp[5], tmp[6]),
                                                                            Math.Vec3.createVec3(tmp[1], tmp[2], tmp[3])));

                            ma_scene.NbLumieres++;
                            break;

                        case "point":
                            if (tmp.Length != 7)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ma_scene.Eclairage.Add(new LumierePonctuelle(Math.Color.createColor(tmp[4], tmp[5], tmp[6]),
                                                                         Math.Point.createPoint(tmp[1], tmp[2], tmp[3])));

                            ma_scene.NbLumieres++;
                            break;

                        //Les entitées géométriques
                        case "vertex":
                            if (tmp.Length != 4)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            if (maxPoint == -1)
                                throw new ArgumentException("Le nombre de points doit être définit à l'avance.", tmp[0]);

                            if (maxPoint == PointsRecontres)
                                throw new ArgumentException("Le nombre de points rencontrés dépasse la contrainte définit.", tmp[0]);


                            ma_scene.add_Point(Math.Point.createPoint(tmp[1], tmp[2], tmp[3]));

                            PointsRecontres++;
                            break;

                        case "tri":
                            if (tmp.Length != 4)
                                throw new System.ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ma_scene.Entite.Add(new Triangle(ma_scene.LesPoints[int.Parse(tmp[1])], ma_scene.LesPoints[int.Parse(tmp[2])], ma_scene.LesPoints[int.Parse(tmp[3])], specular, ambient, diffuse, brillance));
                            ma_scene.NbObjets++;

                            break;

                        case "sphere":
                            if (tmp.Length != 5)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ma_scene.Entite.Add(new Sphere(Math.Point.createPoint(tmp[1], tmp[2], tmp[3]), double.Parse(tmp[4], CultureInfo.InvariantCulture),
                                                           specular, ambient, diffuse, brillance));

                            ma_scene.NbObjets++;

                            break;

                        case "plane":
                            if (tmp.Length != 7)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            ma_scene.Entite.Add(new Plan(Math.Point.createPoint(tmp[1], tmp[2], tmp[3]), Math.Vec3.createVec3(tmp[4], tmp[5], tmp[6]), specular, ambient, diffuse, brillance));

                            ma_scene.NbObjets++;
                            break;

                        case "maxverts":
                            if (tmp.Length != 2)
                                throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                            maxPoint = Int32.Parse(tmp[1]);
                            break;

                        //Les transformations

                        case "translate":
                            if (tmp.Length != 4)
                                throw new ArgumentException("Nombre d'arguments  incorrect", tmp[0]);

                            ma_scene.Transformation.Add(Mat4.CreateTranslationMatrix(Vec3.createVec3(tmp[1],tmp[2],tmp[3])));
                            break;

                        case "scale":
                            if (tmp.Length != 4)
                                throw new ArgumentException("Nombre d'arguments  incorrect", tmp[0]);

                            ma_scene.Transformation.Add(Mat4.CreateScalingMatrix(Vec3.createVec3(tmp[1], tmp[2], tmp[3])));
                            break;

                        case "rotate":
                            if (tmp.Length != 5)
                                throw new ArgumentException("Nombre d'arguments  incorrect", tmp[0]);

                            ma_scene.Transformation.Add(Mat4.CreateRotationMatrix(Vec3.createVec3(tmp[1], tmp[2], tmp[3]),Double.Parse(tmp[4]))  );
                            break;


                    }
                }
            }
            
            //On s'assure que un des paramètres indispensable n'à pas été omis .
            if (!size_present )
                throw new ArgumentException("Argument manquant !!!","size");

            if(!output_present)
                throw new ArgumentException("Argument manquant !!!","output");

            if( !camera_present)
                throw new ArgumentException("Argument manquant !!!", "camera");

            return ma_scene;
        }   
    }
}