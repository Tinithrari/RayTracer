using System.Drawing;
using System.Collections;
using LanceurRayon.Math;
using System.Collections.Generic;
using System;

namespace LanceurRayon.Renderer
{
    /// <summary>
    /// Classe contenant les différentes entitées géométriques, sources de lumières
    /// </summary>
    public class Scene{

        //Les informations générales de la scène
        public bool Shadow { get;  set; }
        public string Output { get; set; }
        public Bitmap Fenetre { get; set; }
        public Camera Camera { get; set; }
        public int maxdepth { get; set; }
        public  int NbObjets { get; set; }
        public int NbLumieres { get; set; }

        //Les différentes entitées géométriques composants la scène.

        public List<Math.Point> LesPoints { get; private set;}
        public List<VisualEntity> Entite { get; private set; }

        //Les sources de lumières
        public List<Lumiere> Eclairage { get; private set; }
  

        public Scene()
        {

            LesPoints = new List<Math.Point>();
            Entite = new List<VisualEntity>();
            Eclairage = new List<Lumiere>();
        }

        //Les méthodes

        /// <summary>
        /// Ajoute une source de lumière globale à la scène
        /// </summary>
        /// <param name="L">Source de lumière</param>

      
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
        /*
        /// <summary>
        /// Vérifie que la somme des contributions des couleurs ne de passe pas 1.
        /// </summary>
        public void check_Lumiere()
        {
            LesLumieresLocales[2]=; 
        }
        */
    }
}
