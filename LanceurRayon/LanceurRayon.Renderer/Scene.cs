using System.Drawing;
using System.Collections;
using LanceurRayon.Math;


namespace LanceurRayon.Renderer
{

    public class Scene{

        public string output { get; set; }
        public Bitmap fenetre { get; set; }
        public Camera camera { get; set; }
        public  int nb_objets { get; set; }
        public int nb_lumieres { get; set; }

        //Les différentes entitées géométriques composants la scène.

        public ArrayList les_points { get; private set;}
        public ArrayList les_vertices { get; private set; }
        public ArrayList les_spheres { get; private set; }
        public ArrayList les_triangles { get; private set; }
        public ArrayList les_plans { get; private set; }



        //Donnée concernant l'éclairage de la scène

        public double[] lumiere_directionelle { get; private set; }
        


        public void add_Sphere(double x,double y,double z ,double R){

            les_spheres.Add(new Sphere(x,y,z,R));

        }

        public string toString(){

            return output + "\n" +
                    (fenetre.Size.Height * fenetre.Size.Width) + "\n" +
                    nb_objets + "\n" +
                    nb_lumieres;
                                    
        }
    }
}
