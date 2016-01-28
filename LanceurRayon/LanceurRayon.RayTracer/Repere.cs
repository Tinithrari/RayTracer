using LanceurRayon.Math;

namespace LanceurRayon.RayTracer
{
    public class Repere
    {
        public Vec3 U { get; private set; }
        public Vec3 V { get; private set; }
        public Vec3 W { get; private set; }

        public Repere(Vec3 u, Vec3 v, Vec3 w)
        {
            this.U = u;
            this.V = v;
            this.W = w;
        }
    }
}
