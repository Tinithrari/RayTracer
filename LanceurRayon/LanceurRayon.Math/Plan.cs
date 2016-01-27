using System;


namespace LanceurRayon.Math
{
    public class Plan
    {
       

        public Point pt { get; private set; }
        public Vec3 vecteur_normal { get; private set; }
    

        public Plan(Point pt,Vec3 vecteur_normal)
        {
            this.pt = pt;
            this.vecteur_normal = vecteur_normal;
          
        }

    
    }
}
