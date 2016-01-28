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
        public string Output { get; set; }
        public Bitmap Fenetre { get; set; }
        public Camera Camera { get; set; }

        public  int NbObjets { get; set; }
        public int NbLumieres { get; set; }

        //Les différentes entitées géométriques composants la scène.

        public ArrayList LesPoints { get; private set;}
        public ArrayList LesSpheres { get; private set; }
        public ArrayList LesTriangles { get; private set; }
        public ArrayList LesPlans { get; private set; }

        //Les sources de lumières

        public ArrayList LesLumieresGlobales { get; private set; }
        public ArrayList LesLumieresLocales { get; private set; }



        public Scene()
        {

            LesPoints = new ArrayList();
            LesSpheres = new ArrayList();
            LesTriangles = new ArrayList();
            LesPlans = new ArrayList();
            LesLumieresGlobales = new ArrayList();
            LesLumieresLocales = new ArrayList();
        }

        //Les méthodes

        /// <summary>
        /// Ajoute une source de lumière globale à la scène
        /// </summary>
        /// <param name="L">Source de lumière</param>

        public void add_lumiere_globale(Lumiere L )
        {

            LesLumieresGlobales.Add(L);

        }


        /// <summary>
        /// Ajoute une source de lumière locale à la scène
        /// </summary>
        /// <param name="L">Source de lumière</param>

        public void add_lumiere_locale(Lumiere L)
        {

            LesLumieresLocales.Add(L);

        }


        /// <summary>
        /// Ajoute une Sphère à la scène
        /// </summary>
        /// <param name="S">Sphère</param>

        public void add_Sphere(Sphere S){

           
            LesSpheres.Add(S);

        }

        /// <summary>
        /// Ajoute un plan à la scène
        /// </summary>
        /// <param name="P">Plan </param>

        public void add_Plan(Plan P)
        {

            LesPlans.Add(P);

        }

        /// <summary>
        /// Ajoute un triangle à la scène
        /// </summary>
        /// <param name="T">Triangle</param>

        public void add_Triangle(Triangle T)
        {

            LesTriangles.Add(T);

        }

        /// <summary>
        /// Ajoute un point à la scène
        /// </summary>
        /// <param name="P">Point</param>

        public void add_Point(Math.Point pt)
        {

            LesPoints.Add(pt);

        }

        /// <summary>
        /// Fournit une description de la scène
        /// </summary>


        public override string ToString()
        {
            return Output + "\n" +
                    (Fenetre.Size.Height * Fenetre.Size.Width) + "\n" +
                    NbObjets + "\n" +
                    NbLumieres;
                                    
        }
    }
}
