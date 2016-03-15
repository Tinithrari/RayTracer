using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Math
{   /// <summary>
    ///Classe modélisant une matrice carrée 4*4. 
    /// </summary>
     public class Mat4
    {
        /// <summary>
        /// 1ere colonne de la matrice.
        /// </summary>
        public Vec4 C1 { get;  set; }
        
        /// <summary>
        /// 2nd colonne de la matrice.
        /// </summary>
        public Vec4 C2 { get; set; }

        /// <summary>
        /// 3eme colonne de la matrice.
        /// </summary>
        public Vec4 C3 { get; set; }

        /// <summary>
        /// 4eme colonne de la matrice.
        /// </summary>
        public Vec4 C4 { get; set; }

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        /// <param name="C1">1ere colonne de la matrice.</param>
        /// <param name="C2">2nd colonne de la matrice.</param>
        /// <param name="C3">3eme colonne de la matrice.</param>
        /// <param name="C4">4eme colonne de la matrice.</param>
        public Mat4(Vec4 C1, Vec4 C2, Vec4 C3, Vec4 C4)
        {
            this.C1 = C1;
            this.C2 = C2;
            this.C3 = C3;
            this.C4 = C4;
        }

        /// <summary>
        /// Créer une matrice 4*4 remplit de zéro
        /// </summary>
        public Mat4()
        {
            C1 = new Vec4();
            C2 = new Vec4();
            C3 = new Vec4();
            C4 = new Vec4();
        }

        /// <summary>
        /// Addition de 2 matrices.
        /// </summary>
        /// <param name="m"></param>
        /// <returns>Résultat de l'opération</returns>
        public Mat4 add(Mat4 m)
        {
            return new Mat4(this.C1.add(m.C1), this.C2.add(m.C2), this.C3.add(m.C3), this.C4.add(m.C4));
        }

        /// <summary>
        /// Soustraction de 2 matrices.
        /// </summary>
        /// <param name="m"></param>
        /// <returns>Résultat de l'opération</returns>
        public Mat4 sub(Mat4 m)
        {
            return new Mat4(this.C1.sub(m.C1), this.C2.sub(m.C2), this.C3.sub(m.C3), this.C4.sub(m.C4));
        }

        /// <summary>
        /// Transposition de la matrice.
        /// </summary>
        /// <returns>Résultat de l'opération</returns>
        public Mat4 transpose()
        {

            return new Mat4(new Vec4(C1.X, C2.X, C3.X, C4.X),
                            new Vec4(C1.Y, C2.Y, C3.Y, C4.Y),
                            new Vec4(C1.Z, C2.Z, C3.Z, C4.Z),
                            new Vec4(C1.T, C2.T, C3.T, C4.T)
                           );
        }

        /// <summary>
        /// Créer la matrice de rotation d'angle t et d'axe v.
        /// </summary>
        /// <param name="v"></param>
        /// <param name="angle"></param>
        /// <returns>Résultat de l'opération</returns>
        public static Mat4 CreateRotationMatrix(Vec3 v,double angle)
        {

            double cos_angle = System.Math.Cos(angle), sin_angle = System.Math.Sin(angle), minus_cos_angle = 1 - cos_angle;

            return new Mat4(new Vec4(cos_angle + (v.X * v.X) * minus_cos_angle, (v.X * v.Y) * minus_cos_angle + (v.Z * sin_angle), (v.X * v.Z) * minus_cos_angle - (v.Y * sin_angle), 0),
                            new Vec4((v.X * v.Y) * minus_cos_angle - (v.Z * sin_angle), cos_angle + (v.Y * v.Y) * minus_cos_angle, ((v.Y * v.Z) * minus_cos_angle) + v.X * sin_angle, 0),
                            new Vec4((v.X * v.Z) * minus_cos_angle + (v.Y * sin_angle), (v.Y * v.Z) * minus_cos_angle - (v.X * sin_angle), cos_angle + ((v.Z * v.Z) * minus_cos_angle), 0),
                            new Vec4(0, 0, 0, 1)
                            );
        }

        /// <summary>
        /// Créer la matrice de translation de vecteur V.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Résultat de l'opération</returns>
        public static Mat4 CreateTranslationMatrix(Vec3 v)
        {

            return new Mat4(new Vec4(1, 0, 0, 0),
                            new Vec4(0, 1, 0, 0),
                            new Vec4(0, 0, 1, 0),
                            new Vec4(v.X, v.Y, v.Z, 1)
                            );
        }

        /// <summary>
        /// Créer la matrice d'homotéthie selon le vecteur v.
        /// </summary>
        /// <param name="v"></param>
        /// <returns>Résultat de l'opération</returns>
        public static Mat4 CreateScalingMatrix(Vec3 v)
        {

            return new Mat4(new Vec4(v.X, 0, 0, 0),
                            new Vec4(0, v.Y, 0, 0),
                            new Vec4(0, 0, v.Z, 0),
                            new Vec4(0, 0, 0, 1)
                            );
        }

        /// <summary>
        /// Calcul le produit d'un vecteur par une matrice 4*4 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="mode"></param>
        /// <returns>le vecteur résultant de l'opération</returns>
        public Vec4 productOneVector(Vec3 v,int mode) {
            Vec4 vt;
           
           vt= mode==1 ?  new Vec4(v.X,v.Y,v.Z,1) : new Vec4(v.X, v.Y, v.Z, 0) ;

            return new Vec4(vt.X * C1.X + vt.Y * C2.X + vt.Z * C3.X + vt.T * C4.X,
                            vt.X * C1.Y + vt.Y * C2.Y + vt.Z * C3.Y + vt.T * C4.Y,
                            vt.X * C1.Z + vt.Y * C2.Z + vt.Z * C3.Z + vt.T * C4.Z,
                            vt.X * C1.T + vt.Y * C2.T + vt.Z * C3.T + vt.T * C4.T
                            );
        }
        
        /// <summary>
        /// Produit matriciel droite
        /// </summary>
        /// <param name="m">Résultat de l'opération </param>
        /// <returns></returns>
        public Mat4 RightMatrixProduct(Mat4 m) {

              Vec4 vl1, vl2, vl3, vl4;

            vl1 = new Vec4(m.C1.X, m.C2.X, m.C3.X, m.C4.X);
            vl2 = new Vec4(m.C1.Y, m.C2.Y,m.C3.Y, m.C4.Y);
            vl3 = new Vec4(m.C1.Z, m.C2.Z, m.C3.Z, m.C4.Z);
            vl4 = new Vec4(m.C1.T, m.C2.T, m.C3.T, m.C4.T);

           return new Mat4(
                            new Vec4(vl1.dot(this.C1) , vl1.dot(this.C2), vl1.dot(this.C3), vl1.dot(this.C4)),
                            new Vec4(vl2.dot(this.C1), vl2.dot(this.C2), vl2.dot(this.C3), vl2.dot(this.C4)),
                            new Vec4(vl3.dot(this.C1), vl3.dot(this.C2), vl3.dot(this.C3), vl3.dot(this.C4)),
                            new Vec4(vl4.dot(this.C1), vl4.dot(this.C2), vl4.dot(this.C3), vl4.dot(this.C4))
                            );


        }

        /// <summary>
        /// Produit matriciel gauche.
        /// </summary>
        /// <param name="m">Résultat de l'opération </param>
        /// <returns></returns>
        public Mat4 LeftMatrixProduct(Mat4 m)
        {
            Vec4 vl1, vl2, vl3, vl4;

            vl1 = new Vec4(C1.X, C2.X, C3.X, C4.X);
            vl2 = new Vec4(C1.Y, C2.Y, C3.Y, C4.Y);
            vl3 = new Vec4(C1.Z, C2.Z, C3.Z, C4.Z);
            vl4 = new Vec4(C1.T, C2.T, C3.T, C4.T);

            return new Mat4(
                            new Vec4(vl1.dot(m.C1) , vl1.dot(m.C2), vl1.dot(m.C3), vl1.dot(m.C4)),
                            new Vec4(vl2.dot(m.C1), vl2.dot(m.C2), vl2.dot(m.C3), vl2.dot(m.C4)),
                            new Vec4(vl3.dot(m.C1), vl3.dot(m.C2), vl3.dot(m.C3), vl3.dot(m.C4)),
                            new Vec4(vl4.dot(m.C1), vl4.dot(m.C2), vl4.dot(m.C3), vl4.dot(m.C4))
                            );

        }

        /// <summary>
        /// Fournit une répresentation textuel d'une matrice
        /// </summary>
        /// <returns>Le texte décrivant la matrice.</returns>
        public override String ToString() {

            return C1.X.ToString() + " " + C2.X.ToString() + " " + C3.X.ToString() + " " + C4.X.ToString() + "\n"+
                   C1.Y.ToString() + " " + C2.Y.ToString() + " " + C3.Y.ToString() + " " + C4.Y.ToString() + "\n" +
                   C1.Z.ToString() + " " + C2.Z.ToString() + " " + C3.Z.ToString() + " " + C4.Z.ToString() + "\n" +
                   C1.T.ToString() + " " + C2.T.ToString() + " " + C3.T.ToString() + " " + C4.T.ToString() + "\n" ;
                   
        }

       
    }
}