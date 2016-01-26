using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LanceurRayon.Renderer
{
    public class ReadFile
    {

        //Chargement du fichier de scène intégralement en mémoire vive .
        public static void Analyze(string nom_fichier)
        {

            string[] lignes_fichier, tmp;


            bool output_present, size_present, camera_present,
                specular_present, ambient_present, directional_present, diffuse_present;

            lignes_fichier = System.IO.File.ReadAllLines(nom_fichier);

            output_present = false;
            size_present = false;
            camera_present = false;
            specular_present = false;
            ambient_present = false;
            directional_present = false;
            diffuse_present = false;

            foreach (string ligne_courante in lignes_fichier)
            {

                if (ligne_courante[0] == '#')//Si le parser rencontre un #  la ligne est considéré comme un commentaire et ignoré.
                    continue;


                //On découpe la ligne de manière à récupérer séparément les mots constituants la ligne.
                tmp = ligne_courante.Split(' ');

                switch (tmp[0])
                {

                    case "size":

                        if (ReadFile.check_size(tmp)){

                            size_present = true;
                            Console.WriteLine("Création d'un bitmap de " + tmp[1] + " par " + tmp[2] + " pixels");
                        }

                        break;

                    case "output":

                        if (ReadFile.check_output(tmp)){

                            output_present = true;
                            //TO DO attraper une exception lors la tentative de création du fichier.
                            Console.WriteLine("fichier de sortie : " + tmp[1]);

                        }


                        break;

                    case "camera":

                        if (ReadFile.check_float(tmp,10,"camera"))
                        {

                            camera_present = true;
                            Console.WriteLine("Création de la caméra");
                        }

                        break;

                    case "ambient":

                        if (ReadFile.check_float(tmp,3,"ambient"))
                        {

                            ambient_present = true;
                            Console.WriteLine("Création de la lumière ambiante ");
                        }

                        break;

                    case "diffuse":

                        if (ReadFile.check_float(tmp,3,"diffuse"))
                        {

                            diffuse_present = true;
                            Console.WriteLine("Diffusion de la lumière");
                        }

                        break;

                    case "specular":

                        if (ReadFile.check_float(tmp,3,"specular"))
                        {

                            specular_present = true;
                            Console.WriteLine("Dispersion de la lumière ");
                        }

                        break;

                    case "directional":

                        if (ReadFile.check_float(tmp,3,"directional"))
                        {

                            directional_present = true;
                            Console.WriteLine("Direction de la lumière");
                        }

                        break;

                    case "point":


                        break;

                    case "vertex":

                        if (ReadFile.check_float(tmp,3,"vertex"))
                        {


                            Console.WriteLine("Création d'une vertice");
                        }

                        break;

                    case "tri":

                        if (ReadFile.check_float(tmp,3,"tri"))
                        {

                            Console.WriteLine("Création d'un triangle");
                        }

                        break;


                    case "sphere":

                        if (ReadFile.check_float(tmp,3,"sphere"))
                        {


                            Console.WriteLine("Création d'une sphère");
                        }

                        break;

                    case "plane":

                        if (ReadFile.check_float(tmp,3,"plane"))
                        {


                            Console.WriteLine("Création d'un plan ");
                        }

                        break;

                    default:
                        Console.WriteLine("mot clef inconnu");
                        break;

                }

                if (!size_present || !output_present)
                    Console.WriteLine("Le fichier de scène doit obligatoirement présenté un fichier de sortie et une taille de fenêtre ");

                if (!ambient_present)
                    Console.WriteLine("Lumière ambiente requise");

                if (!specular_present)
                    Console.WriteLine("plop");

                if (!diffuse_present)
                    Console.WriteLine("Diffusion de la lumière requise");

                if (!directional_present)
                    Console.WriteLine("Lumière directionelle requise");

                if (!camera_present)
                {
                    //camera=0,0,0,0,0,0,0
                    ;
                }


            }

        }



        public static bool check_size(string[] s)
        {

            int test_int;

            if (s.Length != 3){

                Console.WriteLine("le mot clef size doit être suivi de 2 entiers !!!");
                return false;
            }

            if (!Int32.TryParse(s[1], out test_int) || !Int32.TryParse(s[1], out test_int)){

                Console.WriteLine("un ou plusieurs paramètres ne sont pas de type entier !!!");
                return false;
            }

            return true;
        }

  

     
        public static bool check_float(string[] s,int nb_arg_to_check,string keyword)
        {

            double test_float;
            int i;

            if (s.Length != nb_arg_to_check+1){

                Console.WriteLine("le mot clef"+keyword +" doit être suivi de "+nb_arg_to_check +" réels !!!");
                return false;
            }


            for (i = 1; i < nb_arg_to_check; i++){

                if (!Double.TryParse(s[i], out test_float)) { 
                    Console.WriteLine("Le paramètre"+s[i]+" n'est pas de type réel !!!");
                    return false;
                }
            }
      

            return true;

        }


        public static bool check_output(string[] s)
        {


            if (s.Length != 2){

                Console.WriteLine("le mot clef output doit être suivi d'un nom de fichier !!!");
                return false;
            }


            return true;

        }    

    }
}