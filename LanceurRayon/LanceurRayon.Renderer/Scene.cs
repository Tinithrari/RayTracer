using System.Drawing;
using System.Collections;



namespace LanceurRayon.Renderer
{
    //Les classes suivantes servent de place holder pour une implémentation future
    class Vertex { }
    class Sphere {

        private double x;
        private double y;
        private double z;
        private double rayon;


        public Sphere(double x ,double y,double z,double rayon) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.rayon = rayon;
        }

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public double Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
            }
        }

        public double Rayon
        {
            get
            {
                return rayon;
            }

            set
            {
                rayon = value;
            }
        }
    }


    class Triangle { }
    class Plan { }

    public class Scene
    {
        private string output;
        private Bitmap fenetre;
        private double[] camera;

        //Les différentes entitées géométriques composants la scène.
        private ArrayList les_points;
        private ArrayList les_vertices;
        private ArrayList les_spheres;
        private ArrayList les_triangles;
        private ArrayList les_plans;


        //Données concernant l'éclairage
        
        private double[] couleur_ambiante;
        private double[] diffusion_lumiere;
        private double[] lumiere_reflechie;
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

        public double[] Camera
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

        public double[] Couleur_ambiante
        {
            get
            {
                return couleur_ambiante;
            }

            set
            {
                couleur_ambiante = value;
            }
        }

        public double[] Diffusion_lumiere
        {
            get
            {
                return diffusion_lumiere;
            }

            set
            {
                diffusion_lumiere = value;
            }
        }

        public double[] Lumiere_reflechie
        {
            get
            {
                return lumiere_reflechie;
            }

            set
            {
                lumiere_reflechie = value;
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


        public void add_Sphere(double x,double y,double z ,double R){
            les_spheres.Add(new Sphere(x,y,z,R));

        }
    }
}
