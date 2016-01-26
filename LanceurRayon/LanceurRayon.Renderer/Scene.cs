using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanceurRayon.Renderer
{
    class Vertex { }
    class Sphere { }
    class Triangle { }
    class Plan { }

    public class Scene
    {
        
        private Bitmap fenetre;

        //Les différentes entitées géométriques composants la scène.
        private Point[] les_points;
        private Vertex[] les_vertices;
        private Sphere[] les_spheres;
        private Triangle[] les_triangles;
        private Plan[] les_plans;


        //Données concernant l'éclairage
        private double[] camera;
        private double[] couleur_ambiante;
        private double[] diffusion_lumiere;
        private double[] lumiere_reflechie;
        private double[] lumiere_directionelle;

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

        public Point[] Les_points
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

        internal Vertex[] Les_vertices
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

        internal Sphere[] Les_spheres
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

        internal Triangle[] Les_triangles
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

        internal Plan[] Les_plans
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
    }
}
