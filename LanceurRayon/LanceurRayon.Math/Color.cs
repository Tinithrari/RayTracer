﻿using System;
using System.Globalization;

namespace LanceurRayon.Math
{
    /// <summary>
    /// Représente une couleur à partir de double, dont les valeurs varient dans l'intervalle [0, 1]
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Accesseur pour la variante rouge
        /// </summary>
        public double R { get; private set; }

        /// <summary>
        /// Accesseur pour la variante verte
        /// </summary>
        public double G { get; private set; }

        /// <summary>
        /// Accesseur pour la variante bleu
        /// </summary>
        public double B { get; private set; }

        /// <summary>
        /// Permet de créer une couleur noire
        /// </summary>
        public Color() : this(0,0,0)
        { }

        /// <summary>
        /// Permet de créer une couleur à partir de ses valeurs r, g et b
        /// </summary>
        /// <param name="r">La valeur pour le rouge</param>
        /// <param name="g">La valeur pour le vert</param>
        /// <param name="b">La valeur pour le bleu</param>
        /// <exception cref="ArgumentOutOfRangeException">Exception lancée si l'un des arguments est en dehors de l'intervalle [0, 1]</exception>
        public Color(double r, double g, double b)
        {
            this.R = r;
            this.G = g;
            this.B = b;
        }

        /// <summary>
        /// Méthode fabrique construisant le point à partir de chaine de caractère
        /// </summary>
        /// <param name="r">La valeur de R</param>
        /// <param name="g">La valeur de G</param>
        /// <param name="b">La valeur de B</param>
        /// <returns>La couleur correspondant à a description passé en paramètre</returns>
        public static Color createColor(string r, string g, string b)
        {
            try
            {
                return new Color(double.Parse(r, CultureInfo.InvariantCulture), double.Parse(g, CultureInfo.InvariantCulture), double.Parse(b, CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Permet d'additioner deux couleurs
        /// </summary>
        /// <param name="c">La couleur à additionner à la couleur courante</param>
        /// <returns>La couleur résultante de l'opération</returns>
        /// <exception cref="ArgumentNullException">Exception lancée si l'argument est null</exception>
        /// <remarks>Si l'une des valeurs dépasse 1, celle-ci sera remplacée par 1</remarks>
        public Color add(Color c)
        {
            double newR, newG, newB;

            if (c == null)
                throw new ArgumentNullException("On ne peut additioner une couleur à une couleur non définie");

            newR = this.R + c.R;
            newG = this.G + c.G;
            newB = this.B + c.B;

            return new Color(newR, newG, newB);
        }

        /// <summary>
        /// Permet de multiplier une couleur par un scalaire
        /// </summary>
        /// <param name="scal">Le scalaire à utiliser pour la multiplcation</param>
        /// <returns>Le résultat de la multiplication par le scalaire</returns>
        /// <exception cref="ArgumentException">Exception levé si l'argument est négatif</exception>
        /// <remarks>Si le résultat de la multiplication d'un champs est supérieur à 1, le résultat sera remplacé par 1</remarks>
        public Color mul(Double scal)
        {
            double newR, newG, newB;

            if (scal < 0)
                throw new ArgumentException("Le scalaire doit être strictement positif");

            newR = this.R * scal;
            newG = this.G * scal;
            newB = this.B * scal;

            return new Color(newR, newG, newB);
        }

        /// <summary>
        /// Permet d'effectuer un produit de Schur
        /// </summary>
        /// <param name="c">La couleur avec laquelle effectuée un produit de Schur</param>
        /// <returns>Le résultat du produit de Schur</returns>
        /// <exception cref="ArgumentNullException">Si l'argument est null, cette exception est levée</exception>
        /// <remarks>Si le résultat de la multiplication d'un des champs est supérieur à 1, le résultat sera remplacé par 1</remarks>
        public Color times(Color c)
        {
            double newR, newG, newB;

            if (c == null)
                throw new ArgumentNullException("On ne peut effectuer un produit avec une couleur non définie");

            newR = this.R * c.R;
            newG = this.G * c.G;
            newB = this.B * c.B;

            return new Color(newR, newG, newB);
        }

        /// <summary>
        /// Convertit une couleur en chaine de caractère
        /// </summary>
        /// <returns>Une chaine de la forme C R G B</returns>
        public override string ToString()
        {
            return string.Format("C {0} {1} {2}", this.R.ToString("0.0#", CultureInfo.InvariantCulture),
                this.G.ToString("0.0#", CultureInfo.InvariantCulture), this.B.ToString("0.0#", CultureInfo.InvariantCulture));
        }
    }
}
