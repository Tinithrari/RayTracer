using System.Drawing;
using System.Collections;
using LanceurRayon.Math;


namespace LanceurRayon.Renderer
{

    public class Scene{

        private string output;
        private Bitmap fenetre;
        private Camera camera;

        //Les différentes entitées géométriques composants la scène.
        private ArrayList les_points;
        private ArrayList les_vertices;
        private ArrayList les_spheres;
        private ArrayList les_triangles;
        private ArrayList les_plans;


        //Données concernant l'éclairage
        
       
        private double[] lumiere_directionelle;

        public string Output
        {
            get
            {
                return output;
            }

            set
            {
                output = value;
            }
        }

        public Bitmap Fenetre
        {
            get
            {
                return fenetre;
            }

            set
            {
                fenetre = value;
            }
        }

        public Camera Camera
        {
            get
            {
                return camera;
            }

            set
            {
                camera = value;
            }
        }

        public ArrayList Les_points
        {
            get
            {
                return les_points;
            }

            set
            {
                les_points = value;
            }
        }

        public ArrayList Les_vertices
        {
            get
            {
                return les_vertices;
            }

            set
            {
                les_vertices = value;
            }
        }

        public ArrayList Les_spheres
        {
            get
            {
                return les_spheres;
            }

            set
            {
                les_spheres = value;
            }
        }

        public ArrayList Les_triangles
        {
            get
            {
                return les_triangles;
            }

            set
            {
                les_triangles = value;
            }
        }

        public ArrayList Les_plans
        {
            get
            {
                return les_plans;
            }

            set
            {
                les_plans = value;
            }
        }

        public double[] Lumiere_directionelle
        {
            get
            {
                return lumiere_directionelle;
            }

            set
            {
                lumiere_directionelle = value;
            }
        }

        public void add_Sphere(double x,double y,double z ,double R,double V,double B){

            Les_spheres.Add(new Sphere(x,y,z,R,new LanceurRayon.Math.Color(R,V,B)));

        }
    }
}
