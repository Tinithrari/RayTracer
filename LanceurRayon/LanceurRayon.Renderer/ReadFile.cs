using System;
using System.Drawing;
using LanceurRayon.Math;
using System.Globalization;

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
        //Chargement du fichier de scène intégralement en mémoire vive .
        /// <param name="nom_fichier">nom fichier de scène</param>

        public Scene Analyze(string nom_fichier)
        {

            string[] lignes_fichier, tmp;
            Scene ma_scene = new Scene();

            bool output_present, size_present, camera_present;

            Math.Color ambient= new Math.Color();
            Math.Color specular= new Math.Color();
            Math.Color diffuse= new Math.Color();  

            lignes_fichier = System.IO.File.ReadAllLines(nom_fichier);

            output_present = false;
            size_present = false;
            camera_present = false;
           

            foreach (string ligne_courante in lignes_fichier)
            {

                if (ligne_courante[0] == '#')//Si le parser rencontre un #  la ligne est considéré comme un commentaire et ignoré.
                    continue;


                //On découpe la ligne de manière à récupérer séparément les mots constituants la ligne.
                tmp = ligne_courante.Split(' ');


                //Reconnaissance des différents mot clefs
                switch (tmp[0])
                {
                    //Caractéristiques de la scène
                    case "size":
                     
                        if (tmp.Length != 3)
                            throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);
                        

                        ma_scene.Fenetre=new Bitmap(Int32.Parse(tmp[1]),Int32.Parse(tmp[2]));
                        size_present = true;

                        break;

                    case "output":

                        if (tmp.Length != 3 )
                            throw new ArgumentException("Nombre d'arguments  incorrect", tmp[0]);

                            ma_scene.Output = tmp[1];
                            output_present = true;

                        break;

                    case "camera":

                        if (tmp.Length != 12 )
                            throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                      

                        ma_scene.Camera = new Camera ( new Vec3(double.Parse(tmp[1], CultureInfo.InvariantCulture),double.Parse(tmp[2], CultureInfo.InvariantCulture),double.Parse(tmp[3], CultureInfo.InvariantCulture)),
                                                       new Vec3(double.Parse(tmp[4], CultureInfo.InvariantCulture),double.Parse(tmp[5], CultureInfo.InvariantCulture),double.Parse(tmp[6], CultureInfo.InvariantCulture)),
                                                       new  Vec3(double.Parse(tmp[7],CultureInfo.InvariantCulture),double.Parse(tmp[8], CultureInfo.InvariantCulture),double.Parse(tmp[9], CultureInfo.InvariantCulture)),
                                                       double.Parse(tmp[10], CultureInfo.InvariantCulture)
                                                      );
                        camera_present = true;

                        break;

                    //Les couleurs
                    case "ambient":

                        

                        break;

                    case "diffuse":

               

                        break;

                    case "specular":

                        

                        break;
                    
                     //Source de lumière
                    case "directional":

                        if (tmp.Length != 7 )
                            throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);


                        ma_scene.add_lumiere_globale(new Lumiere(
                                                                new Vec3(double.Parse(tmp[1], CultureInfo.InvariantCulture),
                                                                         double.Parse(tmp[2], CultureInfo.InvariantCulture),
                                                                         double.Parse(tmp[3], CultureInfo.InvariantCulture)),
                                                                new Math.Color(double.Parse(tmp[4], CultureInfo.InvariantCulture),
                                                                               double.Parse(tmp[5], CultureInfo.InvariantCulture),
                                                                               double.Parse(tmp[6], CultureInfo.InvariantCulture))
                                                                  )
                                                     );
                        ma_scene.NbLumieres++;

                        break;
                   
                    
                    case "point":

                        if (tmp.Length != 7 )
                            throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                        ma_scene.add_lumiere_locale(new Lumiere(
                                                                 new Vec3(double.Parse(tmp[1], CultureInfo.InvariantCulture),
                                                                          double.Parse(tmp[2], CultureInfo.InvariantCulture),
                                                                          double.Parse(tmp[3], CultureInfo.InvariantCulture)
                                                                          )           
                                                                ,new Math.Color(double.Parse(tmp[4], CultureInfo.InvariantCulture),
                                                                                double.Parse(tmp[5], CultureInfo.InvariantCulture),
                                                                                double.Parse(tmp[6], CultureInfo.InvariantCulture)
                                                                                )
                                                                )
                                                     );

                        ma_scene.NbLumieres++;
                        break;
                    
                    //Les entitées géométriques
                    case "vertex":

                        if (tmp.Length !=5 )
                            throw new System.ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                        ma_scene.add_Point(new Math.Point(
                                                          double.Parse(tmp[1], CultureInfo.InvariantCulture),
                                                          double.Parse(tmp[2], CultureInfo.InvariantCulture),
                                                          double.Parse(tmp[3], CultureInfo.InvariantCulture)
                                                          )
                                           );

                        ma_scene.NbObjets++;

                        break;

                    case "tri":

                        if (tmp.Length != 4 )
                            throw new System.ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                        ma_scene.add_Triangle (new Triangle(
                                                             new Math.Point(
                                                                             double.Parse(tmp[1], CultureInfo.InvariantCulture),
                                                                             double.Parse(tmp[2], CultureInfo.InvariantCulture),
                                                                             double.Parse(tmp[3], CultureInfo.InvariantCulture)
                                                                            )
                                                             ,specular
                                                             ,ambient
                                                             ,diffuse
                                                             )               
                                                );

                        ma_scene.NbObjets++;
                      
                        //Remise a zéro de la couleur
                        ambient = new Math.Color();
                        specular = new Math.Color();
                        diffuse = new Math.Color();

                        break;


                    case "sphere":

                        if (tmp.Length != 5 )
                            throw new ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                      

                        

                       ma_scene.add_Sphere(new Sphere(
                                                       new Math.Point(double.Parse(tmp[1], CultureInfo.InvariantCulture),
                                                                      double.Parse(tmp[2], CultureInfo.InvariantCulture),
                                                                      double.Parse(tmp[3], CultureInfo.InvariantCulture)
                                                                      )
                                                      ,double.Parse(tmp[4], CultureInfo.InvariantCulture)
                                                      ,specular
                                                      ,ambient
                                                      ,diffuse
                                                       )
                                            );

                        ma_scene.NbObjets++;
                       
                        //Remise a zéro de la couleur
                        ambient = new Math.Color();
                        specular = new Math.Color();
                        diffuse = new Math.Color();

                        break;

                    case "plane":
                        
                        if (tmp.Length != 7 )
                            throw new System.ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                        
                        ma_scene.add_Plan(new Plan(
                                                     new Math.Point(double.Parse(tmp[1], CultureInfo.InvariantCulture),
                                                                    double.Parse(tmp[2], CultureInfo.InvariantCulture),
                                                                    double.Parse(tmp[3], CultureInfo.InvariantCulture)
                                                                    )

                                                     ,new Math.Vec3(double.Parse(tmp[4], CultureInfo.InvariantCulture),
                                                                    double.Parse(tmp[5], CultureInfo.InvariantCulture),
                                                                    double.Parse(tmp[6], CultureInfo.InvariantCulture)
                                                                    )
                                                    )
                                          );

                        ma_scene.NbObjets++;

                        break;

                    default:
                        throw new System.ArgumentException("Mot clef inconnu !!!", tmp[0]);
                      
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