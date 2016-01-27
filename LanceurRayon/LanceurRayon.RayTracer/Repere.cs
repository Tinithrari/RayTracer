using LanceurRayon.Math;

namespace LanceurRayon.RayTracer
{
    public class Repere
    {
        private Vec3 u;
        private Vec3 v;
        private Vec3 w;

        public Repere(Vec3 u, Vec3 v, Vec3 w)
        {
            this.u = u;
            this.v = v;
            this.w = w;
        }

        public Vec3 U
        {
            get
            {
                return u;
            }
        }

        public Vec3 V
        {
            get
            {
                return v;
            }
        }

        public Vec3 W
        {
            get
            {
                return w;
            }
        }
    }
}
