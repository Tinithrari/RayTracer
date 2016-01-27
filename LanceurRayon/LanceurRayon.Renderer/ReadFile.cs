using System.IO;
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
                      
                        if (tmp.Length !=4)
                            throw new System.ArgumentException("Nombre d'arguments incorrect", tmp[0]);
                        

                        ma_scene.fenetre=new Bitmap(Int32.Parse(tmp[1]),Int32.Parse(tmp[2]));
                        size_present = true;

                        break;

                    case "output":

                        if (tmp.Length != 3)
                            throw new System.ArgumentException("Nombre d'arguments  incorrect", tmp[0]);

                            ma_scene.output = tmp[1];
                            output_present = true;

                        break;

                    case "camera":

                        if (tmp.Length != 12)
                            throw new System.ArgumentException("Nombre d'arguments incorrect", tmp[0]);

                      
                        ma_scene.camera = new Camera ( new Vec3(Double.Parse(tmp[1], CultureInfo.InvariantCulture),Double.Parse(tmp[2], CultureInfo.InvariantCulture),Double.Parse(tmp[3], CultureInfo.InvariantCulture)),
                                                       new Vec3(Double.Parse(tmp[4], CultureInfo.InvariantCulture),Double.Parse(tmp[5], CultureInfo.InvariantCulture),Double.Parse(tmp[6], CultureInfo.InvariantCulture)),
                                                       new  Vec3(Double.Parse(tmp[7],CultureInfo.InvariantCulture),Double.Parse(tmp[8], CultureInfo.InvariantCulture),Double.Parse(tmp[9], CultureInfo.InvariantCulture)),
                                                       Double.Parse(tmp[10], CultureInfo.InvariantCulture)
                                                      );
                        camera_present = true;

                        break;

                    //Les couleurs
                    case "ambient":

                        

                        break;

                    case "diffuse":

                        ma_scene.nb_lumieres++;

                        break;

                    case "specular":

                        ma_scene.nb_lumieres++;

                        break;
                    
                     //Source de lumière
                    case "directional":

                        if (tmp.Length != 8)
                            throw new System.ArgumentException("Nombre d'arguments insuffisant", tmp[0]);


                        ma_scene.nb_lumieres++;

                        break;
                   
                    //Les entités géométriques
                    case "point":

                        ma_scene.nb_objets++;
                        break;

                    case "vertex":

                        ma_scene.nb_objets++;

                        break;

                    case "tri":

                        ma_scene.nb_objets++;

                        break;


                    case "sphere":

                        ma_scene.nb_objets++;


                        break;

                    case "plane":

                        ma_scene.nb_objets++;

                        break;

                    default:
                        throw new System.ArgumentException("Mot clef inconnu !!!", tmp[0]);
                      
                }
            }

            //On s'assure que un des paramètres indispensable n'à pas été omis .
            if (!size_present )
                throw new System.ArgumentException("Argument manquant !!!","size");

            else if(!output_present)
                throw new System.ArgumentException("Argument maquant !!!","output");

            else if( !camera_present)
                throw new System.ArgumentException("Argument manquant !!!", "camera");

            return ma_scene;
        }

    }
}