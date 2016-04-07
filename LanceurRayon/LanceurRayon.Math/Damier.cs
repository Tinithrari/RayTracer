using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{ 
    /// <summary>
    ///Damier posé sur le sol de la scène 
    /// </summary>
    public class Damier
    {
        /// <summary>
        /// 1ère couleur des dalles
        /// </summary>
        public Color C1{ get; private set; }

        /// <summary>
        /// 2nd couleur des dalles
        /// </summary>
        public Color C2 { get; private set; }

        /// <summary>
        /// taille des dalles au sol.
        /// </summary>
        public double Taille{ get; private set; }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="C1"></param>
        /// <param name="C2"></param>
        /// <param name="Taille"></param>
        public Damier(Color C1,Color C2, double Taille)
        {
            this.C1 = C1;
            this.C2 = C2;
            this.Taille = Taille;
        }
    }
}
