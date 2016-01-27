using System.Drawing;
using System.Collections;
using LanceurRayon.Math;


namespace LanceurRayon.Renderer
{

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


        //Les méthodes

        public void add_lumiere_globale(Vec3 direction ,Math.Color couleur )
        {

            les_lumieres_globales.Add(new Lumiere(direction,couleur));

        }

        public void add_lumiere_locale(Vec3 direction, Math.Color couleur)
        {

            les_lumieres_locales.Add(new Lumiere(direction, couleur));

        }

        public void add_Sphere(Sphere S){

           
            les_spheres.Add(S);

        }

        public void add_Plan(Math.Point pt, Vec3 vecteur_normal)
        {

            les_plans.Add(new Plan(pt, vecteur_normal));

        }

        public void add_Triangle(Math.Point pt)
        {

            les_triangles.Add(new Triangle(pt));

        }

        public void add_Point(Math.Point pt)
        {

            les_points.Add(pt);

        }

        public string toString(){

            return output + "\n" +
                    (fenetre.Size.Height * fenetre.Size.Width) + "\n" +
                    nb_objets + "\n" +
                    nb_lumieres;
                                    
        }

        public Scene()
        {

            les_points = new ArrayList();
            les_spheres = new ArrayList();
            les_triangles = new ArrayList();
            les_plans = new ArrayList();
            les_lumieres_globales = new ArrayList();
            les_lumieres_locales = new ArrayList();
        }
    }
}
