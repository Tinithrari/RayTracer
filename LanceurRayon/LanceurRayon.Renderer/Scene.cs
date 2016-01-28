using System.Drawing;
using System.Collections;
using LanceurRayon.Math;


namespace LanceurRayon.Renderer
{
    /// <summary>
    /// Classe contenant les différentes entitées géométriques, sources de lumières
    /// </summary>
    public class Scene{

        //Les informations générales de la scène
        public string output { get; set; }
        public Bitmap fenetre { get; set; }
        public Camera camera { get; set; }

        public  int nb_objets { get; set; }
        public int nb_lumieres { get; set; }

        //Les différentes entitées géométriques composants la scène.

        public ArrayList les_points { get; private set;}
        public ArrayList les_spheres { get; private set; }
        public ArrayList les_triangles { get; private set; }
        public ArrayList les_plans { get; private set; }

        //Les sources de lumières

        public ArrayList les_lumieres_globales { get; private set; }
        public ArrayList les_lumieres_locales { get; private set; }



        public Scene()
        {

            les_points = new ArrayList();
            les_spheres = new ArrayList();
            les_triangles = new ArrayList();
            les_plans = new ArrayList();
            les_lumieres_globales = new ArrayList();
            les_lumieres_locales = new ArrayList();
        }

        //Les méthodes

        /// <summary>
        /// Ajoute une source de lumière globale à la scène
        /// </summary>
        /// <param name="L">Source de lumière</param>

        public void add_lumiere_globale(Lumiere L )
        {

            les_lumieres_globales.Add(L);

        }


        /// <summary>
        /// Ajoute une source de lumière locale à la scène
        /// </summary>
        /// <param name="L">Source de lumière</param>

        public void add_lumiere_locale(Lumiere L)
        {

            les_lumieres_locales.Add(L);

        }


        /// <summary>
        /// Ajoute une Sphère à la scène
        /// </summary>
        /// <param name="S">Sphère</param>

        public void add_Sphere(Sphere S){

           
            les_spheres.Add(S);

        }

        /// <summary>
        /// Ajoute un plan à la scène
        /// </summary>
        /// <param name="P">Plan </param>

        public void add_Plan(Plan P)
        {

            les_plans.Add(P);

        }

        /// <summary>
        /// Ajoute un triangle à la scène
        /// </summary>
        /// <param name="T">Triangle</param>

        public void add_Triangle(Triangle T)
        {

            les_triangles.Add(T);

        }

        /// <summary>
        /// Ajoute un point à la scène
        /// </summary>
        /// <param name="P">Point</param>

        public void add_Point(Math.Point pt)
        {

            les_points.Add(pt);

        }

        /// <summary>
        /// Fournit une description de la scène
        /// </summary>
    

        public string toString(){

            return output + "\n" +
                    (fenetre.Size.Height * fenetre.Size.Width) + "\n" +
                    nb_objets + "\n" +
                    nb_lumieres;
                                    
        }

      
    }
}
