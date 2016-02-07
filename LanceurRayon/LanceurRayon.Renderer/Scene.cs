using System.Drawing;
using System.Collections;
using LanceurRayon.Math;
using System.Collections.Generic;

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
        public List<VisualEntity> Entite { get; private set; }

        //Les sources de lumières
        public ArrayList LesLumieresGlobales { get; private set; }
        public ArrayList LesLumieresLocales { get; private set; }



        public Scene()
        {

            LesPoints = new ArrayList();
            Entite = new List<VisualEntity>();
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
